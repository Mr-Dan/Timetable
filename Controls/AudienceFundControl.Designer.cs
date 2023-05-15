namespace Timetable.Controls
{
    partial class AudienceFundControl
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
            txtDepartments = new TextBox();
            txtAudience = new TextBox();
            btnInsert = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 48);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 0;
            label1.Text = "Кафедра";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 95);
            label2.Name = "label2";
            label2.Size = new Size(84, 20);
            label2.TabIndex = 1;
            label2.Text = "Аудитория";
            // 
            // txtDepartments
            // 
            txtDepartments.Location = new Point(116, 48);
            txtDepartments.Name = "txtDepartments";
            txtDepartments.Size = new Size(125, 27);
            txtDepartments.TabIndex = 2;
            txtDepartments.MouseDoubleClick += txtDepartments_MouseDoubleClick;
            // 
            // txtAudience
            // 
            txtAudience.Location = new Point(116, 92);
            txtAudience.Name = "txtAudience";
            txtAudience.Size = new Size(125, 27);
            txtAudience.TabIndex = 3;
            txtAudience.MouseDoubleClick += txtAudience_MouseDoubleClick;
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(66, 142);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(122, 29);
            btnInsert.TabIndex = 4;
            btnInsert.Text = "Добавить";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // AudienceFundControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnInsert);
            Controls.Add(txtAudience);
            Controls.Add(txtDepartments);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AudienceFundControl";
            Size = new Size(311, 250);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtDepartments;
        private TextBox txtAudience;
        private Button btnInsert;
    }
}
