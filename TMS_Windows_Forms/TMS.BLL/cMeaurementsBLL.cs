using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common;

namespace TMS.BLL
{
    public class cMeaurementsBLL
    {
        public int InsertMeaurements(cMeaurements m)
        {
            return new TMS.DAL.cMeaurementsDAL().InsertMeaurements(m);
        }
        public int getId(cMeaurements m)
        {
            return new TMS.DAL.cMeaurementsDAL().getId(m);
        }
        public int getId(string type)
        {
            return new TMS.DAL.cMeaurementsDAL().getId(type);
        }

        public int InsertDetails(cDetails d)
        {
            return new TMS.DAL.cMeaurementsDAL().InsertDetails(d);
        }

        public List<cMeaurements> getMeasurements(int cID)
        {
            return new TMS.DAL.cMeaurementsDAL().getMeasurements(cID);
        }
    }
}
