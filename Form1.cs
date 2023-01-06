using Npgsql;
using System.Data;
using Timetable.Forms;
namespace Timetable
{
    public partial class Form1 : Form
    {
        private Form activeForm = new();
        private Button currentButton = new();

        private NpgsqlConnection conn;

        private readonly string conn_param = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=368;Database=timetabledb;";


        private readonly Color activeBackColorButton = Color.Green;
        private readonly Color inactiveBackColorButton = Color.White;

        private readonly Color activeForeColorButton = Color.Black;
        private readonly Color inactiveForeColorButton = Color.Black;

        public Form1()
        {
            InitializeComponent();
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            activeForm?.Close();

            //ActiveButtton(btnSender);
            activeForm= childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.Tag= childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void ActiveButtton(object btnSender)
        {
            if(btnSender != null)
            {
                if(currentButton != (Button)btnSender)
                {
                    DisableButton(currentButton);
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = activeBackColorButton;
                    currentButton.ForeColor = activeForeColorButton;
                }
            }
        }

        private void DisableButton(Button currentButton)
        {
            if (currentButton != null)
            {
                currentButton.BackColor= inactiveBackColorButton;
                currentButton.ForeColor=inactiveForeColorButton;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form3(), sender);
        }

        private void buttonDB_Click(object sender, EventArgs e)
        {
            if (conn?.State == ConnectionState.Open)
            {
                OpenChildForm(new DBForm(conn), sender);
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                conn = new NpgsqlConnection(conn_param);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    btn.BackColor = activeBackColorButton;
                    MessageBox.Show("Подключено");
                }
                else
                {
                    btn.BackColor = inactiveBackColorButton;
                    MessageBox.Show("Соединения нет");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}