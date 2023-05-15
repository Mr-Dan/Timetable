namespace Timetable.Controls
{
    partial class GroupControl
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
            txtName = new TextBox();
            label2 = new Label();
            cmbBoxFaculty = new ComboBox();
            btnInsert = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            cmbBoxFormeducation = new ComboBox();
            dTPRecruitmentYear = new DateTimePicker();
            txtAmount = new TextBox();
            txtCurriculum = new TextBox();
            label6 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 46);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 0;
            label1.Text = "Название";
            // 
            // txtName
            // 
            txtName.Location = new Point(162, 43);
            txtName.Name = "txtName";
            txtName.Size = new Size(151, 27);
            txtName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 93);
            label2.Name = "label2";
            label2.Size = new Size(78, 20);
            label2.TabIndex = 3;
            label2.Text = "Факультет";
            // 
            // cmbBoxFaculty
            // 
            cmbBoxFaculty.FormattingEnabled = true;
            cmbBoxFaculty.Location = new Point(162, 85);
            cmbBoxFaculty.Name = "cmbBoxFaculty";
            cmbBoxFaculty.Size = new Size(151, 28);
            cmbBoxFaculty.TabIndex = 5;
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(94, 272);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(94, 29);
            btnInsert.TabIndex = 6;
            btnInsert.Text = "Вставить";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 131);
            label3.Name = "label3";
            label3.Size = new Size(128, 20);
            label3.TabIndex = 7;
            label3.Text = "Форма обучения";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 166);
            label4.Name = "label4";
            label4.Size = new Size(89, 20);
            label4.TabIndex = 8;
            label4.Text = "Год набора";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 205);
            label5.Name = "label5";
            label5.Size = new Size(162, 20);
            label5.TabIndex = 9;
            label5.Text = "Количество студентов";
            // 
            // cmbBoxFormeducation
            // 
            cmbBoxFormeducation.FormattingEnabled = true;
            cmbBoxFormeducation.Location = new Point(162, 128);
            cmbBoxFormeducation.Name = "cmbBoxFormeducation";
            cmbBoxFormeducation.Size = new Size(151, 28);
            cmbBoxFormeducation.TabIndex = 10;
            // 
            // dTPRecruitmentYear
            // 
            dTPRecruitmentYear.Location = new Point(162, 165);
            dTPRecruitmentYear.Name = "dTPRecruitmentYear";
            dTPRecruitmentYear.Size = new Size(250, 27);
            dTPRecruitmentYear.TabIndex = 11;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(194, 205);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(151, 27);
            txtAmount.TabIndex = 12;
            // 
            // txtCurriculum
            // 
            txtCurriculum.Location = new Point(194, 238);
            txtCurriculum.Name = "txtCurriculum";
            txtCurriculum.Size = new Size(151, 27);
            txtCurriculum.TabIndex = 14;
            txtCurriculum.MouseDoubleClick += txtCurriculum_MouseDoubleClick;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(26, 238);
            label6.Name = "label6";
            label6.Size = new Size(110, 20);
            label6.TabIndex = 13;
            label6.Text = "Учебный план";
            // 
            // GroupControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtCurriculum);
            Controls.Add(label6);
            Controls.Add(txtAmount);
            Controls.Add(dTPRecruitmentYear);
            Controls.Add(cmbBoxFormeducation);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnInsert);
            Controls.Add(cmbBoxFaculty);
            Controls.Add(label2);
            Controls.Add(txtName);
            Controls.Add(label1);
            Name = "GroupControl";
            Size = new Size(442, 323);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtName;
        private Label label2;
        private ComboBox cmbBoxFaculty;
        private Button btnInsert;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox cmbBoxFormeducation;
        private DateTimePicker dTPRecruitmentYear;
        private TextBox txtAmount;
        private TextBox txtCurriculum;
        private Label label6;
    }
}
