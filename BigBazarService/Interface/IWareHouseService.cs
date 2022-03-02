using BigBazarModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBazarService.Interface
{
    public interface IWareHouseService
    {
        public List<WareHouse> GetWareHouseS();
        public List<WareHouse> InsertWareHouseS(List<WareHouse> myvalue);
        public List<WareHouse> UpdateWareHouseS(int id, string itemname, string itemtype, int itemprice, int itemquantity);
        public List<WareHouse> DeleteWareHouseS(int id);
        public BigBazarModels.Models.ChildW getchild(string username, string password);
    }
}
