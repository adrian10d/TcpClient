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
        DataTable res = ConvertCSVtoDataTable(filepath);
            dataGridView1.DataSource = res;
        }

        public static DataTable utworz_tabele()
        {
            List<string> baza = new List<string>();
            string[] linie;
            bool koniec = true;
            while(koniec)
            {
                byte[] buffer = new byte[1024];
                int wielkosc = Global.GlobalVar.GetStream().Read(buffer, 0, 1024);
                string otrzymane = System.Text.Encoding.ASCII.GetString(buffer, 0, wielkosc);
                //linie.Append(otrzymane);
                baza.Add(otrzymane);
            }
            
        }



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
    }
}

