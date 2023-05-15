namespace Timetable.Controls
{
    partial class SelectOneControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            btnClose = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            dataGridViewTable = new DataGridView();
            txtSearch = new TextBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTable).BeginInit();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.Dock = DockStyle.Right;
            btnClose.Location = new Point(238, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(39, 30);
            btnClose.TabIndex = 6;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(178, 186, 191);
            panel1.Controls.Add(btnClose);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(277, 30);
            panel1.TabIndex = 7;
            // 
            // panel2
            // 
            panel2.Controls.Add(dataGridViewTable);
            panel2.Controls.Add(txtSearch);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 30);
            panel2.Name = "panel2";
            panel2.Size = new Size(277, 450);
            panel2.TabIndex = 8;
            // 
            // dataGridViewTable
            // 
            dataGridViewTable.AllowUserToAddRows = false;
            dataGridViewTable.AllowUserToDeleteRows = false;
            dataGridViewTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewTable.BackgroundColor = Color.FromArgb(178, 186, 191);
            dataGridViewTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTable.Dock = DockStyle.Fill;
            dataGridViewTable.Location = new Point(0, 27);
            dataGridViewTable.Name = "dataGridViewTable";
            dataGridViewTable.ReadOnly = true;
            dataGridViewTable.RightToLeft = RightToLeft.No;
            dataGridViewTable.RowHeadersVisible = false;
            dataGridViewTable.RowHeadersWidth = 51;
            dataGridViewTable.RowTemplate.Height = 29;
            dataGridViewTable.Size = new Size(277, 423);
            dataGridViewTable.TabIndex = 7;
            dataGridViewTable.CellMouseDoubleClick += dataGridViewTable_CellMouseDoubleClick;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Top;
            txtSearch.Location = new Point(0, 0);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(277, 27);
            txtSearch.TabIndex = 6;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // SelectOneControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "SelectOneControl";
            Size = new Size(277, 480);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTable).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnClose;
        private Panel panel1;
        private Panel panel2;
        private DataGridView dataGridViewTable;
        private TextBox txtSearch;
    }
}
