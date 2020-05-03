using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common;
using TMS.DAL;

namespace TMS.BLL
{
    public class cAssignedWorkBLL
    {
        public int InsertAssignedWork(cAssignedWork assignedWork)
        {
            return new cAssignedWorkDAL().InsertAssignedWork(assignedWork);
        }
        public int getAssignedTaskToWorker(int workerId)
        {
            return new cAssignedWorkDAL().getAssignedTaskToWorker(workerId);
        }
        public int getAssignedTaskToWorker(int wId, string v)
        {
            return new cAssignedWorkDAL().getAssignedTaskToWorker(wId, v);
        }
        public List<cAssignedWork> getAssignedWorks()
        {
            return new cAssignedWorkDAL().getAssignedWorks();
        }

        public int UpdateAssignedWork(cAssignedWork w1)
        {
            return new cAssignedWorkDAL().UpdateAssignedWork(w1);
        }

        public int RemoveAssignedWork(int v)
        {
            return new cAssignedWorkDAL().RemoveAssignedWork(v);
        }
    }
}
