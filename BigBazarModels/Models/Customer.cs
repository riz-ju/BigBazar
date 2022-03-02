using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBazarModels.Models
{
    public class Customer
    {
        public int customerId { get; set; }
        public string customerName { get; set; }

        public string customerEmail { get; set; }

        public string customerMobile { get; set; }
        public int itemId { get; set; }

        public string itemName { get; set; }
        public string itemType { get; set; }

        public int itemQty { get; set; }


    }
}
