namespace Timetable.Controls
{
    partial class SelectControl
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
            txtSearch = new TextBox();
            dataGridViewTable = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTable).BeginInit();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.Dock = DockStyle.Right;
            btnClose.Location = new Point(1033, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(39, 30);
            btnClose.TabIndex = 2;
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
            panel1.Size = new Size(1072, 30);
            panel1.TabIndex = 3;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Top;
            txtSearch.Location = new Point(0, 30);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(1072, 27);
            txtSearch.TabIndex = 4;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // dataGridViewTable
            // 
            dataGridViewTable.AllowUserToAddRows = false;
            dataGridViewTable.AllowUserToDeleteRows = false;
            dataGridViewTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewTable.BackgroundColor = Color.FromArgb(178, 186, 191);
            dataGridViewTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTable.Dock = DockStyle.Fill;
            dataGridViewTable.Location = new Point(0, 57);
            dataGridViewTable.Name = "dataGridViewTable";
            dataGridViewTable.ReadOnly = true;
            dataGridViewTable.RowHeadersWidth = 51;
            dataGridViewTable.RowTemplate.Height = 29;
            dataGridViewTable.Size = new Size(1072, 474);
            dataGridViewTable.TabIndex = 5;
            dataGridViewTable.CellMouseDoubleClick += dataGridViewTable_CellMouseDoubleClick;
            // 
            // SelectControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridViewTable);
            Controls.Add(txtSearch);
            Controls.Add(panel1);
            Name = "SelectControl";
            Size = new Size(1072, 531);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridViewTable;
        private Button btnClose;
        private Panel panel1;
        private TextBox txtSearch;
    }
}
