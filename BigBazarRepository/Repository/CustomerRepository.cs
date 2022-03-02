using AutoMapper;
using BigBazarData;
using BigBazarData.Entity;
using BigBazarModels.Models;
using BigBazarRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBazarRepository.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IMapper _mapper;
        public CustomerRepository(IMapper mapper)
        {
            _mapper = mapper;

        }
        public List<Customer> DeleteCustomerR(int id)
        {
            using (var db = new ApiDbContext())
            {

                var dbWork = db.customer.Where(x => x.customerId == id).FirstOrDefault();
                db.customer.Remove(dbWork);
                db.SaveChanges();

            }
            return null;
        }

        public List<Customer> GetCustomerR()
        {
            var db = new ApiDbContext();
            var details = db.customer.ToList();
            var rdetails = _mapper.Map<List<Customer>>(details);
            return rdetails;
        }

        public List<Customer> GetCustomerR(int id)
        {
            var db = new ApiDbContext();
            var details = db.customer.Where(x =>x.customerId == id).Select(x=>x).ToList();
            var rdetails = _mapper.Map<List<Customer>>(details);
            return rdetails;
        }

        public List<Customer> InsertCustomerR(Customer myvalue)
        {
            using (var db = new ApiDbContext())
            {  //  var va = myvalue.Select(x => x).FirstOrDefault();
                // var vlu = myvalue.FirstOrDefault();
                
                    var val = _mapper.Map<Customer, customer>(myvalue);

                    db.customer.Add(val);
                    db.SaveChanges();
                
            }
            return null;
        }

        public List<Customer> UpdateCustomerR(int id, Customer myvalue)
        {
            var db = new ApiDbContext();
            var dbWork = db.customer.Where(x => x.customerId == id).FirstOrDefault();
           var myval =  _mapper.Map<Customer,customer>(myvalue);
            //.dbWork.Add(myvalue);
            dbWork.customerName = myval.customerName;
            dbWork.customerId = myval.customerId;
            dbWork.customerMobile = myval.customerMobile;
            dbWork.customerEmail = myval.customerEmail;
            dbWork.itemName = myval.itemName;
            dbWork.itemId = myval.itemId;
            dbWork.itemType = myval.itemType;
            dbWork.itemQty = myval.itemQty;
            db.SaveChanges();

            return null;
        }
        
        
    }
}
