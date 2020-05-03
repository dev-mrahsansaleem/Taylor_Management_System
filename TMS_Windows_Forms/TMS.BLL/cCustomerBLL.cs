using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common;
using TMS.DAL;

namespace TMS.BLL
{
    public class cCustomerBLL
    {
        public int InsertCustomer(cCustomer customer)
        {
            return new cCustomerDAL().InsertCustomer(customer);
        }
        public List<cCustomer> getCustomers()
        {
            return new cCustomerDAL().getCustomers();
        }
        public List<cCustomer> getCustomers(string customername)
        {
            return new cCustomerDAL().getCustomers(customername);
        }
        public int RemoveCustomer(int customerId)
        {
            return new cCustomerDAL().RemoveCustomer(customerId);
        }

        public int UpdateCustomer(cCustomer c1)
        {
            return new cCustomerDAL().UpdateCustomer(c1);
        }
        public int getId(cCustomer c)
        {
            return new cCustomerDAL().getId(c);
        }
    }
}
