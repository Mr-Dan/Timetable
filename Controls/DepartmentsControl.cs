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
    public partial class DepartmentsControl : UserControl
    {
        private NpgsqlConnection conn;
        private DBForm form;
        private int id;
        public DepartmentsControl(NpgsqlConnection conn, DBForm form)
        {
            InitializeComponent();
            this.conn = conn;
            this.form = form;
        }

        private void txtAudience_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelectControl selectControl = new SelectControl("SELECT * FROM audience;",
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

    
        private void buttonInsert_Click(object sender, EventArgs e)
        {
            try
            {
                Departments department = new Departments()
                {
                    Name = txtName.Text,
                    Audience = new Audience() { Id = ConvertCustom.ConvertToInt(txtAudience.Text) },
                };
                if (!SqlAssistant.CheckInfo($"SELECT idaudience FROM departments WHERE namedepartments ='{department.Name}';", conn)) // Если не нашли
                {
                    NpgsqlCommand command = new NpgsqlCommand("INSERT INTO departments(namedepartments,idaudience) " +
                        "VALUES (@namedepartments,@idaudience);", conn);
                    command.Parameters.AddWithValue("namedepartments", department.Name);
                    command.Parameters.AddWithValue("idaudience", department.Audience.Id);
                    command.ExecuteNonQuery();
                    form.ClearDataGrid();
                    form.UpdateDepartments("SELECT " +
                    "departments.iddepartments,namedepartments," +
                    "idaudience,nameaudience,address,typeaudience " +
                    "FROM departments LEFT JOIN audience USING(idaudience)", 6);
                }
                else
                {
                    MessageBox.Show("Такая кафедра уже есть");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
