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
    public class StoreRepository : IStoreRepository
    {
        private readonly IMapper _mapper;
        public StoreRepository(IMapper mapper)
        {
            _mapper = mapper;

        }
        public List<Store> DeleteStoreR(int id)
        {
            using (var db = new ApiDbContext())
            {

                var dbWork = db.store.Where(x => x.itemIdS == id).FirstOrDefault();
                db.store.Remove(dbWork);
                db.SaveChanges();

            }
            return null;
        }

        public List<Store> GetStoreR()
        {
            var db = new ApiDbContext();
            var details = db.store.ToList();
            var rdetails = _mapper.Map<List<Store>>(details);
            return rdetails;
        }

        public List<Store> GetStoreR(int Count)
        {
            var db = new ApiDbContext();
            var details = db.store.Where(x => x.itemQuantityS <= Count).Select(x => x).ToList();
            var rdetails = _mapper.Map<List<Store>>(details);
            return rdetails;
        }

        public List<Store> InsertStoreR(List<Store> myvalue)
        {
            using (var db = new ApiDbContext())
            {  //  var va = myvalue.Select(x => x).FirstOrDefault();
                // var vlu = myvalue.FirstOrDefault();
                foreach (var vlu in myvalue)
                {
                    var val = _mapper.Map<Store, store>(vlu);

                    db.store.Add(val);
                    db.SaveChanges();
                }
            }
            return null;
        }

        public List<Store> UpdateStoreR(int id, string itemname, string itemtype, int itemprice, int itemquantity)
        {
            var db = new ApiDbContext();
            var dbWork = db.store.Where(x => x.itemIdS == id).Select(x => x).FirstOrDefault();
            dbWork.itemNameS = itemname;
            dbWork.itemTypeS = itemtype;
            dbWork.itemPriceS = itemprice;
            dbWork.itemQuantityS = itemquantity;
            db.SaveChanges();
           
            return null;
        }
       /* public void testdbContext()
        {
            using (var db = new ApiDbContext())
            {
                var details = db.store.ToList();
            }
        }*/
    }
}
