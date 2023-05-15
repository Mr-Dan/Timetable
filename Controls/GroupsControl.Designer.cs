namespace Timetable.Controls
{
    partial class GroupsControl
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
            txtGroups = new TextBox();
            txtGroup = new TextBox();
            btnInsert = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 45);
            label1.Name = "label1";
            label1.Size = new Size(109, 20);
            label1.TabIndex = 0;
            label1.Text = "Номер потока";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 85);
            label2.Name = "label2";
            label2.Size = new Size(58, 20);
            label2.TabIndex = 1;
            label2.Text = "Группа";
            // 
            // txtGroups
            // 
            txtGroups.Location = new Point(163, 45);
            txtGroups.Name = "txtGroups";
            txtGroups.Size = new Size(125, 27);
            txtGroups.TabIndex = 2;
            // 
            // txtGroup
            // 
            txtGroup.Location = new Point(163, 85);
            txtGroup.Name = "txtGroup";
            txtGroup.Size = new Size(125, 27);
            txtGroup.TabIndex = 3;
            txtGroup.MouseDoubleClick += txtGroup_MouseDoubleClick;
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(102, 144);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(94, 29);
            btnInsert.TabIndex = 4;
            btnInsert.Text = "Добавить";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // GroupsControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnInsert);
            Controls.Add(txtGroup);
            Controls.Add(txtGroups);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "GroupsControl";
            Size = new Size(338, 304);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtGroups;
        private TextBox txtGroup;
        private Button btnInsert;
    }
}
