using Kid_PalaceA2.Models.ProductM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kid_PalaceA2.Models.Supplier
{
    public class SupplierDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string SupplierName { get; set; }
        [Required]
        public int SupplierPhoneNo { get; set; }

        public string Description { get; set; }

        public bool IsDeleted { get; set; }
    }
}
