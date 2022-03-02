using BigBazarModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBazarRepository.Interface
{
    public interface ICustomerRepository
    {
        public List<Customer> GetCustomerR();

        public List<Customer> GetCustomerR(int id);
        public List<Customer> InsertCustomerR(Customer myvalue);
        public List<Customer> UpdateCustomerR(int id, Customer myvalue);
        public List<Customer> DeleteCustomerR(int id);
    }
}
