﻿using System;
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
            //DataTable res = ConvertCSVtoDataTable(filepath);
            //DataTable res = utworz_tabele();
            //dataGridView1.DataSource = res;
            dataGridView1.ColumnCount = 1;
            dataGridView1.Columns[0].Name = "Nazwa filmu";

            bool koniec = false;
            while (!koniec)
            {
                byte[] buffer = new byte[1024];
                int wielkosc = Global.GlobalVar.GetStream().Read(buffer, 0, 1024);
                string otrzymane = System.Text.Encoding.ASCII.GetString(buffer, 0, wielkosc);
                string odp = "ok133";
                byte[] message1 = new ASCIIEncoding().GetBytes(odp);
                Global.GlobalVar.GetStream().Write(message1, 0, message1.Length);
                if (otrzymane == "endoffile")
                    koniec = true;
                else
                {
                    //dr[0] = otrzymane;
                    string[] row = new string[] { otrzymane };
                    dataGridView1.Rows.Add(row);
                }
            }
        }

        /*public static DataTable utworz_tabele()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Nazwa");
            DataRow dr = dt.NewRow();
            bool koniec = false;
            while(!koniec)
            {
                byte[] buffer = new byte[1024];
                int wielkosc = Global.GlobalVar.GetStream().Read(buffer, 0, 1024);
                string otrzymane = System.Text.Encoding.ASCII.GetString(buffer, 0, wielkosc);
                string odp = "ok133";
                byte[] message1 = new ASCIIEncoding().GetBytes(odp);
                Global.GlobalVar.GetStream().Write(message1, 0, message1.Length);
                if (otrzymane == "endoffile")
                    koniec = true;
                else
                {
                    dr[0] = otrzymane;
                    dt.Rows.Add(otrzymane);
                }
            }
            return dt;
        }

        public static void utworz_tabele2()
        {
            //DataTable dt = new DataTable();
            //dt.Columns.Add("Nazwa");
            //DataRow dr = dt.NewRow();
            
            bool koniec = false;
            while (!koniec)
            {
                byte[] buffer = new byte[1024];
                int wielkosc = Global.GlobalVar.GetStream().Read(buffer, 0, 1024);
                string otrzymane = System.Text.Encoding.ASCII.GetString(buffer, 0, wielkosc);
                string odp = "ok133";
                byte[] message1 = new ASCIIEncoding().GetBytes(odp);
                Global.GlobalVar.GetStream().Write(message1, 0, message1.Length);
                if (otrzymane == "endoffile")
                    koniec = true;
                else
                {
                    //dr[0] = otrzymane;
                    //this.dataGridView1.Rows.Add(otrzymane);
                }
            }
            //return dt;
        }*/



        public static DataTable ConvertCSVtoDataTable(string strFilePath)
        {
            StreamReader sr = new StreamReader(strFilePath);
            string[] headers = sr.ReadLine().Split(',');
            DataTable dt = new DataTable();
            foreach (string header in headers)
            {
                dt.Columns.Add(header);
            } while (!sr.EndOfStream)
            {
                string[] rows = Regex.Split(sr.ReadLine(), ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
                DataRow dr = dt.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }


        private void BazaFilmow_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string film = this.textBox1.Text.ToString();
            byte[] message1 = new ASCIIEncoding().GetBytes(film);
            Global.GlobalVar.GetStream().Write(message1, 0, message1.Length);
            //dataGridView1.Rows.Add(film);
            //object r = film;
            //dataGridView1.
            //DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            //row.Cells[0].Value = film;
            string[] row = new string[] { film };
            dataGridView1.Rows.Add(row);
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
    }
}

