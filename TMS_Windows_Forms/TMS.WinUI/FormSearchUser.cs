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
    public partial class FormSearchUser : Form
    {
        public FormSearchUser()
        {
            InitializeComponent();
        }
        

        private void FormSearchUser_Load(object sender, EventArgs e)
        {
            dgvUsers.DataSource = "";
            dgvUsers.DataSource = new cUserBLL().getUsers();
        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {
            dgvUsers.DataSource = "";
            dgvUsers.DataSource = new cUserBLL().getUsers(tbUsername.Text.Trim());
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int selectedRowIndex = this.dgvUsers.SelectedCells[0].RowIndex;
            int selectedColumnIndex = this.dgvUsers.SelectedCells[0].ColumnIndex;
            if (selectedColumnIndex == 0)//update
            {
                //MessageBox.Show("update click  "+this.dgvUsers.Rows[selectedRowIndex].Cells[4].Value);access row value
                cUsers u1 = new cUsers();
                u1.uId = Convert.ToInt32(this.dgvUsers.Rows[selectedRowIndex].Cells[2].Value);
                u1.uFullName = this.dgvUsers.Rows[selectedRowIndex].Cells[3].Value.ToString();
                u1.uUserName = this.dgvUsers.Rows[selectedRowIndex].Cells[4].Value.ToString();
                u1.uPassword = this.dgvUsers.Rows[selectedRowIndex].Cells[5].Value.ToString();
                u1.uType = this.dgvUsers.Rows[selectedRowIndex].Cells[6].Value.ToString();
                u1.uIsActive = Convert.ToBoolean(this.dgvUsers.Rows[selectedRowIndex].Cells[7].Value);
                if(u1.uType.ToUpper() == "ADMIN" || u1.uType.ToUpper()== "OPERATER")
                {
                    new cUserBLL().UpdateUser(u1);
                    dgvUsers.DataSource = "";
                    dgvUsers.DataSource = new cUserBLL().getUsers();
                    this.dgvUsers.Columns[2].ReadOnly = true;
                    MessageBox.Show("Data Updated...!!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("User type must be one of \"Admin\" or \"Operater\"...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            else if (selectedColumnIndex == 1)//delete
            {
                new cUserBLL().RemoveUser(Convert.ToInt32(this.dgvUsers.Rows[selectedRowIndex].Cells[2].Value));
                dgvUsers.DataSource = "";
                dgvUsers.DataSource = new cUserBLL().getUsers();
                this.dgvUsers.Columns[2].ReadOnly = true;
                MessageBox.Show("Data Deleted...!!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
