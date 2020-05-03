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
    public partial class FormSearchCustomer : Form
    {
        public FormSearchCustomer()
        {
            InitializeComponent();
        }

        private void FormSearchCustomer_Load(object sender, EventArgs e)
        {
            dgvUsers.DataSource = "";
            dgvUsers.DataSource = new cCustomerBLL().getCustomers();
        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {
            dgvUsers.DataSource = "";
            dgvUsers.DataSource = new cCustomerBLL().getCustomers(tbUsername.Text.Trim());
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowIndex = this.dgvUsers.SelectedCells[0].RowIndex;
            int selectedColumnIndex = this.dgvUsers.SelectedCells[0].ColumnIndex;
            if (selectedColumnIndex == 0)//update
            {
                //MessageBox.Show("update click  "+this.dgvUsers.Rows[selectedRowIndex].Cells[4].Value);access row value
                cCustomer c1 = new cCustomer();
                c1.cId = Convert.ToInt32(this.dgvUsers.Rows[selectedRowIndex].Cells[2].Value);
                c1.cFullName = this.dgvUsers.Rows[selectedRowIndex].Cells[3].Value.ToString();
                c1.cCNIC = this.dgvUsers.Rows[selectedRowIndex].Cells[4].Value.ToString();
                c1.cAddress = this.dgvUsers.Rows[selectedRowIndex].Cells[5].Value.ToString();
                c1.cMobileNo = this.dgvUsers.Rows[selectedRowIndex].Cells[6].Value.ToString();
                c1.cRemarks = this.dgvUsers.Rows[selectedRowIndex].Cells[7].Value.ToString();

                new cCustomerBLL().UpdateCustomer(c1);

                dgvUsers.DataSource = "";
                dgvUsers.DataSource = new cCustomerBLL().getCustomers();
                this.dgvUsers.Columns[2].ReadOnly = true;

                MessageBox.Show("Data Updated...!!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else if (selectedColumnIndex == 1)//delete
            {
                new cCustomerBLL().RemoveCustomer(Convert.ToInt32(this.dgvUsers.Rows[selectedRowIndex].Cells[2].Value));

                dgvUsers.DataSource = "";
                dgvUsers.DataSource = new cCustomerBLL().getCustomers();
                this.dgvUsers.Columns[2].ReadOnly = true;

                MessageBox.Show("Data Deleted...!!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
