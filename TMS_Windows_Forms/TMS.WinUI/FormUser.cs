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
    public partial class FormUser : Form
    {
        public FormUser()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cUsers user = new cUsers();
            user.uFullName = txtfullname.Text.Trim();
            user.uPassword = txtPassword.Text.Trim();
            user.uUserName = txtUsername.Text.Trim();
            user.uType = cbType.Text.Trim();
            user.uIsActive = cbIsActive.Checked;

            if(user.uFullName!="")
            {
                if(user.uPassword!="")
                {
                    if(user.uUserName!="")
                    {
                        if(user.uType!="")
                        {
                            //valid record or user
                            if(new cUserBLL().InsertUser(user)>0)
                            {
                                MessageBox.Show("Data stored...!!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtfullname.Text="";
                                txtPassword.Text="";
                                txtUsername.Text="";
                                cbType.Text="";
                                cbIsActive.Checked=false;

                            }
                            else
                            {
                                MessageBox.Show("Data cannot be stored...!!!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Type should be selected...!!!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("User Name should be filled...!!!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Password should be filled...!!!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Full Name should be filled...!!!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new FormSearchUser().Show();
        }
    }
}
