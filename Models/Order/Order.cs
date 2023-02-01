using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kid_PalaceA2.Models
{

    public class Order
    {

        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }


        public List<OrderItem> OrderItems { get; set; }

        public string Orderstatus { get; set; }
        [NotMapped]
        public int OrderstatusID { get; set; }


    }
}