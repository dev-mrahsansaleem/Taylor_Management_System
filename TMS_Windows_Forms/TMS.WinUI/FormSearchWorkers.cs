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
    public partial class FormSearchWorkers : Form
    {
        public FormSearchWorkers()
        {
            InitializeComponent();
        }

        private void FormSearchWorkers_Load(object sender, EventArgs e)
        {
            dgvUsers.DataSource = "";
            dgvUsers.DataSource = new cWorkerBLL().getWorkers();
            this.dgvUsers.Columns[2].ReadOnly = true;
        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {
            dgvUsers.DataSource = "";
            dgvUsers.DataSource = new cWorkerBLL().getWorkers(tbUsername.Text.Trim());
            this.dgvUsers.Columns[2].ReadOnly = true;
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowIndex = this.dgvUsers.SelectedCells[0].RowIndex;
            int selectedColumnIndex = this.dgvUsers.SelectedCells[0].ColumnIndex;
            if (selectedColumnIndex == 0)//update
            {
                //MessageBox.Show("update click  "+this.dgvUsers.Rows[selectedRowIndex].Cells[4].Value);access row value
                cWorker w1 = new cWorker();
                w1.wId = Convert.ToInt32(this.dgvUsers.Rows[selectedRowIndex].Cells[2].Value);
                w1.wFullName = this.dgvUsers.Rows[selectedRowIndex].Cells[3].Value.ToString();
                w1.wCNIC = this.dgvUsers.Rows[selectedRowIndex].Cells[4].Value.ToString();
                w1.wAddress = this.dgvUsers.Rows[selectedRowIndex].Cells[5].Value.ToString();
                w1.wMobileNo = this.dgvUsers.Rows[selectedRowIndex].Cells[6].Value.ToString();
                w1.wEmergencyContact = this.dgvUsers.Rows[selectedRowIndex].Cells[7].Value.ToString();
                w1.wdateOfJoin = Convert.ToDateTime(this.dgvUsers.Rows[selectedRowIndex].Cells[8].Value);
                w1.wIsActive = Convert.ToBoolean(this.dgvUsers.Rows[selectedRowIndex].Cells[9].Value);
                new cWorkerBLL().UpdateWorker(w1);
                dgvUsers.DataSource = "";
                dgvUsers.DataSource = new cWorkerBLL().getWorkers();
                this.dgvUsers.Columns[2].ReadOnly = true;
                MessageBox.Show("Data Updated...!!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (selectedColumnIndex == 1)//delete
            {
                new cWorkerBLL().RemoveWorker(Convert.ToInt32(this.dgvUsers.Rows[selectedRowIndex].Cells[2].Value));
                dgvUsers.DataSource = "";
                dgvUsers.DataSource = new cWorkerBLL().getWorkers();
                this.dgvUsers.Columns[2].ReadOnly = true;
                MessageBox.Show("Data Deleted...!!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
