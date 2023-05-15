namespace Timetable.Controls
{
    partial class CurriculumControl
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
            txtName = new TextBox();
            cmbBoxQualification = new ComboBox();
            btnInsert = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 43);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 0;
            label1.Text = "Название";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 86);
            label2.Name = "label2";
            label2.Size = new Size(111, 20);
            label2.TabIndex = 1;
            label2.Text = "Квалификация";
            // 
            // txtName
            // 
            txtName.Location = new Point(148, 43);
            txtName.Name = "txtName";
            txtName.Size = new Size(151, 27);
            txtName.TabIndex = 2;
            // 
            // cmbBoxQualification
            // 
            cmbBoxQualification.FormattingEnabled = true;
            cmbBoxQualification.Location = new Point(148, 78);
            cmbBoxQualification.Name = "cmbBoxQualification";
            cmbBoxQualification.Size = new Size(151, 28);
            cmbBoxQualification.TabIndex = 3;
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(102, 122);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(116, 29);
            btnInsert.TabIndex = 4;
            btnInsert.Text = "Добавить";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // CurriculumControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnInsert);
            Controls.Add(cmbBoxQualification);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "CurriculumControl";
            Size = new Size(342, 285);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtName;
        private ComboBox cmbBoxQualification;
        private Button btnInsert;
    }
}
