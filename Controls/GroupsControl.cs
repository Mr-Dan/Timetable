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
    public partial class GroupsControl : UserControl
    {
        private NpgsqlConnection conn;
        private DBForm form;
        public GroupsControl(NpgsqlConnection conn, DBForm form)
        {
            InitializeComponent();
            this.conn = conn;
            this.form = form;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                Groups groups = new Groups()
                {
                    IdGroups = ConvertCustom.ConvertToInt(txtGroups.Text),
                    Group = new GroupTable()
                    {
                        Id = ConvertCustom.ConvertToInt(txtGroup.Text),
                    }
                };
                if (!SqlAssistant.CheckInfo($"SELECT id FROM groups WHERE idgroups ='{groups.IdGroups}' AND idgroup ='{groups.Group.Id}';", conn)) // Если не нашли
                {
                    NpgsqlCommand command = new NpgsqlCommand("INSERT INTO groups(idgroups,idgroup) VALUES(@idgroups,@idgroup)", conn);
                    command.Parameters.AddWithValue("idgroups", groups.IdGroups);
                    command.Parameters.AddWithValue("idgroup", groups.Group.Id);
                    command.ExecuteNonQuery();
                    form.ClearDataGrid();
                    form.UpdateGroups("SELECT id,idgroups," +
                    "idgroup,namegroup," +
                    "idfaculty,namefaculty," +
                    "iddepartments,namedepartments" +
                    " FROM groups LEFT JOIN grouptable USING(idgroup) LEFT JOIN faculty USING(idfaculty) LEFT JOIN departments  USING(iddepartments);", 8);
                }
                else
                {
                    MessageBox.Show("Такой поток уже есть");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtGroup_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelectControl selectControl = new SelectControl("SELECT idgroup, namegroup, formeducation, recruitmentyear, amount, " +
                    "idfaculty, namefaculty, iddepartments, namedepartments" +
                    " FROM grouptable LEFT JOIN faculty USING(idfaculty) LEFT JOIN departments USING(iddepartments);",
         9,
         "idgroup",
        "group", txtGroup, conn)
            {
                Name = "SelectControl",
                Location = new Point(100, 100),
            };
            form.Controls.Add(selectControl);
            selectControl.BringToFront();
        }
    }
}
