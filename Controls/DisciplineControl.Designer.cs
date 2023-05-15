namespace Timetable.Controls
{
    partial class DisciplineControl
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
            cmbBoxTypelesson = new ComboBox();
            btnInsert = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 48);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 0;
            label1.Text = "Название";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 90);
            label2.Name = "label2";
            label2.Size = new Size(94, 20);
            label2.TabIndex = 1;
            label2.Text = "Тип занятия";
            // 
            // txtName
            // 
            txtName.Location = new Point(193, 41);
            txtName.Name = "txtName";
            txtName.Size = new Size(151, 27);
            txtName.TabIndex = 3;
            // 
            // cmbBoxTypelesson
            // 
            cmbBoxTypelesson.FormattingEnabled = true;
            cmbBoxTypelesson.Location = new Point(193, 82);
            cmbBoxTypelesson.Name = "cmbBoxTypelesson";
            cmbBoxTypelesson.Size = new Size(151, 28);
            cmbBoxTypelesson.TabIndex = 5;
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(140, 131);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(94, 29);
            btnInsert.TabIndex = 6;
            btnInsert.Text = "Добавить";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // DisciplineControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnInsert);
            Controls.Add(cmbBoxTypelesson);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "DisciplineControl";
            Size = new Size(373, 215);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtName;
        private ComboBox cmbBoxTypelesson;
        private Button btnInsert;
    }
}
