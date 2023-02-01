using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kid_PalaceA2.Models.ProductM
{
    public class ProductCatagory
    {
        [Key]
        public int ProductCategoryId { get; set; }

        [Required(ErrorMessage = "Required")]
        public string ProductCategoryName { get; set; }

    
      //  public List<ProductCatagory> lst = new List<ProductCatagory>();

    }
}
