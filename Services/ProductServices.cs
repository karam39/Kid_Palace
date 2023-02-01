using Kid_PalaceA2.Models;
using Kid_PalaceA2.Models.ProductM;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace Kid_PalaceA2.Services
{
    public interface IProductServices
    {
         List<ToyModel> selectedcatprddata(int id);
         List<ProductCatagory> getprdCatdata();
         List<ToyModel> getprddata();
         int Scatid(int id);

        List<ProductCatagory> loadCategory();
       
    }
        public class ProductServices: IProductServices
    {
        //ToyModel obj = new ToyModel();
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductServices(AppDbContext db, IWebHostEnvironment hostEnviroment)
        {
            _db = db;
            this._hostEnvironment = hostEnviroment;
        }

        public List<ToyModel> selectedcatprddata(int id)
        {
            var prd = _db.Products2.Where(x => x.IsDeleted == false).ToList();
            var sprd = from cate in prd where cate.ProdCategoryid == id select cate;
            List<ToyModel> lst;
            lst = sprd.ToList();
            return (lst);
        }
        public List<ProductCatagory> getprdCatdata()
        {
            var prdcat = _db.ProductCategory.ToList();
            return (prdcat);
        }
        public List<ToyModel> getprddata()
        {
            var prd = _db.Products2.Where(x=>x.IsDeleted==false).ToList();
            return (prd);
        }
        public int Scatid(int id)
        {
            int catid = id;
            return (catid);
        }

        public List<ProductCatagory> loadCategory()
        {
            try
            {
                List<ProductCatagory> Pobj = new List<ProductCatagory>();
                Pobj = _db.ProductCategory.ToList();
                Pobj.Insert(0, new ProductCatagory { ProductCategoryId = 0, ProductCategoryName = "Please Select" });
                return Pobj;
            }
            catch (Exception)
            {
                throw;

            }
        }
              
     

    }
}

