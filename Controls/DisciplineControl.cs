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
    public partial class DisciplineControl : UserControl
    {
        private NpgsqlConnection conn;
        private DBForm form;
        private List<string> typelesson;
        public DisciplineControl(NpgsqlConnection conn, DBForm form)
        {
            InitializeComponent();
            this.conn = conn;
            this.form = form;

            typelesson = SqlAssistant.SelectOne("SELECT pg_enum.enumlabel AS enumlabel FROM pg_type JOIN pg_enum ON pg_enum.enumtypid = pg_type.oid WHERE pg_type.typname = 'typelesson';", conn);
            cmbBoxTypelesson.Items.AddRange(typelesson.ToArray());
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                Discipline discipline = new Discipline()
                {
                    Name = txtName.Text,
                    TypeLesson = cmbBoxTypelesson.Text
                };
                if (!SqlAssistant.CheckInfo($"SELECT iddiscipline FROM discipline WHERE namediscipline ='{discipline.Name}' AND typelesson ='{discipline.TypeLesson}'::typelesson;", conn)) // Если не нашли
                {
                    NpgsqlCommand command = new NpgsqlCommand("INSERT INTO discipline(namediscipline,typelesson) VALUES(@namediscipline,@typelesson::typelesson)", conn);
                    command.Parameters.AddWithValue("namediscipline", discipline.Name);
                    command.Parameters.AddWithValue("typelesson", discipline.TypeLesson);
                    command.ExecuteNonQuery();
                    form.ClearDataGrid();
                    form.UpdateDiscipline("SELECT * FROM discipline;", 3);
                }
                else
                {
                    MessageBox.Show("Такая дисциплина уже есть");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
