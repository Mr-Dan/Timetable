namespace Timetable.Controls
{
    partial class DepartmentsControl
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
            Label label1;
            label2 = new Label();
            txtName = new TextBox();
            buttonInsert = new Button();
            txtAudience = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 39);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 0;
            label1.Text = "Название";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 81);
            label2.Name = "label2";
            label2.Size = new Size(84, 20);
            label2.TabIndex = 1;
            label2.Text = "Аудитория";
            // 
            // txtName
            // 
            txtName.Location = new Point(169, 39);
            txtName.Name = "txtName";
            txtName.Size = new Size(151, 27);
            txtName.TabIndex = 3;
            // 
            // buttonInsert
            // 
            buttonInsert.Location = new Point(115, 129);
            buttonInsert.Name = "buttonInsert";
            buttonInsert.Size = new Size(94, 29);
            buttonInsert.TabIndex = 8;
            buttonInsert.Text = "Вставить";
            buttonInsert.UseVisualStyleBackColor = true;
            buttonInsert.Click += buttonInsert_Click;
            // 
            // txtAudience
            // 
            txtAudience.Location = new Point(169, 81);
            txtAudience.Name = "txtAudience";
            txtAudience.Size = new Size(151, 27);
            txtAudience.TabIndex = 9;
            txtAudience.MouseDoubleClick += txtAudience_MouseDoubleClick;
            // 
            // DepartmentsControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtAudience);
            Controls.Add(buttonInsert);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "DepartmentsControl";
            Size = new Size(368, 173);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtName;
        private ComboBox cmbBoxTeacher;
        private Button buttonInsert;
        private TextBox txtAudience;
        private TextBox txtTeacher;
    }
}
