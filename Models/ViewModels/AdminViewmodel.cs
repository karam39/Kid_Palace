using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kid_PalaceA2.Models.ViewModels
{
    public class AdminViewmodel
    {
        public int totalproducts { get; set; }

        public int Sales { get; set; }

        public int Dilevery { get; set; }

        public List<Order> PendingOrders { get; set; }
    }
}
