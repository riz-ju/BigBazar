using BigBazarModels.Models;
using BigBazarRepository.Interface;
using BigBazarService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBazarService.Service
{
    
    
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<Customer> DeleteCustomerS(int id)
        {
           return _customerRepository.DeleteCustomerR(id);
        }

        public List<Customer> GetCustomerS()
        {
            return _customerRepository.GetCustomerR();
        }

        public List<Customer> GetCustomerS(int id)
        {
            return _customerRepository.GetCustomerR(id);
        }

        public List<Customer> InsertCustomerS(Customer myvalue)
        {
            return _customerRepository.InsertCustomerR(myvalue);
        }

        public List<Customer> UpdateCustomerS(int id, Customer myvalue)
        {
            return _customerRepository.UpdateCustomerR(id, myvalue);
        }

        public ChildC getchild(string username, string password)
        {
            List<ChildC> childrecord = new List<ChildC>();
         childrecord.Add(new ChildC { Id = 1, childname = "Joe Biden", username = "Joe", password = "Biden" });
           /* var check = childrecord.Where(x=>x.username == username && x.password == password).FirstOrDefault();
            if (check == null)
            {
                MemberAccessException memberAccessException = new MemberAccessException("Wrong Credentials");
            }
            else
            {
                return check;
            }
            return null;*/
            return childrecord.Where(x => x.username == username && x.password == password).Select(x => x).FirstOrDefault();

        }
    }
}
