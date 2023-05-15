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
    public partial class CurriculumControl : UserControl
    {
        private NpgsqlConnection conn;
        private DBForm form;
        private List<string> qualification;

        public CurriculumControl(NpgsqlConnection conn, DBForm form)
        {
            InitializeComponent();
            this.conn = conn;
            this.form = form;
            qualification = SqlAssistant.SelectOne("SELECT pg_enum.enumlabel AS enumlabel FROM pg_type JOIN pg_enum ON pg_enum.enumtypid = pg_type.oid WHERE pg_type.typname = 'qualification';", conn);
            cmbBoxQualification.Items.AddRange(qualification.ToArray());
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                Curriculum curriculum = new Curriculum()
                {
                    Name = txtName.Text,
                    Qualification = cmbBoxQualification.Text,
                };
                if (!SqlAssistant.CheckInfo($"SELECT idcurriculum FROM curriculum WHERE namecurriculum ='{curriculum.Name}' AND qualification='{curriculum.Qualification}';", conn)) // Если не нашли
                {
                    NpgsqlCommand command = new NpgsqlCommand("INSERT INTO curriculum(namecurriculum,qualification) VALUES(@namecurriculum,@qualification::qualification)", conn);
                    command.Parameters.AddWithValue("namecurriculum", curriculum.Name);
                    command.Parameters.AddWithValue("qualification", curriculum.Qualification);
                    command.ExecuteNonQuery();
                    form.ClearDataGrid();
                    form.UpdateCurriculum("SELECT * FROM curriculum;", 3);
                }
                else
                {
                    MessageBox.Show("Такой учебный план уже есть");
                }

                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
