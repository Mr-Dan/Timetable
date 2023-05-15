namespace Timetable.Forms
{
    partial class DBForm
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
            buttonUpdate = new Button();
            panelTitle = new Panel();
            headDepartmentButton = new Button();
            curriculumDisciplineButton = new Button();
            curriculumButton = new Button();
            buttonInsert = new Button();
            groupsButton = new Button();
            SearchTextBox = new TextBox();
            audienceFundButton = new Button();
            teacherButton = new Button();
            groupTableButton = new Button();
            facultyButton = new Button();
            disciplineButton = new Button();
            departmentsButton = new Button();
            audienceButton = new Button();
            insertPanel = new Panel();
            panel2 = new Panel();
            panel1 = new Panel();
            buttonPanelClose = new Button();
            dataGridViewTable = new DataGridView();
            panelTitle.SuspendLayout();
            insertPanel.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTable).BeginInit();
            SuspendLayout();
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(782, 44);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(130, 30);
            buttonUpdate.TabIndex = 2;
            buttonUpdate.Text = "Обновить";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // panelTitle
            // 
            panelTitle.BackColor = Color.FromArgb(168, 176, 181);
            panelTitle.Controls.Add(headDepartmentButton);
            panelTitle.Controls.Add(curriculumDisciplineButton);
            panelTitle.Controls.Add(curriculumButton);
            panelTitle.Controls.Add(buttonInsert);
            panelTitle.Controls.Add(buttonUpdate);
            panelTitle.Controls.Add(groupsButton);
            panelTitle.Controls.Add(SearchTextBox);
            panelTitle.Controls.Add(audienceFundButton);
            panelTitle.Controls.Add(teacherButton);
            panelTitle.Controls.Add(groupTableButton);
            panelTitle.Controls.Add(facultyButton);
            panelTitle.Controls.Add(disciplineButton);
            panelTitle.Controls.Add(departmentsButton);
            panelTitle.Controls.Add(audienceButton);
            panelTitle.Dock = DockStyle.Top;
            panelTitle.Location = new Point(0, 0);
            panelTitle.Name = "panelTitle";
            panelTitle.Size = new Size(1711, 82);
            panelTitle.TabIndex = 3;
            // 
            // headDepartmentButton
            // 
            headDepartmentButton.Location = new Point(222, 12);
            headDepartmentButton.Name = "headDepartmentButton";
            headDepartmentButton.Size = new Size(120, 30);
            headDepartmentButton.TabIndex = 11;
            headDepartmentButton.Text = "Зав кафедр";
            headDepartmentButton.UseVisualStyleBackColor = true;
            headDepartmentButton.Click += headDepartmentButton_Click;
            // 
            // curriculumDisciplineButton
            // 
            curriculumDisciplineButton.Location = new Point(1270, 12);
            curriculumDisciplineButton.Name = "curriculumDisciplineButton";
            curriculumDisciplineButton.Size = new Size(220, 30);
            curriculumDisciplineButton.TabIndex = 10;
            curriculumDisciplineButton.Text = "Учебный план дисциплин";
            curriculumDisciplineButton.UseVisualStyleBackColor = true;
            curriculumDisciplineButton.Click += curriculumDisciplineButton_Click;
            // 
            // curriculumButton
            // 
            curriculumButton.Location = new Point(1114, 12);
            curriculumButton.Name = "curriculumButton";
            curriculumButton.Size = new Size(150, 30);
            curriculumButton.TabIndex = 9;
            curriculumButton.Text = "Учебный план";
            curriculumButton.UseVisualStyleBackColor = true;
            curriculumButton.Click += curriculumButton_Click;
            // 
            // buttonInsert
            // 
            buttonInsert.Location = new Point(646, 44);
            buttonInsert.Name = "buttonInsert";
            buttonInsert.Size = new Size(130, 30);
            buttonInsert.TabIndex = 5;
            buttonInsert.Text = "Добавить";
            buttonInsert.UseVisualStyleBackColor = true;
            buttonInsert.Click += buttonInsert_Click;
            // 
            // groupsButton
            // 
            groupsButton.Location = new Point(968, 12);
            groupsButton.Name = "groupsButton";
            groupsButton.Size = new Size(140, 30);
            groupsButton.TabIndex = 8;
            groupsButton.Text = "Группы/Потоки";
            groupsButton.UseVisualStyleBackColor = true;
            groupsButton.Click += groupsButton_Click;
            // 
            // SearchTextBox
            // 
            SearchTextBox.Location = new Point(10, 46);
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.Size = new Size(630, 27);
            SearchTextBox.TabIndex = 4;
            SearchTextBox.Text = "Поиск";
            SearchTextBox.TextChanged += SearchTextBox_TextChanged;
            // 
            // audienceFundButton
            // 
            audienceFundButton.Location = new Point(802, 12);
            audienceFundButton.Name = "audienceFundButton";
            audienceFundButton.Size = new Size(160, 30);
            audienceFundButton.TabIndex = 7;
            audienceFundButton.Text = "Аудиторный фонд";
            audienceFundButton.UseVisualStyleBackColor = true;
            audienceFundButton.Click += audienceFundButton_Click;
            // 
            // teacherButton
            // 
            teacherButton.Location = new Point(666, 12);
            teacherButton.Name = "teacherButton";
            teacherButton.Size = new Size(130, 30);
            teacherButton.TabIndex = 6;
            teacherButton.Text = "Преподователи";
            teacherButton.UseVisualStyleBackColor = true;
            teacherButton.Click += teacherButton_Click;
            // 
            // groupTableButton
            // 
            groupTableButton.Location = new Point(560, 12);
            groupTableButton.Name = "groupTableButton";
            groupTableButton.Size = new Size(100, 30);
            groupTableButton.TabIndex = 5;
            groupTableButton.Text = "Группы";
            groupTableButton.UseVisualStyleBackColor = true;
            groupTableButton.Click += groupTableButton_Click;
            // 
            // facultyButton
            // 
            facultyButton.Location = new Point(454, 12);
            facultyButton.Name = "facultyButton";
            facultyButton.Size = new Size(100, 30);
            facultyButton.TabIndex = 4;
            facultyButton.Text = "Факультет";
            facultyButton.UseVisualStyleBackColor = true;
            facultyButton.Click += facultyButton_Click;
            // 
            // disciplineButton
            // 
            disciplineButton.Location = new Point(348, 12);
            disciplineButton.Name = "disciplineButton";
            disciplineButton.Size = new Size(100, 30);
            disciplineButton.TabIndex = 3;
            disciplineButton.Text = "Десциплина";
            disciplineButton.UseVisualStyleBackColor = true;
            disciplineButton.Click += disciplineButton_Click;
            // 
            // departmentsButton
            // 
            departmentsButton.Location = new Point(116, 12);
            departmentsButton.Name = "departmentsButton";
            departmentsButton.Size = new Size(100, 30);
            departmentsButton.TabIndex = 2;
            departmentsButton.Text = "Кафедра";
            departmentsButton.UseVisualStyleBackColor = true;
            departmentsButton.Click += departmentsButton_Click;
            // 
            // audienceButton
            // 
            audienceButton.Location = new Point(10, 10);
            audienceButton.Name = "audienceButton";
            audienceButton.Size = new Size(100, 30);
            audienceButton.TabIndex = 0;
            audienceButton.Text = "Аудитории";
            audienceButton.UseVisualStyleBackColor = true;
            audienceButton.Click += audienceButton_Click;
            // 
            // insertPanel
            // 
            insertPanel.Controls.Add(panel2);
            insertPanel.Controls.Add(panel1);
            insertPanel.Location = new Point(55, 133);
            insertPanel.Name = "insertPanel";
            insertPanel.Size = new Size(250, 274);
            insertPanel.TabIndex = 4;
            insertPanel.Visible = false;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 33);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 241);
            panel2.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonPanelClose);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 33);
            panel1.TabIndex = 1;
            // 
            // buttonPanelClose
            // 
            buttonPanelClose.Dock = DockStyle.Right;
            buttonPanelClose.Location = new Point(215, 0);
            buttonPanelClose.Name = "buttonPanelClose";
            buttonPanelClose.Size = new Size(35, 33);
            buttonPanelClose.TabIndex = 0;
            buttonPanelClose.Text = "X";
            buttonPanelClose.UseVisualStyleBackColor = true;
            buttonPanelClose.Click += buttonPanelClose_Click;
            // 
            // dataGridViewTable
            // 
            dataGridViewTable.AllowUserToAddRows = false;
            dataGridViewTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewTable.BackgroundColor = Color.FromArgb(168, 176, 181);
            dataGridViewTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTable.Dock = DockStyle.Fill;
            dataGridViewTable.Location = new Point(0, 82);
            dataGridViewTable.Name = "dataGridViewTable";
            dataGridViewTable.RowHeadersWidth = 51;
            dataGridViewTable.RowTemplate.Height = 29;
            dataGridViewTable.Size = new Size(1711, 542);
            dataGridViewTable.TabIndex = 5;
            dataGridViewTable.CellMouseDoubleClick += dataGridViewTable_CellMouseDoubleClick;
            dataGridViewTable.CellValueChanged += dataGridViewTable_CellValueChanged;
            dataGridViewTable.UserDeletedRow += dataGridViewTable_UserDeletedRow;
            // 
            // DBForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1711, 624);
            Controls.Add(dataGridViewTable);
            Controls.Add(insertPanel);
            Controls.Add(panelTitle);
            Name = "DBForm";
            Text = "DBForm";
            panelTitle.ResumeLayout(false);
            panelTitle.PerformLayout();
            insertPanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewTable).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button buttonUpdate;
        private Panel panelTitle;
        private TextBox SearchTextBox;
        private Button buttonInsert;
        private Button disciplineButton;
        private Button departmentsButton;
        private Button audienceButton;
        private Button groupsButton;
        private Button audienceFundButton;
        private Button teacherButton;
        private Button groupTableButton;
        private Button facultyButton;
        private Panel insertPanel;
        private Button buttonPanelClose;
        private Panel panel1;
        private Panel panel2;
        private Button curriculumDisciplineButton;
        private Button curriculumButton;
        private Button headDepartmentButton;
        private DataGridView dataGridViewTable;
    }
}