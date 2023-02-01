using Kid_PalaceA2.Models.ProductM;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kid_PalaceA2.Models
{
    public class ProductViewdata
    {
        public List<ToyModel> product { get; set; }
        public List<ProductCatagory> prdCategory { get; set; }
        public List<ToyModel> SelectedprdCat { get; set; }

        public int prdCatId { get; set; }

      //  public List<ToyModel> LatestProduct { get; set; }
    }
}
