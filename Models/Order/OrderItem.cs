using Kid_PalaceA2.Models.ProductM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kid_PalaceA2.Models
{
    public class OrderItem
    {

        [Key]
        public int Id { get; set; }

        public int Quantity { get; set; }
        public double Price { get; set; }
        public string ToyImg { get; set; }
        public string ToyName { get; set; }

        //[ForeignKey("ToyModel")]
        public int ToyModelId { get; set; }
        //public ToyModel ToyModel { get; set; }
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

    }
}
