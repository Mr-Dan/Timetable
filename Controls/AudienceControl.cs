using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timetable.Controller;
using Timetable.Forms;
using Timetable.Models;

namespace Timetable.Controls
{
    public partial class AudienceControl : UserControl
    {
        private NpgsqlConnection conn;
        private DBForm form;
        private List<string> typeAudience;
        public AudienceControl(NpgsqlConnection conn, DBForm form)
        {
            InitializeComponent();
            this.conn = conn;
            this.form = form;
            typeAudience = SqlAssistant.SelectOne("SELECT pg_enum.enumlabel AS enumlabel FROM pg_type JOIN pg_enum ON pg_enum.enumtypid = pg_type.oid WHERE pg_type.typname = 'typeaudience';",conn);
            typeComboBox.Items.AddRange(typeAudience.ToArray());
        }
        private void ButtonInsert_Click(object sender, EventArgs e)
        { // При нажатие на кнопку
            try
            {
                Audience audience = new Audience() // создаем класс для проверки введенных данных
                {
                    Name = NametextBox.Text,
                    Address = AddresstextBox.Text,
                    Type = typeComboBox.Text,
                    Capacity = Convert.ToInt32(capacitytextBox.Text),
                    TravelTime = traveltimedateTimePicker.Value.TimeOfDay,
                };
                if (!SqlAssistant.CheckInfo($"SELECT idaudience FROM audience WHERE nameaudience ='{audience.Name}';", conn)) // Если не нашли
                {
                    NpgsqlCommand command = new NpgsqlCommand("INSERT INTO audience(nameaudience,address,typeAudience,capacity,travelTime) " +
                        "VALUES (@nameaudience,@address,@typeAudience::typeAudience,@capacity,@travelTime);", conn);
                    command.Parameters.AddWithValue("nameaudience", audience.Name);
                    command.Parameters.AddWithValue("address", audience.Address);
                    command.Parameters.AddWithValue("typeAudience", audience.Type);
                    command.Parameters.AddWithValue("capacity", audience.Capacity);
                    command.Parameters.AddWithValue("travelTime", audience.TravelTime);
                    command.ExecuteNonQuery();
                    form.ClearDataGrid();
                    form.UpdateAudience("SELECT * FROM audience;", 6);
                }
                else
                {
                    MessageBox.Show("Такая аудитория уже есть");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
