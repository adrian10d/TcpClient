using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
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
            this.label3.Visible = false;
            byte[] message = new ASCIIEncoding().GetBytes("1");
            Global.GlobalVar.GetStream().Write(message, 0, message.Length);
            Thread.Sleep(500);
            string login = this.textBox1.Text.ToString();
            string haslo = this.textBox2.Text.ToString();
            byte[] message1 = new ASCIIEncoding().GetBytes(login);
            byte[] message2 = new ASCIIEncoding().GetBytes(haslo);
            var sha1 = new SHA1CryptoServiceProvider();
            var sha1data = sha1.ComputeHash(message2);
            Global.GlobalVar.GetStream().Write(message1, 0, message1.Length);
            Global.GlobalVar.GetStream().Write(sha1data, 0, sha1data.Length);
            byte[] buffer = new byte[1];
            Global.GlobalVar.GetStream().Read(buffer, 0, 1);
            string otrzymane = System.Text.Encoding.ASCII.GetString(buffer, 0, 1);

            if (otrzymane == "0")
            {
                this.label3.Text = "Nie udalo sie zalogowac!";
                this.label3.Visible = true;
            }
            else if (otrzymane == "1")
            {
                this.Close();
             //   Gra f3 = new Gra();
            //    f3.Show();
                BazaFilmow baza = new BazaFilmow();
                baza.Show();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
