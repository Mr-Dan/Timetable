namespace Timetable.Controls
{
    partial class HeadDepartmentControl
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
            label2 = new Label();
            btnInsert = new Button();
            txtDepartments = new TextBox();
            txtTeacher = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 45);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 0;
            label1.Text = "Кафедра";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 88);
            label2.Name = "label2";
            label2.Size = new Size(118, 20);
            label2.TabIndex = 1;
            label2.Text = "Преподователь";
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(109, 140);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(94, 29);
            btnInsert.TabIndex = 2;
            btnInsert.Text = "Добавить";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // txtDepartments
            // 
            txtDepartments.Location = new Point(183, 43);
            txtDepartments.Name = "txtDepartments";
            txtDepartments.Size = new Size(125, 27);
            txtDepartments.TabIndex = 3;
            txtDepartments.MouseDoubleClick += txtDepartments_MouseDoubleClick;
            // 
            // txtTeacher
            // 
            txtTeacher.Location = new Point(183, 81);
            txtTeacher.Name = "txtTeacher";
            txtTeacher.Size = new Size(125, 27);
            txtTeacher.TabIndex = 4;
            txtTeacher.MouseDoubleClick += txtTeacher_MouseDoubleClick;
            // 
            // HeadDepartmentControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtTeacher);
            Controls.Add(txtDepartments);
            Controls.Add(btnInsert);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "HeadDepartmentControl";
            Size = new Size(378, 312);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button btnInsert;
        private TextBox txtDepartments;
        private TextBox txtTeacher;
    }
}
