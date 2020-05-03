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
    public partial class FormWorker : Form
    {
        public FormWorker()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            cWorker worker = new cWorker();
            worker.wFullName = txtfullname.Text.Trim();
            worker.wCNIC = txtCNIC.Text.Trim();
            worker.wAddress = txtAddress.Text.Trim();
            worker.wMobileNo = txtMobileNo.Text.Trim();


            worker.wEmergencyContact = cbEmergency.Text.Trim();
            worker.wdateOfJoin = dtpJoining.Value;
            worker.wIsActive = cbIsActive.Checked;

            if (worker.wFullName != "")
            {
                if (worker.wCNIC != "")
                {
                    if (worker.wAddress != "")
                    {
                        if (worker.wMobileNo != "")
                        {
                            if(worker.wEmergencyContact!="")
                            {
                                if (new cWorkerBLL().InsertWorker(worker) > 0)
                                {
                                    //valid record or user
                                    /**/
                                    MessageBox.Show("Data stored...!!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    txtfullname.Text = "";
                                    txtCNIC.Text = "";
                                    txtAddress.Text = "";
                                    txtMobileNo.Text = "";
                                    cbEmergency.Text = "";
                                    cbEmergency.Items.Clear();
                                    dtpJoining.ResetText();
                                    cbIsActive.Checked = false;
                                }
                                else
                                {
                                    MessageBox.Show("Data cannot be stored...!!!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Emergencey Contact No. Must be entered...!!!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            }
                        }
                        else
                        {
                            MessageBox.Show("Mobile No should be selected...!!!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Address should be filled...!!!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("CNIC should be filled...!!!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Full Name should be filled...!!!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cbEmergency_Click(object sender, EventArgs e)
        {
            cbEmergency.Items.Clear();
            cbEmergency.Items.Add(txtMobileNo.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new FormSearchWorkers().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
