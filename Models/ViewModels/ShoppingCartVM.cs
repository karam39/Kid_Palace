using Kid_PalaceA2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kid_PalaceA2.Models.ViewModels
{
    public class ShoppingCartVM
    {
        public ShoppingCartService ShoppingCart { get; set; }
        public double ShoppingCartTotal { get; set; }


    }
}
