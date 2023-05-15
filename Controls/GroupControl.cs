using Npgsql;
using Npgsql.Internal.TypeHandlers.LTreeHandlers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timetable.Controller;
using Timetable.Forms;
using Timetable.Models;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace Timetable.Controls
{
    public partial class GroupControl : UserControl
    {
        private NpgsqlConnection conn;
        private DBForm form;
        List<Faculty> faculties = new List<Faculty>();
        private List<string> formeducation;
        public GroupControl(NpgsqlConnection conn, DBForm form)
        {
            InitializeComponent();
            this.conn = conn;
            this.form = form;

            List<object[]> obj = new List<object[]>();
            List<string> title = new List<string>();

            (obj, title) = SqlAssistant.SelectAll("SELECT idfaculty,namefaculty,iddepartments FROM faculty;", 3, conn);

            faculties = new List<Faculty>(Faculty.GetFaculties(obj, title));
            cmbBoxFaculty.Items.AddRange(SqlAssistant.SelectOne("SELECT namefaculty FROM faculty", conn).ToArray());

            formeducation = SqlAssistant.SelectOne("SELECT pg_enum.enumlabel AS enumlabel FROM pg_type JOIN pg_enum ON pg_enum.enumtypid = pg_type.oid WHERE pg_type.typname = 'formeducation';", conn);
            cmbBoxFormeducation.Items.AddRange(formeducation.ToArray());
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {

                GroupTable group = new GroupTable()
                {
                    Name = txtName.Text,
                    Faculty = faculties.Find(x => x.Name == cmbBoxFaculty.Text),
                    Formeducation = cmbBoxFormeducation.Text,
                    RecruitmentYear = Convert.ToDateTime(dTPRecruitmentYear.Text),
                    Amount = ConvertCustom.ConvertToInt(txtAmount.Text),

                };
                if (!SqlAssistant.CheckInfo($"SELECT idgroup FROM groupTable WHERE namegroup ='{group.Name}';", conn))
                {
                    NpgsqlCommand command = new NpgsqlCommand("INSERT INTO grouptable(idfaculty,namegroup,formeducation,recruitmentyear,amount,idcurriculum) VALUES (@idfaculty,@namegroup,@formeducation::formeducation,@recruitmentyear,@amount,@idcurriculum)", conn);
                    command.Parameters.AddWithValue("idfaculty", group.Faculty.Id);
                    command.Parameters.AddWithValue("namegroup", group.Name);
                    command.Parameters.AddWithValue("formeducation", group.Formeducation);
                    command.Parameters.AddWithValue("recruitmentyear", group.RecruitmentYear);
                    command.Parameters.AddWithValue("amount", group.Amount);
                    command.Parameters.AddWithValue("idcurriculum", group.Curriculum.Id);
                    command.ExecuteNonQuery();
                    form.ClearDataGrid();
                    form.UpdateGroupTable("SELECT idgroup, namegroup, formeducation, recruitmentyear, amount, " +
                    "idfaculty, namefaculty, iddepartments, namedepartments,idcurriculum,namecurriculum,qualification" +
                    " FROM grouptable LEFT JOIN faculty USING(idfaculty) LEFT JOIN departments USING(iddepartments) LEFT JOIN curriculum USING(idcurriculum);;", 12);
                }
                else
                {
                    MessageBox.Show("Такой группа уже есть");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCurriculum_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}
