using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBazarData.Entity
{
    public class store
    {
        [Key]
        public int itemIdS { get; set; }
        public string itemNameS { get; set; }
        public string itemTypeS { get; set; }
        public int itemPriceS { get; set; }
        public int itemQuantityS { get; set; }
    }
}
