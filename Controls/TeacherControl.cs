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
using System.Xml;
using Timetable.Controller;
using Timetable.Forms;
using Timetable.Models;

namespace Timetable.Controls
{
    public partial class TeacherControl : UserControl
    {
        private NpgsqlConnection conn;
        private DBForm form;
        List<Departments> departments = new List<Departments>();

        public TeacherControl(NpgsqlConnection conn, DBForm form)
        {
            InitializeComponent();
            this.conn = conn;
            this.form = form;

            List<object[]> obj = new List<object[]>();
            List<string> title = new List<string>();
            (obj, title) = SqlAssistant.SelectAll("SELECT departments.iddepartments,namedepartments FROM departments", 2,conn);

            departments = new List<Departments>(Departments.GetDepartments(obj, title));
            cmbBoxDepartments.Items.AddRange(SqlAssistant.SelectOne("SELECT namedepartments FROM departments",conn).ToArray());
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                Teacher teacher = new Teacher()
                {
                    LastName = txtLastName.Text,
                    Name = txtName.Text,
                    Patronymic = txtPatronymic.Text,
                    Position = txtPosition.Text,
                    Departments = departments.Find(x => x.Name.Equals(cmbBoxDepartments.Text.Trim())),
                    AcademicDegree = txtAcademicDegree.Text,
                };


                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO teacher(iddepartments,lastname,nameteacher,patronymic,position,academicdegree)" +
                    "VALUES (@iddepartments,@lastname,@nameteacher,@patronymic,@position,@academicdegree);",conn);
                command.Parameters.AddWithValue("iddepartments", teacher.Departments.Id);
                command.Parameters.AddWithValue("lastname", teacher.LastName);
                command.Parameters.AddWithValue("nameteacher", teacher.Name);
                command.Parameters.AddWithValue("patronymic", teacher.Patronymic);
                command.Parameters.AddWithValue("position", teacher.Position);
                command.Parameters.AddWithValue("academicdegree", teacher.AcademicDegree);
                command.ExecuteNonQuery();
                form.ClearDataGrid();
                form.UpdateTeacher("SELECT " +
                    "teacher.idteacher,nameteacher,lastname,patronymic,position,academicdegree," +
                    "iddepartments,namedepartments " +
                    " FROM teacher LEFT JOIN departments  USING(iddepartments);", 8);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
