using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.ReportDataSet;

namespace TMS.DAL
{
    public class cReportDAL
    {
        public SummaryDataSet getData()
        {
            SqlConnection con = new SqlConnection(Helper.conStr);
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
            con.Open();
            string query = "select * from Customers";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            
            Common.ReportDataSet.SummaryDataSet ds = new SummaryDataSet();
            da.Fill(ds.summary);

            return ds;
        }
    }
}
