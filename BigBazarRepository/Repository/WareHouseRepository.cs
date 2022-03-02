
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
    public class WareHouseRepository : IWareHouseRepository
    {
        private readonly IMapper _mapper;

        public WareHouseRepository(IMapper mapper)
        {
            _mapper = mapper;

        }
        public List<WareHouse> DeleteWareHouseR(int id)
        {
            /*var db = new ApiDbContext();
            var details = db.wareHouse.ToList();
            var rdetails = _mapper.Map<List<WareHouse>>(details);
            return rdetails;*/
            using (var db = new ApiDbContext())
            {

                var dbWork = db.wareHouse.Where(x => x.itemIdW == id).FirstOrDefault();
                db.wareHouse.Remove(dbWork);
                db.SaveChanges();

            }
            return null;
        }

        public List<WareHouse> GetWareHouseR()
        {
            var db = new ApiDbContext();
            var details = db.wareHouse.ToList();
            var rdetails = _mapper.Map<List<WareHouse>>(details);
            return rdetails;
        }

        public List<WareHouse> InsertWareHouseR(List<WareHouse> myvalue)
        {
            using (var db = new ApiDbContext())
            {  //  var va = myvalue.Select(x => x).FirstOrDefault();
                // var vlu = myvalue.FirstOrDefault();
                foreach (var vlu in myvalue)
                {
                    var val = _mapper.Map<WareHouse, wareHouse>(vlu);

                    db.wareHouse.Add(val);
                    db.SaveChanges();
                }
            }
            return null;
        }

        public List<WareHouse> UpdateWareHouseR(int id, string itemname, string itemtype, int itemprice, int itemquantity)
        {
            var db = new ApiDbContext();
            var dbWork = db.wareHouse.Where(x => x.itemIdW == id).Select(x => x).FirstOrDefault();
            dbWork.itemNameW = itemname;
            dbWork.itemTypeW = itemtype;
            dbWork.itemPriceW = itemprice;
            dbWork.itemQuantityW = itemquantity;
            db.SaveChanges();
            return null;
        }

       /* public void testdbContext()
        {
            using (var db = new ApiDbContext())
            {
                var details = db.wareHouse.ToList();
            }
        }*/
    }
}
