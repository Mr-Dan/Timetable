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

namespace Timetable.Controls
{
    public partial class SelectOneControl : UserControl
    {
        private NpgsqlConnection conn;
        private DBForm form;
        private List<string> typeList;
        private DataGridViewCell data;
        private string type;
        private string trse;
        private TimetableSet timetableSet;
        private TextBox textBox;

        public SelectOneControl(NpgsqlConnection conn, DBForm form, DataGridViewCell data, string type)
        {
            InitializeComponent();
            this.conn = conn;
            this.form = form;
            this.data = data;
            this.type = type;
            typeList = SqlAssistant.SelectOne($"SELECT pg_enum.enumlabel AS enumlabel FROM pg_type JOIN pg_enum ON pg_enum.enumtypid = pg_type.oid WHERE pg_type.typname = '{type}';", conn);
            dataGridViewTable.Columns.Add("type", "выбор");
            for (int i = 0; i < typeList.Count; i++)
            {
                dataGridViewTable.Rows.Add(typeList[i]);
            }
        }

        public SelectOneControl(NpgsqlConnection conn, TextBox textBox, string type)
        {
            InitializeComponent();
            this.conn = conn;
            this.textBox = textBox;
            this.type = type;
            typeList = SqlAssistant.SelectOne($"SELECT pg_enum.enumlabel AS enumlabel FROM pg_type JOIN pg_enum ON pg_enum.enumtypid = pg_type.oid WHERE pg_type.typname = '{type}';", conn);
            dataGridViewTable.Columns.Add("type", "выбор");
            for (int i = 0; i < typeList.Count; i++)
            {
                dataGridViewTable.Rows.Add(typeList[i]);
            }
        }

        public SelectOneControl(NpgsqlConnection conn, string type, TimetableSet timetableSet)
        {

            InitializeComponent();
            this.conn = conn;
            this.type = type;
            this.timetableSet = timetableSet;
            typeList = SqlAssistant.SelectOne($"SELECT pg_enum.enumlabel AS enumlabel FROM pg_type JOIN pg_enum ON pg_enum.enumtypid = pg_type.oid WHERE pg_type.typname = '{type}';", conn);
            dataGridViewTable.Columns.Add("type", "выбор");
            for (int i = 0; i < typeList.Count; i++)
            {
                dataGridViewTable.Rows.Add(typeList[i]);
            }

        }
        public SelectOneControl(NpgsqlConnection conn, string type, TimetableSet timetableSet, DataGridViewCell data)
        {

            InitializeComponent();
            this.conn = conn;
            this.type = type;
            this.timetableSet = timetableSet;
            this.data = data;
            typeList = SqlAssistant.SelectOne($"SELECT pg_enum.enumlabel AS enumlabel FROM pg_type JOIN pg_enum ON pg_enum.enumtypid = pg_type.oid WHERE pg_type.typname = '{type}';", conn);
            dataGridViewTable.Columns.Add("type", "выбор");
            for (int i = 0; i < typeList.Count; i++)
            {
                dataGridViewTable.Rows.Add(typeList[i]);
            }

        }

        private void dataGridViewTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                int pos = dataGridViewTable.Columns["type"].Index;// Ищем позицию id
                if (pos > -1)
                {
                    if (textBox != null)
                    {
                        textBox.Text = dataGridViewTable.Rows[e.RowIndex].Cells[pos].Value.ToString();
                    }
                    else if (data != null)
                    {
                        data.Value = dataGridViewTable.Rows[e.RowIndex].Cells[pos].Value;
                    }
                    //timetableSet.Test = dataGridViewTable.Rows[e.RowIndex].Cells[pos].Value.ToString();
                    Visible = false;
                    Dispose();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridViewTable.Rows.Clear();
            typeList = SqlAssistant.SelectOne($"SELECT pg_enum.enumlabel AS enumlabel FROM pg_type JOIN pg_enum ON pg_enum.enumtypid = pg_type.oid WHERE pg_type.typname = '{type}' AND enumlabel ~* '{txtSearch.Text}';", conn);
            for (int i = 0; i < typeList.Count; i++)
            {
                dataGridViewTable.Rows.Add(typeList[i]);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Visible = false;
            Dispose();
        }
    }
}
