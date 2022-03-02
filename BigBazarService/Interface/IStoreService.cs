using BigBazarModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBazarService.Interface
{
    public interface IStoreService
    {
        public List<Store> GetStoreS();

        public List<Store> GetStoreS(int Count);

        public List<Store> InsertStoreS(List<Store> myvalue);
        public List<Store> UpdateStoreS(int id, string itemname, string itemtype, int itemprice, int itemquantity);
        public List<Store> DeleteStoreS(int id);
        public BigBazarModels.Models.Child getchild(string username, string password);
    }
}
