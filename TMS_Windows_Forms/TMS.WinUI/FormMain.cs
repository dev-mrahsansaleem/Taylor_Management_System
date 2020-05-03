using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TMS.WinUI
{
    public partial class FormMain : Form
    {
        private string uType;

        public FormMain()
        {
            InitializeComponent();
        }

        public FormMain(string uType)
        {
            InitializeComponent();
            this.uType = uType;
        }

        private void createUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormUser().Show();
        }

        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormCustomer().Show();
        }

        private void addWorkerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormWorker().Show();
        }

        private void assignWorkToWorkerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormAssignWorkToWorker().Show();
        }

        private void completedWorkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.rptSummary rpt = new Reports.rptSummary();
            TMS.Common.ReportDataSet.SummaryDataSet ds = new TMS.BLL.cReportBLL().getData();
            rpt.SetDataSource(ds);


            FormViewSummary frn= new FormViewSummary();

            frn.crystalReportViewer1.ReportSource = rpt;

            frn.ShowDialog();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if(uType.ToUpper()!="admin".ToUpper())
                reportsToolStripMenuItem.Enabled = false;
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
