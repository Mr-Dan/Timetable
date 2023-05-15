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
    public partial class HeadDepartmentControl : UserControl
    {
        private NpgsqlConnection conn;
        private DBForm form;
        public HeadDepartmentControl(NpgsqlConnection conn, DBForm form)
        {
            InitializeComponent();
            this.conn = conn;
            this.form = form;
        }

        private void txtDepartments_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelectControl selectControl = new SelectControl("SELECT " +
                    "departments.iddepartments,namedepartments," +
                    "idaudience,nameaudience,address,typeaudience " +
                    "FROM departments LEFT JOIN audience USING(idaudience)",
                  6,
          "iddepartments",
         "departments", txtDepartments, conn)
            {
                Name = "SelectControl",
                Location = new Point(100, 100),
            };
            form.Controls.Add(selectControl);
            selectControl.BringToFront();
        }

        private void txtTeacher_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (txtDepartments.Text.Trim() != "")
            {
                SelectControl selectControl = new SelectControl("SELECT " +
                        "teacher.idteacher,nameteacher,lastname,patronymic,position,academicdegree," +
                        "iddepartments,namedepartments " +
                $" FROM teacher LEFT JOIN departments  USING(iddepartments) WHERE iddepartments ='{txtDepartments.Text}';",
                        8,
                "idteacher",
               "teacher", txtTeacher, conn)
                {
                    Name = "SelectControl",
                    Location = new Point(100, 100),
                };
                form.Controls.Add(selectControl);
                selectControl.BringToFront();
            }
            else
            {
                MessageBox.Show("Выберите кафедур");
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                HeadDepartment headDepartment = new HeadDepartment()
                {
                    Department = new Departments()
                    {
                        Id = ConvertCustom.ConvertToInt(txtDepartments.Text)
                    },
                    Teacher = new Teacher()
                    {
                        Id = ConvertCustom.ConvertToInt(txtTeacher.Text)

                    }
                };
                if (!SqlAssistant.CheckInfo($"SELECT idheadDepartment FROM headdepartment WHERE iddepartments ='{headDepartment.Department.Id}' AND idteacher ='{headDepartment.Teacher.Id}';", conn)) // Если не нашли
                {
                    NpgsqlCommand command = new NpgsqlCommand("INSERT INTO headdepartment(iddepartments,idteacher) " +
                        "VALUES (@iddepartments,@idteacher);", conn);
                    command.Parameters.AddWithValue("iddepartments", headDepartment.Department.Id);
                    command.Parameters.AddWithValue("idteacher", headDepartment.Teacher.Id);
                    command.ExecuteNonQuery();
                    form.ClearDataGrid();
                    form.UpdateHeadDepartment("SELECT idheaddepartment," +
            "headdepartment.iddepartments,namedepartments," +
            "headdepartment.idteacher,lastname,nameteacher,patronymic,position,academicdegree " +
            "FROM headdepartment LEFT JOIN  departments USING(iddepartments) LEFT JOIN teacher USING(idteacher);", 9);
                }
                else
                {
                    MessageBox.Show("Зав кафедры уже есть такой");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
