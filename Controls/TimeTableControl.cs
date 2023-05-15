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
    public partial class TimeTableControl : UserControl
    {
        private NpgsqlConnection conn;
        private TimetableSet form;
        private string name;
        private string semester;
        public TimeTableControl(NpgsqlConnection conn, TimetableSet form, string name, string semester)
        {
            InitializeComponent();
            this.conn = conn;
            this.form = form;
            this.semester = semester;
            this.name = name;
        }


        private void txtGroups_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelectControl selectControl = new SelectControl("SELECT id,idgroups," +
                    "idgroup,namegroup," +
                    "idfaculty,namefaculty," +
                    "iddepartments,namedepartments" +
                    " FROM groups LEFT JOIN grouptable USING(idgroup) " +
                    "LEFT JOIN faculty USING(idfaculty) " +
                    $"LEFT JOIN departments  USING(iddepartments) WHERE namegroup = '{name}';", 8,
          "idgroups",
         "groups", txtGroups, conn)
            {
                Name = "SelectControl",
                Location = new Point(100, 100),
            };
            form.Controls.Add(selectControl);
            selectControl.BringToFront();
        }

        private void txtTeacher_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelectControl selectControl = new SelectControl("SELECT " +
                    "teacher.idteacher,nameteacher,lastname,patronymic,position,academicdegree," +
                    "iddepartments,namedepartments " +
                    " FROM teacher LEFT JOIN departments  USING(iddepartments);", 8,
          "idteacher",
         "teacher", txtTeacher, conn)
            {
                Name = "SelectControl",
                Location = new Point(100, 100),
            };
            form.Controls.Add(selectControl);
            selectControl.BringToFront();
        }

        private void txtDiscipline_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelectControl selectControl = new SelectControl($"SELECT idcurriculumdiscipline,iddiscipline,typelesson,namediscipline,course,semester,hours FROM grouptable LEFT JOIN curriculum USING(idcurriculum) LEFT JOIN curriculumdiscipline USING (idcurriculum) LEFT JOIN discipline USING(iddiscipline) WHERE namegroup = '{name}'  AND semester = '{semester}';", 7,
          "iddiscipline",
         "curriculumdiscipline", txtDiscipline, conn)
            {
                Name = "SelectControl",
                Location = new Point(100, 100),
            };
            form.Controls.Add(selectControl);
            selectControl.BringToFront();
        }

        private void txtWeekday_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelectOneControl selectOneControl = new SelectOneControl(conn, txtWeekday, "weekday")
            {
                Name = "SelectControl",
                Location = new Point(100, 100),
            };
            form.Controls.Add(selectOneControl);
            selectOneControl.BringToFront();
        }

        private void txtClasstime_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelectOneControl selectOneControl = new SelectOneControl(conn, txtClasstime, "classtime")
            {
                Name = "SelectControl",
                Location = new Point(100, 100),
            };
            form.Controls.Add(selectOneControl);
            selectOneControl.BringToFront();
        }

        private void txtAudience_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelectControl selectControl = new SelectControl("SELECT * FROM audience;", 6,
          "idaudience",
         "audience", txtAudience, conn)
            {
                Name = "SelectControl",
                Location = new Point(100, 100),
            };
            form.Controls.Add(selectControl);
            selectControl.BringToFront();
        }

        private void txtPeriodicity_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelectOneControl selectOneControl = new SelectOneControl(conn, txtPeriodicity, "periodicity")
            {
                Name = "SelectControl",
                Location = new Point(100, 100),
            };
            form.Controls.Add(selectOneControl);
            selectOneControl.BringToFront();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Timetable timetable = new Models.Timetable()
                {
                    // ClassTime = Convert.ToDateTime( txtClasstime.Text).TimeOfDay,
                    
                    Teacher = new Teacher()
                    {
                        Id = ConvertCustom.ConvertToInt(txtTeacher.Text)
                    },
                    Discipline = new Discipline()
                    {
                        Id = ConvertCustom.ConvertToInt(txtDiscipline.Text)
                    },
                    Group = new GroupTable()
                    {
                        Id = ConvertCustom.ConvertToInt(txtGroups.Text)
                    },
                    Periodicity = txtPeriodicity.Text,

                };


              /*  if (!SqlAssistant.CheckInfo($"SELECT idtimetable FROM timetable " +
                    $"WHERE idgroups ='{timetable.Group.Id}' " +
                    $"AND  idteacher ='{timetable.Teacher.Id}'" +
                    $"AND iddiscipline ='{timetable.Discipline.Id}'" +
                    $"AND periodicity ='{timetable.Periodicity}';", conn)) // Если не нашли
                {*/
                    NpgsqlCommand command = new NpgsqlCommand("INSERT INTO timetable(idgroups,idteacher,iddiscipline,periodicity) " +
                        "VALUES (@idgroups,@idteacher,@iddiscipline,@periodicity::periodicity);", conn);
                    command.Parameters.AddWithValue("idgroups", timetable.Group.Id);
                    command.Parameters.AddWithValue("iddiscipline", timetable.Discipline.Id);
                    command.Parameters.AddWithValue("periodicity", timetable.Periodicity);
                    command.Parameters.AddWithValue("idteacher", timetable.Teacher.Id);
                    command.ExecuteNonQuery();
                    form.ClearDataGrid();
                    form.UpdateTimeTable($"SELECT idtimetable,idgroups,grouptable.namegroup,teacher.idteacher,teacher.lastName, teacher.nameteacher , teacher.patronymic, teacher.position, teacher.academicdegree,discipline.namediscipline,discipline.typeLesson,weekday,classTime,audience.idaudience,audience.nameaudience,periodicity FROM timetable NATURAL JOIN groups NATURAL JOIN grouptable LEFT JOIN teacher on timetable.idteacher = teacher.idteacher LEFT JOIN discipline on timetable.iddiscipline = discipline.iddiscipline LEFT JOIN audience on timetable.idaudience = audience.idaudience WHERE grouptable.namegroup = '{name}';", 16);
             /*   }
                else
                {
                    MessageBox.Show("Такой план уже есть");
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
}
