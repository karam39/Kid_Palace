using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kid_PalaceA2.Models
{
    public class RecievingAddress
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CustomerName { get; set; }

        [Required]
        public int PhoneNo { get; set; }

        [Required]
        public string Address { get; set; }

        public string SpecialInstructions { get; set; }

        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

    }
}
