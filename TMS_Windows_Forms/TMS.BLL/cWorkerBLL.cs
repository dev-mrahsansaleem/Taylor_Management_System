using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common;
using TMS.DAL;

namespace TMS.BLL
{
    public class cWorkerBLL
    {
        public int InsertWorker(cWorker worker)
        {
            return new cWorkerDAL().InsertWorker(worker);
        }
        public List<cWorker> getWorkers()
        {
            return new cWorkerDAL().getWorkers();
        }
        public List<cWorker> getWorkers(string workername)
        {
            return new cWorkerDAL().getWorkers(workername);
        }
        public int UpdateWorker(cWorker worker)
        {
            return new cWorkerDAL().UpdateWorker(worker);
        }
        public int RemoveWorker(int workerid)
        {
            return new cWorkerDAL().RemoveWorker(workerid);
        }
    }
}
