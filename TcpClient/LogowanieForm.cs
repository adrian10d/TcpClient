using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TcpClient
{
    public partial class LogowanieForm : Form
    {
        public LogowanieForm()
        {
            InitializeComponent();
        }

        private void LogowanieForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.label1.Visible = false;
            byte[] message = new ASCIIEncoding().GetBytes("1");
            Global.GlobalVar.GetStream().Write(message, 0, message.Length);
            Thread.Sleep(500);
            string login = this.textBox1.Text.ToString();
            string haslo = this.textBox2.Text.ToString();
            byte[] message1 = new ASCIIEncoding().GetBytes(login);
            byte[] message2 = new ASCIIEncoding().GetBytes(haslo);
            Global.GlobalVar.GetStream().Write(message1, 0, message1.Length);
            Global.GlobalVar.GetStream().Write(message2, 0, message2.Length);
            byte[] buffer = new byte[1];
            Global.GlobalVar.GetStream().Read(buffer, 0, 1);
            string otrzymane = System.Text.Encoding.ASCII.GetString(buffer, 0, 1);

            if (otrzymane == "0")
            {
                this.label1.Text = "Nie udalo sie zalogowac!";
                this.label1.Visible = true;
            }
            else if (otrzymane == "1")
            {
                this.Close();
                Gra f3 = new Gra();
                f3.Show();
            }

        }
    }
}
