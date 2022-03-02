using BigBazarModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBazarRepository.Interface
{
    public interface IWareHouseRepository
    {
        public List<WareHouse> GetWareHouseR();
        public List<WareHouse> InsertWareHouseR(List<WareHouse> myvalue);
        public List<WareHouse> UpdateWareHouseR(int id, string itemname, string itemtype, int itemprice, int itemquantity);
        public List<WareHouse> DeleteWareHouseR(int id);
    }
}
