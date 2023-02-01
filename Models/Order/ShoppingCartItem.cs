using Kid_PalaceA2.Models.ProductM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kid_PalaceA2.Models
{
    public class ShoppingCartItem
    {

        [Key]
        public int Id { get; set; }

        public ToyModel ToyModel { get; set; }
        public int Quantity { get; set; }     
        public string ShoppingCartId { get; set; }
    }
}
