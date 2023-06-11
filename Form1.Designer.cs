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
            panelMenuLeft = new Panel();
            buttonConnect = new Button();
            buttonDB = new Button();
            buttonTimetable = new Button();
            panelMain = new Panel();
            panelMenuLeft.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenuLeft
            // 
            panelMenuLeft.BackColor = Color.FromArgb(178, 186, 191);
            panelMenuLeft.Controls.Add(buttonConnect);
            panelMenuLeft.Controls.Add(buttonDB);
            panelMenuLeft.Controls.Add(buttonTimetable);
            panelMenuLeft.Dock = DockStyle.Left;
            panelMenuLeft.Location = new Point(0, 0);
            panelMenuLeft.Name = "panelMenuLeft";
            panelMenuLeft.Size = new Size(190, 753);
            panelMenuLeft.TabIndex = 1;
            // 
            // buttonConnect
            // 
            buttonConnect.BackColor = Color.FromArgb(239, 241, 242);
            buttonConnect.Dock = DockStyle.Bottom;
            buttonConnect.FlatAppearance.BorderSize = 0;
            buttonConnect.FlatStyle = FlatStyle.Flat;
            buttonConnect.Location = new Point(0, 704);
            buttonConnect.Name = "buttonConnect";
            buttonConnect.Size = new Size(190, 49);
            buttonConnect.TabIndex = 3;
            buttonConnect.Text = "Подключение";
            buttonConnect.UseVisualStyleBackColor = false;
            buttonConnect.Click += buttonConnect_Click;
            // 
            // buttonDB
            // 
            buttonDB.BackColor = Color.FromArgb(239, 241, 242);
            buttonDB.Dock = DockStyle.Top;
            buttonDB.FlatAppearance.BorderSize = 0;
            buttonDB.FlatStyle = FlatStyle.Flat;
            buttonDB.Location = new Point(0, 70);
            buttonDB.Name = "buttonDB";
            buttonDB.Size = new Size(190, 70);
            buttonDB.TabIndex = 1;
            buttonDB.Text = "Заполения данных в бд";
            buttonDB.UseVisualStyleBackColor = false;
            buttonDB.Visible = false;
            buttonDB.Click += buttonDB_Click;
            // 
            // buttonTimetable
            // 
            buttonTimetable.BackColor = Color.FromArgb(239, 241, 242);
            buttonTimetable.Dock = DockStyle.Top;
            buttonTimetable.FlatAppearance.BorderSize = 0;
            buttonTimetable.FlatStyle = FlatStyle.Flat;
            buttonTimetable.Location = new Point(0, 0);
            buttonTimetable.Name = "buttonTimetable";
            buttonTimetable.Size = new Size(190, 70);
            buttonTimetable.TabIndex = 0;
            buttonTimetable.Text = "Составить расписание";
            buttonTimetable.UseVisualStyleBackColor = false;
            buttonTimetable.Visible = false;
            buttonTimetable.Click += Button1_Click;
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(168, 176, 181);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(190, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1562, 753);
            panelMain.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1752, 753);
            Controls.Add(panelMain);
            Controls.Add(panelMenuLeft);
            Name = "Form1";
            panelMenuLeft.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenuLeft;
        private Panel panelMain;
        private Button buttonDB;
        private Button buttonTimetable;
        private Button buttonConnect;
    }
}