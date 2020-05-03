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
    public partial class FormSearchAssignWork : Form
    {
        public FormSearchAssignWork()
        {
            InitializeComponent();
        }
        void updatedata()
        {
            this.dgvUsers.DataSource = "";
            this.dgvUsers.DataSource = new cAssignedWorkBLL().getAssignedWorks();
            this.dgvUsers.Columns[2].ReadOnly = true;
            this.dgvUsers.Columns[3].ReadOnly = true;
            this.dgvUsers.Columns[4].ReadOnly = true;
            this.dgvUsers.Columns[6].ReadOnly = true;
        }
        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowIndex = this.dgvUsers.SelectedCells[0].RowIndex;
            int selectedColumnIndex = this.dgvUsers.SelectedCells[0].ColumnIndex;
            if (selectedColumnIndex == 0)//update
            {
                //MessageBox.Show("update click  "+this.dgvUsers.Rows[selectedRowIndex].Cells[4].Value);access row value
                cAssignedWork w1 = new cAssignedWork();
                w1.aId = Convert.ToInt32(this.dgvUsers.Rows[selectedRowIndex].Cells[2].Value);
                w1.wId = Convert.ToInt32(this.dgvUsers.Rows[selectedRowIndex].Cells[3].Value);
                w1.mId = Convert.ToInt32(this.dgvUsers.Rows[selectedRowIndex].Cells[4].Value);
                w1.astatus = this.dgvUsers.Rows[selectedRowIndex].Cells[5].Value.ToString();
                w1.aDueDate = Convert.ToDateTime(this.dgvUsers.Rows[selectedRowIndex].Cells[6].Value);
                w1.aRemarks = this.dgvUsers.Rows[selectedRowIndex].Cells[7].Value.ToString();
                w1.aPrice = Convert.ToInt32(this.dgvUsers.Rows[selectedRowIndex].Cells[8].Value);

                if ((w1.astatus == "complete" || w1.astatus == "pending") && w1.astatus != "")
                {
                    new cAssignedWorkBLL().UpdateAssignedWork(w1);
                    updatedata();
                    MessageBox.Show("Data Updated...!!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("status type must be \"complete\" or \"pending\"...!!!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                
            }
            else if (selectedColumnIndex == 1)//delete
            {
                new cAssignedWorkBLL().RemoveAssignedWork(Convert.ToInt32(this.dgvUsers.Rows[selectedRowIndex].Cells[2].Value));
                updatedata();
                MessageBox.Show("Data Deleted...!!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FormSearchAssignWork_Load(object sender, EventArgs e)
        {
            updatedata();
        }
    }
}
