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
    public partial class FormCustomer : Form
    {
        List<List<cDetails>> mList = new List<List<cDetails>>();
        List<string> typeList = new List<string>();
        public FormCustomer()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormGetMeasurements frm= new FormGetMeasurements();
            
            frm.ShowDialog();
            mList.Add(frm.detailsList);
            typeList.Add(frm.detailsList[0].tempType);
            listBox1.DataSource = new List<string>();
            listBox1.DataSource = typeList;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            cCustomer customer = new cCustomer();
            customer.cFullName = txtFullname.Text.Trim();
            customer.cCNIC = txtCNIC.Text.Trim();
            customer.cAddress = txtAddress.Text.Trim();
            customer.cMobileNo = txtMobile.Text.Trim();
            customer.cRemarks = txtRemarks.Text.Trim();

            if (customer.cFullName != "")
            {
                if (customer.cCNIC != "")
                {
                    if (customer.cAddress != "")
                    {
                        if (customer.cMobileNo != "")
                        {
                            if (customer.cRemarks != "")
                            {
                                if (new cCustomerBLL().InsertCustomer(customer) > 0)
                                {
                                    //valid record or user
                                    /**/

                                    var cid = new cCustomerBLL().getId(customer);//recently added customer
                                    cMeaurements m = new cMeaurements();
                                    cDetails d = new cDetails();
                                    foreach(var mes in mList)
                                    {
                                        m.cId = cid;
                                        m.mType = mes[0].tempType;
                                        new cMeaurementsBLL().InsertMeaurements(m);
                                        var mid= new cMeaurementsBLL().getId(m);
                                        foreach(var details in mes)
                                        {
                                            d.mId = mid;
                                            d.field_name = details.field_name;
                                            d.field_value = details.field_value;
                                            new cMeaurementsBLL().InsertDetails(d);
                                        }
                                    }
                                    MessageBox.Show("Data stored...!!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    txtFullname.Text = "";
                                    txtCNIC.Text = "";
                                    txtAddress.Text = "";
                                    txtMobile.Text = "";
                                    txtRemarks.Text = "";

                                }
                                else
                                {
                                    MessageBox.Show("Data cannot be stored...!!!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Remarks Must be entered...!!!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new FormSearchCustomer().Show();
        }
    }
}
