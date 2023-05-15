namespace Timetable.Forms
{
    partial class TimetableSet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelTitle = new Panel();
            btnSettings = new Button();
            label3 = new Label();
            button1 = new Button();
            txtSemester = new TextBox();
            btnUpdate = new Button();
            btnGen = new Button();
            label1 = new Label();
            txtGroup = new TextBox();
            panelMain = new Panel();
            GenSettings = new Panel();
            txtPopulation = new TextBox();
            label9 = new Label();
            label8 = new Label();
            txtTeacherWindow = new TextBox();
            label7 = new Label();
            txtGroupWindow = new TextBox();
            label6 = new Label();
            txtMoreFourLesson = new TextBox();
            label5 = new Label();
            txtOneLesson = new TextBox();
            label4 = new Label();
            txtIterations = new TextBox();
            label2 = new Label();
            panel2 = new Panel();
            btnClose = new Button();
            dataGridViewTable = new DataGridView();
            panelTitle.SuspendLayout();
            panelMain.SuspendLayout();
            GenSettings.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTable).BeginInit();
            SuspendLayout();
            // 
            // panelTitle
            // 
            panelTitle.BackColor = Color.FromArgb(168, 176, 181);
            panelTitle.Controls.Add(btnSettings);
            panelTitle.Controls.Add(label3);
            panelTitle.Controls.Add(button1);
            panelTitle.Controls.Add(txtSemester);
            panelTitle.Controls.Add(btnUpdate);
            panelTitle.Controls.Add(btnGen);
            panelTitle.Controls.Add(label1);
            panelTitle.Controls.Add(txtGroup);
            panelTitle.Dock = DockStyle.Top;
            panelTitle.Location = new Point(0, 0);
            panelTitle.Name = "panelTitle";
            panelTitle.Size = new Size(1179, 94);
            panelTitle.TabIndex = 0;
            // 
            // btnSettings
            // 
            btnSettings.Location = new Point(863, 17);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(192, 29);
            btnSettings.TabIndex = 9;
            btnSettings.Text = "Настройки генерации";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(338, 20);
            label3.Name = "label3";
            label3.Size = new Size(67, 20);
            label3.TabIndex = 8;
            label3.Text = "Семестр";
            // 
            // button1
            // 
            button1.Location = new Point(3, 59);
            button1.Name = "button1";
            button1.Size = new Size(206, 29);
            button1.TabIndex = 2;
            button1.Text = "Добавить занятие";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtSemester
            // 
            txtSemester.Location = new Point(411, 17);
            txtSemester.Name = "txtSemester";
            txtSemester.Size = new Size(180, 27);
            txtSemester.TabIndex = 5;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(237, 59);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(200, 29);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "Обновить";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnGen
            // 
            btnGen.Location = new Point(607, 17);
            btnGen.Name = "btnGen";
            btnGen.Size = new Size(241, 29);
            btnGen.TabIndex = 3;
            btnGen.Text = "Составить расписание";
            btnGen.UseVisualStyleBackColor = true;
            btnGen.Click += btnGen_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(130, 20);
            label1.TabIndex = 1;
            label1.Text = "Выбирите группу";
            // 
            // txtGroup
            // 
            txtGroup.Location = new Point(152, 17);
            txtGroup.Name = "txtGroup";
            txtGroup.Size = new Size(180, 27);
            txtGroup.TabIndex = 0;
            txtGroup.MouseDoubleClick += txtGroup_MouseDoubleClick;
            // 
            // panelMain
            // 
            panelMain.BackColor = SystemColors.ControlDark;
            panelMain.Controls.Add(GenSettings);
            panelMain.Controls.Add(dataGridViewTable);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 94);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1179, 445);
            panelMain.TabIndex = 1;
            // 
            // GenSettings
            // 
            GenSettings.BackColor = Color.FromArgb(178, 186, 191);
            GenSettings.Controls.Add(txtPopulation);
            GenSettings.Controls.Add(label9);
            GenSettings.Controls.Add(label8);
            GenSettings.Controls.Add(txtTeacherWindow);
            GenSettings.Controls.Add(label7);
            GenSettings.Controls.Add(txtGroupWindow);
            GenSettings.Controls.Add(label6);
            GenSettings.Controls.Add(txtMoreFourLesson);
            GenSettings.Controls.Add(label5);
            GenSettings.Controls.Add(txtOneLesson);
            GenSettings.Controls.Add(label4);
            GenSettings.Controls.Add(txtIterations);
            GenSettings.Controls.Add(label2);
            GenSettings.Controls.Add(panel2);
            GenSettings.Location = new Point(660, 48);
            GenSettings.Name = "GenSettings";
            GenSettings.Size = new Size(291, 275);
            GenSettings.TabIndex = 2;
            GenSettings.Visible = false;
            // 
            // txtPopulation
            // 
            txtPopulation.Location = new Point(103, 72);
            txtPopulation.MaxLength = 9;
            txtPopulation.Name = "txtPopulation";
            txtPopulation.Size = new Size(80, 27);
            txtPopulation.TabIndex = 14;
            txtPopulation.Text = "400";
            txtPopulation.TextChanged += txtIntCheck_TextChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(10, 76);
            label9.Name = "label9";
            label9.Size = new Size(88, 20);
            label9.TabIndex = 13;
            label9.Text = "Популяций";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 237);
            label8.Name = "label8";
            label8.Size = new Size(185, 20);
            label8.TabIndex = 12;
            label8.Text = "За окно у преподователя";
            // 
            // txtTeacherWindow
            // 
            txtTeacherWindow.Location = new Point(198, 230);
            txtTeacherWindow.MaxLength = 9;
            txtTeacherWindow.Name = "txtTeacherWindow";
            txtTeacherWindow.Size = new Size(80, 27);
            txtTeacherWindow.TabIndex = 11;
            txtTeacherWindow.Text = "7";
            txtTeacherWindow.TextChanged += txtIntCheck_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(10, 201);
            label7.Name = "label7";
            label7.Size = new Size(129, 20);
            label7.TabIndex = 10;
            label7.Text = "За окно у группы";
            // 
            // txtGroupWindow
            // 
            txtGroupWindow.Location = new Point(145, 198);
            txtGroupWindow.MaxLength = 9;
            txtGroupWindow.Name = "txtGroupWindow";
            txtGroupWindow.Size = new Size(80, 27);
            txtGroupWindow.TabIndex = 9;
            txtGroupWindow.Text = "10";
            txtGroupWindow.TextChanged += txtIntCheck_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(10, 165);
            label6.Name = "label6";
            label6.Size = new Size(185, 20);
            label6.TabIndex = 8;
            label6.Text = "За больше 4 пары в день";
            // 
            // txtMoreFourLesson
            // 
            txtMoreFourLesson.Location = new Point(198, 160);
            txtMoreFourLesson.MaxLength = 9;
            txtMoreFourLesson.Name = "txtMoreFourLesson";
            txtMoreFourLesson.Size = new Size(80, 27);
            txtMoreFourLesson.TabIndex = 7;
            txtMoreFourLesson.Text = "40";
            txtMoreFourLesson.TextChanged += txtIntCheck_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 130);
            label5.Name = "label5";
            label5.Size = new Size(99, 20);
            label5.TabIndex = 6;
            label5.Text = "За одну пару";
            // 
            // txtOneLesson
            // 
            txtOneLesson.Location = new Point(115, 127);
            txtOneLesson.MaxLength = 9;
            txtOneLesson.Name = "txtOneLesson";
            txtOneLesson.Size = new Size(80, 27);
            txtOneLesson.TabIndex = 5;
            txtOneLesson.Text = "40";
            txtOneLesson.TextChanged += txtIntCheck_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 106);
            label4.Name = "label4";
            label4.Size = new Size(70, 20);
            label4.TabIndex = 4;
            label4.Text = "Штрафы:";
            // 
            // txtIterations
            // 
            txtIterations.Location = new Point(103, 34);
            txtIterations.MaxLength = 9;
            txtIterations.Name = "txtIterations";
            txtIterations.Size = new Size(80, 27);
            txtIterations.TabIndex = 3;
            txtIterations.Text = "100";
            txtIterations.TextChanged += txtIntCheck_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 41);
            label2.Name = "label2";
            label2.Size = new Size(78, 20);
            label2.TabIndex = 2;
            label2.Text = "Итераций";
            // 
            // panel2
            // 
            panel2.Controls.Add(btnClose);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(291, 31);
            panel2.TabIndex = 1;
            // 
            // btnClose
            // 
            btnClose.Dock = DockStyle.Right;
            btnClose.Location = new Point(252, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(39, 31);
            btnClose.TabIndex = 0;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // dataGridViewTable
            // 
            dataGridViewTable.AllowUserToAddRows = false;
            dataGridViewTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewTable.BackgroundColor = Color.FromArgb(168, 176, 181);
            dataGridViewTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTable.Dock = DockStyle.Fill;
            dataGridViewTable.Location = new Point(0, 0);
            dataGridViewTable.Name = "dataGridViewTable";
            dataGridViewTable.RowHeadersWidth = 51;
            dataGridViewTable.RowTemplate.Height = 29;
            dataGridViewTable.Size = new Size(1179, 445);
            dataGridViewTable.TabIndex = 1;
            dataGridViewTable.CellMouseDoubleClick += dataGridViewTable_CellMouseDoubleClick;
            dataGridViewTable.CellValueChanged += dataGridViewTable_CellValueChanged;
            dataGridViewTable.UserDeletedRow += dataGridViewTable_UserDeletedRow;
            // 
            // TimetableSet
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1179, 539);
            Controls.Add(panelMain);
            Controls.Add(panelTitle);
            Name = "TimetableSet";
            Text = "TimetableSet";
            panelTitle.ResumeLayout(false);
            panelTitle.PerformLayout();
            panelMain.ResumeLayout(false);
            GenSettings.ResumeLayout(false);
            GenSettings.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewTable).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTitle;
        private Button button1;
        private Label label1;
        private TextBox txtGroup;
        private Panel panelMain;
        private DataGridView dataGridViewTable;
        private Button btnGen;
        private Button btnUpdate;
        private Label label3;
        private TextBox txtSemester;
        private Button btnSettings;
        private Panel GenSettings;
        private Label label8;
        private TextBox txtTeacherWindow;
        private Label label7;
        private TextBox txtGroupWindow;
        private Label label6;
        private TextBox txtMoreFourLesson;
        private Label label5;
        private TextBox txtOneLesson;
        private Label label4;
        private TextBox txtIterations;
        private Label label2;
        private Panel panel2;
        private Button btnClose;
        private TextBox txtPopulation;
        private Label label9;
    }
}