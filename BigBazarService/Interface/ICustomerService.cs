using BigBazarModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBazarService.Interface
{
    public interface ICustomerService
    {
        public List<Customer> GetCustomerS();

        public List<Customer> GetCustomerS(int id);
        public List<Customer> InsertCustomerS(Customer myvalue);
        public List<Customer> UpdateCustomerS(int id, Customer myvalue);
        public List<Customer> DeleteCustomerS(int id);

        public BigBazarModels.Models.ChildC getchild(string username, string password);
    }
}
