using Kid_PalaceA2.Models.Supplier;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kid_PalaceA2.Models.ProductM
{
    public class ToyModel
    {
        [Key]
        public  int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        public string ToyName { get; set; }

        [Required(ErrorMessage = "Required")]
        public int PrdQuantity { get; set; }

        [Required(ErrorMessage = "Required")]
        public int ToyPrice { get; set; }

        public int Discount { get; set; }

        public int SalePrice { get; set;}

        [Required(ErrorMessage = "Required")]
        public string ToyImg { get; set; }

        [NotMapped]
        [DisplayName("Upload Picture")]
        public IFormFile ImageFile { get; set; }


        [ForeignKey("Toyrefids")]
        [Required(ErrorMessage = "Required")]
        [Display(Name = "AgeCategory")]
        public int ProdCategoryid { get; set; }

        public virtual ProductCatagory Toyrefids { get; set; }

        [ForeignKey("SupplierrefId")]
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }

        public virtual SupplierDetail SupplierrefId { get; set; }

        [Required(ErrorMessage = "Required")]
        [NotMapped]
        public string PCategoryName { get; set; }
        [Required(ErrorMessage = "Required")]
        [NotMapped]
        public string SupplierName { get; set; }

        public List<ToyModel> lst = new List<ToyModel>();

        public bool IsDeleted { get; set; }
        public DateTime Creationdate { get; set; }
        public DateTime Deletiondate { get; set; }

        public DateTime LastModificationTime { get; set; }
    }
}
