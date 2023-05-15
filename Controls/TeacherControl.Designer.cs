namespace Timetable.Controls
{
    partial class TeacherControl
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
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtLastName = new TextBox();
            txtName = new TextBox();
            txtPosition = new TextBox();
            txtPatronymic = new TextBox();
            label6 = new Label();
            txtAcademicDegree = new TextBox();
            btnInsert = new Button();
            cmbBoxDepartments = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 28);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 0;
            label1.Text = "Фамилия";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 71);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 1;
            label2.Text = "Имя";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 114);
            label3.Name = "label3";
            label3.Size = new Size(72, 20);
            label3.TabIndex = 2;
            label3.Text = "Отчество";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(34, 161);
            label4.Name = "label4";
            label4.Size = new Size(86, 20);
            label4.TabIndex = 3;
            label4.Text = "Должность";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(34, 206);
            label5.Name = "label5";
            label5.Size = new Size(69, 20);
            label5.TabIndex = 4;
            label5.Text = "Кафедра";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(158, 28);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(125, 27);
            txtLastName.TabIndex = 5;
            // 
            // txtName
            // 
            txtName.Location = new Point(158, 71);
            txtName.Name = "txtName";
            txtName.Size = new Size(125, 27);
            txtName.TabIndex = 6;
            // 
            // txtPosition
            // 
            txtPosition.Location = new Point(158, 158);
            txtPosition.Name = "txtPosition";
            txtPosition.Size = new Size(125, 27);
            txtPosition.TabIndex = 7;
            // 
            // txtPatronymic
            // 
            txtPatronymic.Location = new Point(158, 114);
            txtPatronymic.Name = "txtPatronymic";
            txtPatronymic.Size = new Size(125, 27);
            txtPatronymic.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(34, 251);
            label6.Name = "label6";
            label6.Size = new Size(118, 20);
            label6.TabIndex = 10;
            label6.Text = "Ученая степень";
            // 
            // txtAcademicDegree
            // 
            txtAcademicDegree.Location = new Point(158, 248);
            txtAcademicDegree.Name = "txtAcademicDegree";
            txtAcademicDegree.Size = new Size(125, 27);
            txtAcademicDegree.TabIndex = 11;
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(107, 297);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(94, 29);
            btnInsert.TabIndex = 12;
            btnInsert.Text = "Добавить";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // cmbBoxDepartments
            // 
            cmbBoxDepartments.FormattingEnabled = true;
            cmbBoxDepartments.Location = new Point(158, 206);
            cmbBoxDepartments.Name = "cmbBoxDepartments";
            cmbBoxDepartments.Size = new Size(125, 28);
            cmbBoxDepartments.TabIndex = 13;
            // 
            // TeacherControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cmbBoxDepartments);
            Controls.Add(btnInsert);
            Controls.Add(txtAcademicDegree);
            Controls.Add(label6);
            Controls.Add(txtPatronymic);
            Controls.Add(txtPosition);
            Controls.Add(txtName);
            Controls.Add(txtLastName);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TeacherControl";
            Size = new Size(353, 338);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtLastName;
        private TextBox txtName;
        private TextBox txtPosition;
        private TextBox txtPatronymic;
        private Label label6;
        private TextBox txtAcademicDegree;
        private Button btnInsert;
        private ComboBox cmbBoxDepartments;
    }
}
