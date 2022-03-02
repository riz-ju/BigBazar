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
    public class WareHouseService : IWareHouseService
    {
        private readonly IWareHouseRepository _wareHouseRepository;
        public WareHouseService(IWareHouseRepository wareHouseRepository)
        {
            _wareHouseRepository = wareHouseRepository;

        }

        public List<WareHouse> DeleteWareHouseS(int id)
        {
            return _wareHouseRepository.DeleteWareHouseR(id);
        }

        public List<WareHouse> GetWareHouseS()
        {
            return _wareHouseRepository.GetWareHouseR();
        }

        public List<WareHouse> InsertWareHouseS(List<WareHouse> myvalue)
        {
           return _wareHouseRepository.InsertWareHouseR(myvalue);
        }

        public List<WareHouse> UpdateWareHouseS(int id, string itemname, string itemtype, int itemprice, int itemquantity)
        {
         return  _wareHouseRepository.UpdateWareHouseR(id, itemname, itemtype,  itemprice, itemquantity);
        
        }
        public ChildW getchild(string username, string password)
        {
            List<ChildW> childrecord = new List<ChildW>();
            childrecord.Add(new ChildW { Id = 1, childname = "Vladimir Putin", username = "Vladimir", password = "Putin" });


            return childrecord.Where(x => x.username == username && x.password == password).Select(x => x).FirstOrDefault();

        }
    }
}
