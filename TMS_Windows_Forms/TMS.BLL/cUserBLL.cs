using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common;
using TMS.DAL;

namespace TMS.BLL
{
    public class cUserBLL
    {
        public int InsertUser(cUsers user)
        {
            return new cUserDAL().InsertUser(user);
        }
        public List<cUsers> getUsers()
        {
            return new cUserDAL().getUsers();
        }
        public List<cUsers> getUsers(string username)
        {
            return new cUserDAL().getUsers(username);
        }

        public int UpdateUser(cUsers user)
        {
            return new cUserDAL().UpdateUser(user);
        }
        public int RemoveUser(int userid)
        {
            return new cUserDAL().RemoveUser(userid);
        }

    }
}
