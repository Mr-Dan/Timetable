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
            this.dataGridViewTable = new System.Windows.Forms.DataGridView();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.groupsButton = new System.Windows.Forms.Button();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.audienceFundButton = new System.Windows.Forms.Button();
            this.teacherButton = new System.Windows.Forms.Button();
            this.groupTableButton = new System.Windows.Forms.Button();
            this.facultyButton = new System.Windows.Forms.Button();
            this.disciplineButton = new System.Windows.Forms.Button();
            this.departmentsButton = new System.Windows.Forms.Button();
            this.timetableButton = new System.Windows.Forms.Button();
            this.audienceButton = new System.Windows.Forms.Button();
            this.insertPanel = new System.Windows.Forms.Panel();
            this.buttonPanelClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTable)).BeginInit();
            this.panelTitle.SuspendLayout();
            this.insertPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewTable
            // 
            this.dataGridViewTable.AllowUserToAddRows = false;
            this.dataGridViewTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTable.Location = new System.Drawing.Point(0, 80);
            this.dataGridViewTable.Name = "dataGridViewTable";
            this.dataGridViewTable.RowHeadersWidth = 51;
            this.dataGridViewTable.RowTemplate.Height = 29;
            this.dataGridViewTable.Size = new System.Drawing.Size(1708, 516);
            this.dataGridViewTable.TabIndex = 1;
            this.dataGridViewTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTable_CellEndEdit);
            this.dataGridViewTable.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridViewTable_UserDeletedRow);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(930, 46);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(134, 29);
            this.buttonUpdate.TabIndex = 2;
            this.buttonUpdate.Text = "Обновить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelTitle.Controls.Add(this.buttonInsert);
            this.panelTitle.Controls.Add(this.buttonUpdate);
            this.panelTitle.Controls.Add(this.groupsButton);
            this.panelTitle.Controls.Add(this.SearchTextBox);
            this.panelTitle.Controls.Add(this.audienceFundButton);
            this.panelTitle.Controls.Add(this.teacherButton);
            this.panelTitle.Controls.Add(this.groupTableButton);
            this.panelTitle.Controls.Add(this.facultyButton);
            this.panelTitle.Controls.Add(this.disciplineButton);
            this.panelTitle.Controls.Add(this.departmentsButton);
            this.panelTitle.Controls.Add(this.timetableButton);
            this.panelTitle.Controls.Add(this.audienceButton);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(1711, 80);
            this.panelTitle.TabIndex = 3;
            // 
            // buttonInsert
            // 
            this.buttonInsert.Location = new System.Drawing.Point(781, 45);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(134, 29);
            this.buttonInsert.TabIndex = 5;
            this.buttonInsert.Text = "Добавить";
            this.buttonInsert.UseVisualStyleBackColor = true;
            this.buttonInsert.Click += new System.EventHandler(this.buttonInsert_Click);
            // 
            // groupsButton
            // 
            this.groupsButton.Location = new System.Drawing.Point(970, 7);
            this.groupsButton.Name = "groupsButton";
            this.groupsButton.Size = new System.Drawing.Size(159, 29);
            this.groupsButton.TabIndex = 8;
            this.groupsButton.Text = "Группы/Потоки";
            this.groupsButton.UseVisualStyleBackColor = true;
            this.groupsButton.Click += new System.EventHandler(this.groupsButton_Click);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(3, 46);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(630, 27);
            this.SearchTextBox.TabIndex = 4;
            this.SearchTextBox.Text = "Поиск";
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // audienceFundButton
            // 
            this.audienceFundButton.Location = new System.Drawing.Point(781, 7);
            this.audienceFundButton.Name = "audienceFundButton";
            this.audienceFundButton.Size = new System.Drawing.Size(183, 29);
            this.audienceFundButton.TabIndex = 7;
            this.audienceFundButton.Text = "Аудиторный фонд";
            this.audienceFundButton.UseVisualStyleBackColor = true;
            this.audienceFundButton.Click += new System.EventHandler(this.audienceFundButton_Click);
            // 
            // teacherButton
            // 
            this.teacherButton.Location = new System.Drawing.Point(639, 7);
            this.teacherButton.Name = "teacherButton";
            this.teacherButton.Size = new System.Drawing.Size(136, 29);
            this.teacherButton.TabIndex = 6;
            this.teacherButton.Text = "Преподователи";
            this.teacherButton.UseVisualStyleBackColor = true;
            this.teacherButton.Click += new System.EventHandler(this.teacherButton_Click);
            // 
            // groupTableButton
            // 
            this.groupTableButton.Location = new System.Drawing.Point(539, 7);
            this.groupTableButton.Name = "groupTableButton";
            this.groupTableButton.Size = new System.Drawing.Size(94, 29);
            this.groupTableButton.TabIndex = 5;
            this.groupTableButton.Text = "Группы";
            this.groupTableButton.UseVisualStyleBackColor = true;
            this.groupTableButton.Click += new System.EventHandler(this.groupTableButton_Click);
            // 
            // facultyButton
            // 
            this.facultyButton.Location = new System.Drawing.Point(439, 7);
            this.facultyButton.Name = "facultyButton";
            this.facultyButton.Size = new System.Drawing.Size(94, 29);
            this.facultyButton.TabIndex = 4;
            this.facultyButton.Text = "Факультет";
            this.facultyButton.UseVisualStyleBackColor = true;
            this.facultyButton.Click += new System.EventHandler(this.facultyButton_Click);
            // 
            // disciplineButton
            // 
            this.disciplineButton.Location = new System.Drawing.Point(325, 7);
            this.disciplineButton.Name = "disciplineButton";
            this.disciplineButton.Size = new System.Drawing.Size(108, 29);
            this.disciplineButton.TabIndex = 3;
            this.disciplineButton.Text = "Десциплина";
            this.disciplineButton.UseVisualStyleBackColor = true;
            this.disciplineButton.Click += new System.EventHandler(this.disciplineButton_Click);
            // 
            // departmentsButton
            // 
            this.departmentsButton.Location = new System.Drawing.Point(225, 6);
            this.departmentsButton.Name = "departmentsButton";
            this.departmentsButton.Size = new System.Drawing.Size(94, 29);
            this.departmentsButton.TabIndex = 2;
            this.departmentsButton.Text = "Кафедра";
            this.departmentsButton.UseVisualStyleBackColor = true;
            this.departmentsButton.Click += new System.EventHandler(this.departmentsButton_Click);
            // 
            // timetableButton
            // 
            this.timetableButton.Location = new System.Drawing.Point(107, 6);
            this.timetableButton.Name = "timetableButton";
            this.timetableButton.Size = new System.Drawing.Size(112, 29);
            this.timetableButton.TabIndex = 1;
            this.timetableButton.Text = "Расписание";
            this.timetableButton.UseVisualStyleBackColor = true;
            this.timetableButton.Click += new System.EventHandler(this.timetableButton_Click);
            // 
            // audienceButton
            // 
            this.audienceButton.Location = new System.Drawing.Point(7, 6);
            this.audienceButton.Name = "audienceButton";
            this.audienceButton.Size = new System.Drawing.Size(94, 29);
            this.audienceButton.TabIndex = 0;
            this.audienceButton.Text = "Аудитории";
            this.audienceButton.UseVisualStyleBackColor = true;
            this.audienceButton.Click += new System.EventHandler(this.audienceButton_Click);
            // 
            // insertPanel
            // 
            this.insertPanel.Controls.Add(this.panel1);
            this.insertPanel.Location = new System.Drawing.Point(598, 192);
            this.insertPanel.Name = "insertPanel";
            this.insertPanel.Size = new System.Drawing.Size(250, 274);
            this.insertPanel.TabIndex = 4;
            this.insertPanel.Visible = false;
            // 
            // buttonPanelClose
            // 
            this.buttonPanelClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonPanelClose.Location = new System.Drawing.Point(215, 0);
            this.buttonPanelClose.Name = "buttonPanelClose";
            this.buttonPanelClose.Size = new System.Drawing.Size(35, 32);
            this.buttonPanelClose.TabIndex = 0;
            this.buttonPanelClose.Text = "X";
            this.buttonPanelClose.UseVisualStyleBackColor = true;
            this.buttonPanelClose.Click += new System.EventHandler(this.buttonPanelClose_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonPanelClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 32);
            this.panel1.TabIndex = 1;
            // 
            // DBForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1711, 522);
            this.Controls.Add(this.insertPanel);
            this.Controls.Add(this.panelTitle);
            this.Controls.Add(this.dataGridViewTable);
            this.Name = "DBForm";
            this.Text = "DBForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTable)).EndInit();
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.insertPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion     
        private Button buttonUpdate;
        private Panel panelTitle;
        private DataGridView dataGridViewTable;
        private TextBox SearchTextBox;
        private Button buttonInsert;
        private Button disciplineButton;
        private Button departmentsButton;
        private Button timetableButton;
        private Button audienceButton;
        private Button groupsButton;
        private Button audienceFundButton;
        private Button teacherButton;
        private Button groupTableButton;
        private Button facultyButton;
        private Panel insertPanel;
        private Button buttonPanelClose;
        private Panel panel1;
    }
}