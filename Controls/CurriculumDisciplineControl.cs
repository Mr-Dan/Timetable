using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
    public partial class CurriculumDisciplineControl : UserControl
    {
        private NpgsqlConnection conn;
        private DBForm form;
        public CurriculumDisciplineControl(NpgsqlConnection conn, DBForm form)
        {
            InitializeComponent();
            this.conn = conn;
            this.form = form;
        }

        private void txtCurriculum_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelectControl selectControl = new SelectControl("SELECT " +
          "idcurriculum,namecurriculum,qualification" +
          " FROM curriculum;",
          3,
          "idcurriculum",
         "curriculum", txtCurriculum, conn)
            {
                Name = "SelectControl",
                Location = new Point(100, 100),
            };
            form.Controls.Add(selectControl);
            selectControl.BringToFront();
        }

        private void txtDiscipline_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelectControl selectControl = new SelectControl("SELECT " +
          "iddiscipline,namediscipline,typelesson" +
          " FROM discipline;",
          3,
          "iddiscipline",
         "discipline", txtDiscipline, conn)
            {
                Name = "SelectControl",
                Location = new Point(100, 100),
            };
            form.Controls.Add(selectControl);
            selectControl.BringToFront();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                CurriculumDiscipline curriculumDiscipline = new CurriculumDiscipline()
                {
                    Curriculum = new Curriculum()
                    {
                        Id = ConvertCustom.ConvertToInt(txtCurriculum.Text),
                    },
                    Discipline = new Discipline() 
                    {
                        Id = ConvertCustom.ConvertToInt(txtDiscipline.Text),
                    },
                    Course = ConvertCustom.ConvertToInt(txtCourse.Text),
                    Semester = ConvertCustom.ConvertToInt(txtSemester.Text),
                    Hours = ConvertCustom.ConvertToInt(txtHours.Text),
                };

                if (!SqlAssistant.CheckInfo($"SELECT idcurriculumdiscipline FROM curriculumdiscipline WHERE idcurriculum ='{curriculumDiscipline.Curriculum.Id}' AND iddiscipline ='{curriculumDiscipline.Discipline.Id}'AND course ='{curriculumDiscipline.Course}'AND semester ='{curriculumDiscipline.Semester}';", conn)) // Если не нашли
                {
                    NpgsqlCommand command = new NpgsqlCommand("INSERT INTO curriculumdiscipline(idcurriculum,iddiscipline,course,semester,hours) VALUES(@idcurriculum,@iddiscipline,@course,@semester,@hours)", conn);
                    command.Parameters.AddWithValue("idcurriculum", curriculumDiscipline.Curriculum.Id);
                    command.Parameters.AddWithValue("iddiscipline", curriculumDiscipline.Discipline.Id);
                    command.Parameters.AddWithValue("course", curriculumDiscipline.Course);
                    command.Parameters.AddWithValue("semester", curriculumDiscipline.Semester);
                    command.Parameters.AddWithValue("hours", curriculumDiscipline.Hours);
                    command.ExecuteNonQuery();
                    form.ClearDataGrid();
                    form.UpdateCurriculumDiscipline("SELECT idcurriculumdiscipline,course,semester,hours," +
                    "idcurriculum,namecurriculum,qualification," +
                    "iddiscipline,namediscipline,typelesson" +
                    " FROM curriculumdiscipline LEFT JOIN curriculum USING(idcurriculum) LEFT JOIN discipline USING(iddiscipline);", 10);
                }
                else
                {
                    MessageBox.Show("Такая дисциплина уже есть в учебном плане");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
