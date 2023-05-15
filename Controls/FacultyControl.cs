using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timetable.Controller;
using Timetable.Forms;
using Timetable.Models;

namespace Timetable.Controls
{
    public partial class FacultyControl : UserControl
    {
        private NpgsqlConnection conn;
        private DBForm form;
        List<Departments> departments = new List<Departments>();
        public FacultyControl(NpgsqlConnection conn, DBForm form)
        {
            InitializeComponent();
            this.conn = conn;
            this.form = form;

            List<object[]> obj = new List<object[]>();
            List<string> title = new List<string>();
            (obj, title) = SqlAssistant.SelectAll("SELECT departments.iddepartments,namedepartments FROM departments", 2, conn);

            departments = new List<Departments>(Departments.GetDepartments(obj, title));
            cmbBoxDepartments.Items.AddRange(SqlAssistant.SelectOne("SELECT namedepartments FROM departments", conn).ToArray());
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                Faculty faculty = new Faculty()
                {
                    Name = txtName.Text,
                    Departments = departments.Find(x => x.Name.Equals(cmbBoxDepartments.Text.Trim())),
                };
                if (!SqlAssistant.CheckInfo($"SELECT idfaculty FROM faculty WHERE namefaculty ='{faculty.Name}';", conn)) 
                {
                    NpgsqlCommand command = new NpgsqlCommand("INSERT INTO faculty(namefaculty,iddepartments) VALUES (@namefaculty,@iddepartments)", conn);
                command.Parameters.AddWithValue("namefaculty", faculty.Name);
                command.Parameters.AddWithValue("iddepartments", faculty.Departments.Id);
                command.ExecuteNonQuery();
                form.ClearDataGrid();
                form.UpdateFaculty("SELECT idfaculty, namefaculty,faculty.iddepartments," +
            " namedepartments FROM faculty LEFT JOIN departments USING(iddepartments);", 4);
                }
                else
                {
                    MessageBox.Show("Такой факультет уже есть");
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
