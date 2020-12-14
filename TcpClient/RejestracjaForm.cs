using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class RejestracjaForm : Form
    {
        public RejestracjaForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.label3.Visible = false;
            string login = this.textBox1.Text.ToString();
            string haslo1 = this.textBox2.Text.ToString();
            byte[] message = new ASCIIEncoding().GetBytes("2");
            Global.GlobalVar.GetStream().Write(message, 0, message.Length);
            Thread.Sleep(500);
            byte[] message1 = new ASCIIEncoding().GetBytes(login);
            Global.GlobalVar.GetStream().Write(message1, 0, message1.Length);
            byte[] message2 = new ASCIIEncoding().GetBytes(haslo1);
            Global.GlobalVar.GetStream().Write(message2, 0, message2.Length);
            byte[] buffer = new byte[1];
            Global.GlobalVar.GetStream().Read(buffer, 0, 1);
            string otrzymane = System.Text.Encoding.ASCII.GetString(buffer, 0, 1);
            if (otrzymane == "0")
            {
                this.label3.Text = "Login juz zajety!";
                this.label3.Visible = true;
            }
            else if (otrzymane == "1")
            {
                this.label3.Text = "Udalo sie utworzyc konto! Pzechodze do okna startowego.";
                this.label3.Visible = true;
                Thread.Sleep(1000);
                this.Close();
                Form1 f1 = new Form1();
                f1.Show();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
