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
    public partial class AudienceFundControl : UserControl
    {
        private NpgsqlConnection conn;
        private DBForm form;
        private int id;
        public AudienceFundControl(NpgsqlConnection conn, DBForm form)
        {
            InitializeComponent();
            this.conn = conn;
            this.form = form;
        }

        private void txtDepartments_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelectControl selectControl = new SelectControl("SELECT " +
           "iddepartments,namedepartments" +
           " FROM departments;",
           2,
           "iddepartments",
          "departments", txtDepartments, conn)
            {
                Name = "SelectControl",
                Location = new Point(100, 100),
            };
            form.Controls.Add(selectControl);
            selectControl.BringToFront();
        }

        private void txtAudience_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelectControl selectControl = new SelectControl($"SELECT idaudience, nameaudience, address, typeaudience, capacity, traveltime FROM audience WHERE NOT EXISTS (SELECT * FROM audiencefund WHERE audience.idaudience = audiencefund.idaudience AND iddepartments ={txtDepartments.Text});",
          6,
          "idaudience",
         "audience", txtAudience, conn)
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
                AudienceFund audienceFund = new AudienceFund()
                {
                    Departments = new Departments()
                    {
                        Id = ConvertCustom.ConvertToInt(txtDepartments.Text),
                    },
                    Audience = new Audience()
                    {
                        Id = ConvertCustom.ConvertToInt(txtAudience.Text),
                    }                    
                };
                if (!SqlAssistant.CheckInfo($"SELECT idaudiencefund FROM audienceFund WHERE iddepartments ='{audienceFund.Departments.Id}' AND idaudience ='{audienceFund.Audience.Id}';", conn)) // Если не нашли
                {
                    NpgsqlCommand command = new NpgsqlCommand("INSERT INTO audienceFund(iddepartments,idaudience) VALUES(@iddepartments,@idaudience)", conn);
                    command.Parameters.AddWithValue("iddepartments", audienceFund.Departments.Id);
                    command.Parameters.AddWithValue("idaudience", audienceFund.Audience.Id);
                    command.ExecuteNonQuery();
                    form.ClearDataGrid();
                    form.UpdateAudienceFund("SELECT idaudiencefund," +
                    "iddepartments,namedepartments," +
                    "audiencefund.idaudience,nameaudience,address,typeaudience,capacity,traveltime" +
                    " FROM audiencefund LEFT JOIN audience USING(idaudience) LEFT JOIN departments USING(iddepartments);", 9);
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
