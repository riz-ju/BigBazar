using BigBazarModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBazarRepository.Interface
{
   public interface IStoreRepository
    {
        public List<Store> GetStoreR();

        public List<Store> GetStoreR(int Count);
        public List<Store> InsertStoreR(List<Store> myvalue);
        public List<Store> UpdateStoreR(int id, string itemname, string itemtype, int itemprice, int itemquantity);
        public List<Store> DeleteStoreR(int id);
    }
}
