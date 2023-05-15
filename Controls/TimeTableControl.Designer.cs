namespace Timetable.Controls
{
    partial class TimeTableControl
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
            label1 = new Label();
            txtGroups = new TextBox();
            txtTeacher = new TextBox();
            label2 = new Label();
            txtDiscipline = new TextBox();
            label3 = new Label();
            btnClose = new Button();
            btnInsert = new Button();
            txtPeriodicity = new TextBox();
            label7 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 44);
            label1.Name = "label1";
            label1.Size = new Size(106, 20);
            label1.TabIndex = 0;
            label1.Text = "Группа/Поток";
            // 
            // txtGroups
            // 
            txtGroups.Location = new Point(161, 41);
            txtGroups.Name = "txtGroups";
            txtGroups.Size = new Size(125, 27);
            txtGroups.TabIndex = 1;
            txtGroups.MouseDoubleClick += txtGroups_MouseDoubleClick;
            // 
            // txtTeacher
            // 
            txtTeacher.Location = new Point(161, 87);
            txtTeacher.Name = "txtTeacher";
            txtTeacher.Size = new Size(125, 27);
            txtTeacher.TabIndex = 3;
            txtTeacher.MouseDoubleClick += txtTeacher_MouseDoubleClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 90);
            label2.Name = "label2";
            label2.Size = new Size(117, 20);
            label2.TabIndex = 2;
            label2.Text = "Преподаватель";
            // 
            // txtDiscipline
            // 
            txtDiscipline.Location = new Point(161, 134);
            txtDiscipline.Name = "txtDiscipline";
            txtDiscipline.Size = new Size(125, 27);
            txtDiscipline.TabIndex = 5;
            txtDiscipline.MouseDoubleClick += txtDiscipline_MouseDoubleClick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(35, 137);
            label3.Name = "label3";
            label3.Size = new Size(96, 20);
            label3.TabIndex = 4;
            label3.Text = "Дисциплина";
            // 
            // btnClose
            // 
            btnClose.Location = new Point(311, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(35, 29);
            btnClose.TabIndex = 12;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(107, 217);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(94, 29);
            btnInsert.TabIndex = 13;
            btnInsert.Text = "Добавить";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // txtPeriodicity
            // 
            txtPeriodicity.Location = new Point(161, 175);
            txtPeriodicity.Name = "txtPeriodicity";
            txtPeriodicity.Size = new Size(125, 27);
            txtPeriodicity.TabIndex = 15;
            txtPeriodicity.MouseDoubleClick += txtPeriodicity_MouseDoubleClick;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(35, 178);
            label7.Name = "label7";
            label7.Size = new Size(119, 20);
            label7.TabIndex = 14;
            label7.Text = "Периодичность";
            // 
            // TimeTableControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtPeriodicity);
            Controls.Add(label7);
            Controls.Add(btnInsert);
            Controls.Add(btnClose);
            Controls.Add(txtDiscipline);
            Controls.Add(label3);
            Controls.Add(txtTeacher);
            Controls.Add(label2);
            Controls.Add(txtGroups);
            Controls.Add(label1);
            Name = "TimeTableControl";
            Size = new Size(349, 263);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtGroups;
        private TextBox txtTeacher;
        private Label label2;
        private TextBox txtDiscipline;
        private Label label3;
        private TextBox txtWeekday;
        private Label label4;
        private TextBox txtClasstime;
        private Label label5;
        private TextBox txtAudience;
        private Label label6;
        private Button btnClose;
        private Button btnInsert;
        private TextBox txtPeriodicity;
        private Label label7;
    }
}
