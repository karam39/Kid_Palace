using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kid_PalaceA2.Models.ViewModels
{
    public class Orderviewdata
    {
        public List<OrderItem> Orderr { get; set; }
        public List<RecievingAddress> Address { get; set; }

        public DateTime orderdate { get; set; }
    }
}
