using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.DAL;

namespace TMS.BLL
{
    public class cReportBLL
    {
        public TMS.Common.ReportDataSet.SummaryDataSet getData()
        {
            return new cReportDAL().getData();
        }
    }
}
