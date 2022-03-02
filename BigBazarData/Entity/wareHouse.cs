using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBazarData.Entity
{
    public class wareHouse
    {
        [Key]
        public int itemIdW { get; set; }
        public string itemNameW { get; set; }
        public string itemTypeW { get; set; }
        public int itemPriceW { get; set; }
        public int itemQuantityW { get; set; }
    }
}
