using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class BazaFilmow : Form
    {
        public BazaFilmow()
        {
            InitializeComponent();
            string filepath = (Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\TcpClient\\movies.csv");

            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "Title";
            dataGridView1.Columns[1].Name = "Year";
            dataGridView1.Columns[2].Name = "Director";
            dataGridView1.Columns[3].Name = "Genre";
            dataGridView1.Columns[4].Name = "Rating";


            bool koniec = false;
            while (!koniec)
            {
                byte[] buffer = new byte[1024];
                int wielkosc = Global.GlobalVar.GetStream().Read(buffer, 0, 1024);
                string otrzymane = System.Text.Encoding.ASCII.GetString(buffer, 0, wielkosc);
                string[] rows = Regex.Split(otrzymane, ";(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
                string odp = "ok133";
                byte[] message1 = new ASCIIEncoding().GetBytes(odp);
                Global.GlobalVar.GetStream().Write(message1, 0, message1.Length);
                if (otrzymane == "endoffile")
                    koniec = true;
                else
                {
                    dataGridView1.Rows.Add(rows);
                }
            }
        }


        private void BazaFilmow_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.label6.Visible = false;
            string title = this.textBox1.Text.ToString();
            string year = this.textBox2.Text.ToString();
            string director = this.textBox3.Text.ToString();
            string genre = this.comboBox1.Text.ToString();
            string rating = this.comboBox2.Text.ToString();
            if(title.Length!=0)
            {
                string film = title + ";" + year + ";" + director + ";" + genre + ";" + rating;
                byte[] message1 = new ASCIIEncoding().GetBytes(film);
                Global.GlobalVar.GetStream().Write(message1, 0, message1.Length);
                string[] row = new string[] { title, year, director, genre, rating };
                dataGridView1.Rows.Add(row);
            }
            else
            {
                this.label6.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string msg = "wyloguj00x015";
            byte[] message1 = new ASCIIEncoding().GetBytes(msg);
            Global.GlobalVar.GetStream().Write(message1, 0, message1.Length);
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}

