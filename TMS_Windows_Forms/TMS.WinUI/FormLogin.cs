using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TMS.BLL;
using TMS.Common;

namespace TMS.WinUI
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = comboBox1.Text;
            string password = textBox1.Text;
            bool valid = false;
            List<cUsers> AllUsers= new cUserBLL().getUsers();

            foreach(var user in AllUsers)
            {
                if(user.uUserName==username && user.uPassword==password)
                {
                    //valid user navigate to main page
                    this.Hide();
                    valid = true;
                    new FormMain(user.uType).ShowDialog();
                    this.Close();
                }
            }
            if(!valid)
                MessageBox.Show("Invalid User...!!!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.comboBox1.DataSource = new List<string>();
            this.comboBox1.DataSource = new cUserBLL().getUsers();
            this.comboBox1.ValueMember = "uUserName";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
