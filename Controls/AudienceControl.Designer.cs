namespace Timetable.Controls
{
    partial class AudienceControl
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
            this.NametextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AddresstextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.capacitytextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.traveltimedateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // NametextBox
            // 
            this.NametextBox.Location = new System.Drawing.Point(160, 41);
            this.NametextBox.Name = "NametextBox";
            this.NametextBox.Size = new System.Drawing.Size(172, 27);
            this.NametextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Название";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Тип";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Адрес";
            // 
            // AddresstextBox
            // 
            this.AddresstextBox.Location = new System.Drawing.Point(160, 70);
            this.AddresstextBox.Name = "AddresstextBox";
            this.AddresstextBox.Size = new System.Drawing.Size(172, 27);
            this.AddresstextBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Вместительность";
            // 
            // capacitytextBox
            // 
            this.capacitytextBox.Location = new System.Drawing.Point(160, 140);
            this.capacitytextBox.Name = "capacitytextBox";
            this.capacitytextBox.Size = new System.Drawing.Size(172, 27);
            this.capacitytextBox.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Время в пути";
            // 
            // traveltimedateTimePicker
            // 
            this.traveltimedateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.traveltimedateTimePicker.Location = new System.Drawing.Point(160, 175);
            this.traveltimedateTimePicker.Name = "traveltimedateTimePicker";
            this.traveltimedateTimePicker.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.traveltimedateTimePicker.ShowUpDown = true;
            this.traveltimedateTimePicker.Size = new System.Drawing.Size(172, 27);
            this.traveltimedateTimePicker.TabIndex = 9;
            this.traveltimedateTimePicker.Value = new System.DateTime(2023, 1, 6, 0, 0, 0, 0);
            // 
            // buttonInsert
            // 
            this.buttonInsert.Location = new System.Drawing.Point(105, 217);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(139, 29);
            this.buttonInsert.TabIndex = 10;
            this.buttonInsert.Text = "Добавить";
            this.buttonInsert.UseVisualStyleBackColor = true;
            this.buttonInsert.Click += new System.EventHandler(this.ButtonInsert_Click);
            // 
            // typeComboBox
            // 
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Location = new System.Drawing.Point(160, 107);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(172, 28);
            this.typeComboBox.TabIndex = 11;
            // 
            // AudienceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.buttonInsert);
            this.Controls.Add(this.traveltimedateTimePicker);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.capacitytextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AddresstextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NametextBox);
            this.Name = "AudienceControl";
            this.Size = new System.Drawing.Size(353, 283);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox NametextBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox AddresstextBox;
        private Label label4;
        private TextBox capacitytextBox;
        private Label label5;
        private DateTimePicker traveltimedateTimePicker;
        private Button buttonInsert;
        private ComboBox typeComboBox;
    }
}
