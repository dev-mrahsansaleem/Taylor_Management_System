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
    public partial class FormAssignWorkToWorker : Form
    {
        bool load = false;
        public FormAssignWorkToWorker()
        {
            InitializeComponent();
        }

        public class item
        {
            public string workername { get; set; }
            public int assigntask { get; set; }
            public int completedtask { get; set; }
            public int pendingtask { get; set; }
            //public DateTime maxdate { get; set; }
        };
        public void updateDataGrid()
        {
            List<item> myItems = new List<item>();
            var workers = new cWorkerBLL().getWorkers();
            foreach (var w in workers)
            {
                item myItem = new item();
                myItem.workername = w.wFullName;
                myItem.assigntask = new cAssignedWorkBLL().getAssignedTaskToWorker(w.wId);
                myItem.completedtask = new cAssignedWorkBLL().getAssignedTaskToWorker(w.wId, "complete");
                myItem.pendingtask = new cAssignedWorkBLL().getAssignedTaskToWorker(w.wId, "pending");
                myItems.Add(myItem);
            }
            this.dgvUsers.DataSource = "";
            this.dgvUsers.DataSource = myItems;
        }
        private void FormAssignWorkToWorker_Load(object sender, EventArgs e)
        {
            //this.comboBox1.DataSource = new List<string>();
            this.comboBox1.DataSource = new cCustomerBLL().getCustomers();
            this.comboBox1.ValueMember = "cFullName";
            this.comboBox2.DataSource = new List<string>();
            this.comboBox2.DataSource = new cWorkerBLL().getWorkers();
            this.comboBox2.ValueMember = "wFullName";
            updateDataGrid();
            this.dgvUsers.ReadOnly = true;
            //this.dgvUsers.AutoGenerateColumns = true;
            load = true;
            showCustomerMeaurements();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            new FormCustomer().ShowDialog();
            this.comboBox1.DataSource = new cCustomerBLL().getCustomers();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new FormWorker().ShowDialog();
            this.comboBox2.DataSource = new cWorkerBLL().getWorkers();
            updateDataGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cAssignedWork work = new cAssignedWork();
            work.mId = Convert.ToInt32(new cMeaurementsBLL().getId(listBox1.Text) );
            work.wId= Convert.ToInt32(comboBox2.SelectedItem.GetType().GetProperty("wId").GetValue(comboBox2.SelectedItem));
            work.astatus = "pending";
            work.aDueDate = dateTimePicker1.Value;
            work.aRemarks = textBox1.Text.Trim();
            work.aPrice = Convert.ToInt32(textBox2.Text.Trim());
            if (work.aPrice>-1)
            {
                if(work.aRemarks != "")
                {
                    new cAssignedWorkBLL().InsertAssignedWork(work);
                    updateDataGrid();
                    MessageBox.Show("data added...!!!", "Sucsses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("enter remarks for work...!!!", "alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("enter valid price for work...!!!", "alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            new FormSearchAssignWork().ShowDialog();
            updateDataGrid();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if(load)
            {
                showCustomerMeaurements();
            }
        }
        void showCustomerMeaurements()
        {
            var measures = new cMeaurementsBLL().getMeasurements(new cCustomerBLL().getId(new cCustomerBLL().getCustomers(comboBox1.Text)[0]));
            List<string> typeList = new List<string>();
            foreach(var m in measures)
            {
                typeList.Add(m.mType);
            }
            listBox1.DataSource = typeList;
        }
    }
}
