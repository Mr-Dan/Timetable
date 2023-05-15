namespace Timetable.Controls
{
    partial class CurriculumDisciplineControl
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
            txtCurriculum = new TextBox();
            txtDiscipline = new TextBox();
            txtCourse = new TextBox();
            txtSemester = new TextBox();
            txtHours = new TextBox();
            btnInsert = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(48, 38);
            label1.Name = "label1";
            label1.Size = new Size(110, 20);
            label1.TabIndex = 0;
            label1.Text = "Учебный план";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(48, 93);
            label2.Name = "label2";
            label2.Size = new Size(96, 20);
            label2.TabIndex = 1;
            label2.Text = "Дисциплина";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(48, 148);
            label3.Name = "label3";
            label3.Size = new Size(41, 20);
            label3.TabIndex = 2;
            label3.Text = "Курс";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(48, 203);
            label4.Name = "label4";
            label4.Size = new Size(67, 20);
            label4.TabIndex = 3;
            label4.Text = "Семестр";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(48, 257);
            label5.Name = "label5";
            label5.Size = new Size(45, 20);
            label5.TabIndex = 4;
            label5.Text = "Часы";
            // 
            // txtCurriculum
            // 
            txtCurriculum.Location = new Point(172, 35);
            txtCurriculum.Name = "txtCurriculum";
            txtCurriculum.Size = new Size(125, 27);
            txtCurriculum.TabIndex = 5;
            txtCurriculum.MouseDoubleClick += txtCurriculum_MouseDoubleClick;
            // 
            // txtDiscipline
            // 
            txtDiscipline.Location = new Point(172, 86);
            txtDiscipline.Name = "txtDiscipline";
            txtDiscipline.Size = new Size(125, 27);
            txtDiscipline.TabIndex = 6;
            txtDiscipline.MouseDoubleClick += txtDiscipline_MouseDoubleClick;
            // 
            // txtCourse
            // 
            txtCourse.Location = new Point(172, 141);
            txtCourse.Name = "txtCourse";
            txtCourse.Size = new Size(125, 27);
            txtCourse.TabIndex = 7;
            // 
            // txtSemester
            // 
            txtSemester.Location = new Point(172, 200);
            txtSemester.Name = "txtSemester";
            txtSemester.Size = new Size(125, 27);
            txtSemester.TabIndex = 8;
            // 
            // txtHours
            // 
            txtHours.Location = new Point(172, 257);
            txtHours.Name = "txtHours";
            txtHours.Size = new Size(125, 27);
            txtHours.TabIndex = 9;
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(111, 308);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(136, 29);
            btnInsert.TabIndex = 10;
            btnInsert.Text = "Добавить";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // CurriculumDisciplineControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnInsert);
            Controls.Add(txtHours);
            Controls.Add(txtSemester);
            Controls.Add(txtCourse);
            Controls.Add(txtDiscipline);
            Controls.Add(txtCurriculum);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "CurriculumDisciplineControl";
            Size = new Size(405, 388);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtCurriculum;
        private TextBox txtDiscipline;
        private TextBox txtCourse;
        private TextBox txtSemester;
        private TextBox txtHours;
        private Button btnInsert;
    }
}
