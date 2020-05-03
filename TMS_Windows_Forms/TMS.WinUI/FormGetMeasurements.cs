using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TMS.Common;

namespace TMS.WinUI
{
    public partial class FormGetMeasurements : Form
    {
        string path = @"D:\Git\Zoay\TMS\TMS.Common\Meausurements\";
        cDetails d = new cDetails();
        public List<cDetails> detailsList = new List<cDetails>();
        public FormGetMeasurements()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormGetMeasurements_Load(object sender, EventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo(path);//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.txt");
            List<string> fNames = new List<string>();
            foreach (var file in Files)
            {
                fNames.Add(file.Name);
            }
            comboBox1.DataSource = fNames;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(comboBox1.Text!="")
                {
                    dataGridView1.Rows.Clear();
                    string s = "";
                    StreamReader sr = new StreamReader(path + comboBox1.Text);
                    sr.BaseStream.Seek(0, SeekOrigin.Begin);
                    s = sr.ReadLine();
                    d.tempType = s;
                    s = sr.ReadLine();
                    while (s != null)
                    {
                        dataGridView1.Rows.Add(s, '0');
                        s = sr.ReadLine();
                    }
                    sr.Close();
                }
            }
            catch
            {
                MessageBox.Show(path + comboBox1.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i=0;i< dataGridView1.Rows.Count - 1;i++)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                //MessageBox.Show(row.Cells[0].Value.ToString());
                d.field_name = row.Cells[0].Value.ToString();
                d.field_value = Convert.ToDouble(row.Cells[1].Value.ToString());

                detailsList.Add(d);
            }
            this.Close();
        }
    }
}
