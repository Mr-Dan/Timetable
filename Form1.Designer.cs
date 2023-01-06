namespace Timetable
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMenuLeft = new System.Windows.Forms.Panel();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonDB = new System.Windows.Forms.Button();
            this.buttonTimetable = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelMenuLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenuLeft
            // 
            this.panelMenuLeft.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panelMenuLeft.Controls.Add(this.buttonConnect);
            this.panelMenuLeft.Controls.Add(this.buttonSettings);
            this.panelMenuLeft.Controls.Add(this.buttonDB);
            this.panelMenuLeft.Controls.Add(this.buttonTimetable);
            this.panelMenuLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenuLeft.Location = new System.Drawing.Point(0, 0);
            this.panelMenuLeft.Name = "panelMenuLeft";
            this.panelMenuLeft.Size = new System.Drawing.Size(216, 647);
            this.panelMenuLeft.TabIndex = 1;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonConnect.Location = new System.Drawing.Point(0, 598);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(216, 49);
            this.buttonConnect.TabIndex = 3;
            this.buttonConnect.Text = "Подключение";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonSettings
            // 
            this.buttonSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonSettings.Location = new System.Drawing.Point(0, 98);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(216, 49);
            this.buttonSettings.TabIndex = 2;
            this.buttonSettings.Text = "Настройки";
            this.buttonSettings.UseVisualStyleBackColor = true;
            // 
            // buttonDB
            // 
            this.buttonDB.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonDB.Location = new System.Drawing.Point(0, 49);
            this.buttonDB.Name = "buttonDB";
            this.buttonDB.Size = new System.Drawing.Size(216, 49);
            this.buttonDB.TabIndex = 1;
            this.buttonDB.Text = "Заполения данных в бд";
            this.buttonDB.UseVisualStyleBackColor = true;
            this.buttonDB.Click += new System.EventHandler(this.buttonDB_Click);
            // 
            // buttonTimetable
            // 
            this.buttonTimetable.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonTimetable.Location = new System.Drawing.Point(0, 0);
            this.buttonTimetable.Name = "buttonTimetable";
            this.buttonTimetable.Size = new System.Drawing.Size(216, 49);
            this.buttonTimetable.TabIndex = 0;
            this.buttonTimetable.Text = "Составить расписание";
            this.buttonTimetable.UseVisualStyleBackColor = true;
            this.buttonTimetable.Click += new System.EventHandler(this.Button1_Click);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(216, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1528, 647);
            this.panelMain.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1744, 647);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelMenuLeft);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelMenuLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelMenuLeft;
        private Panel panelMain;
        private Button buttonDB;
        private Button buttonTimetable;
        private Button buttonSettings;
        private Button buttonConnect;
    }
}