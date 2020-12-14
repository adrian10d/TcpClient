using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Gra : Form
    {
        public Gra()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dane = this.textBox1.Text.ToString();
            byte[] message1 = new ASCIIEncoding().GetBytes(dane);
            Global.GlobalVar.GetStream().Write(message1, 0, message1.Length);
            byte[] buffer = new byte[25];
            Global.GlobalVar.GetStream().Read(buffer, 0, 25);
            string otrzymane = System.Text.Encoding.ASCII.GetString(buffer, 0, 25);
            this.label1.Text = otrzymane;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] message1 = new ASCIIEncoding().GetBytes("koniec");
            Global.GlobalVar.GetStream().Write(message1, 0, message1.Length);
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
