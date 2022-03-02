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
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;
        public StoreService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;

        }

        public List<Store> DeleteStoreS(int id)
        {
          return  _storeRepository.DeleteStoreR(id);
        }

        public List<Store> GetStoreS()
        {
            return _storeRepository.GetStoreR();
        }
        public List<Store> GetStoreS(int Count)
        {
            return _storeRepository.GetStoreR(Count);
        }

        public List<Store> InsertStoreS(List<Store> myvalue)
        {
            return _storeRepository.InsertStoreR(myvalue);
            //throw new NotImplementedException();
        }

        public List<Store> UpdateStoreS(int id, string itemname, string itemtype, int itemprice, int itemquantity)
        {
          return  _storeRepository.UpdateStoreR(id, itemname, itemtype, itemprice, itemquantity);
        }

        public Child getchild(string username, string password)
        {
            List<Child> childrecord = new List<Child>();
            childrecord.Add(new Child { Id = 1, childname = "Volodymyr Zelenskyy", username = "Volodymyr", password = "Zelenskyy" });
        

            return childrecord.Where(x => x.username == username && x.password == password).Select(x => x).FirstOrDefault();

        }
    }
}
