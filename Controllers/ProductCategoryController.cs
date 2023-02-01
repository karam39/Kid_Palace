using Kid_PalaceA2.Models;
using Kid_PalaceA2.Models.ProductM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kid_PalaceA2.Controllers
{
    public class ProductCategoryController : Controller
    {

        private readonly AppDbContext _db;

        public ProductCategoryController(AppDbContext db)
        {
            _db = db;
        }


        public IActionResult _Productcategory()
        {
            var a = _db.ProductCategory.ToList();
            return View(a);

        }
        public IActionResult ShowProductCategoryList()
        {
            var a = _db.ProductCategory.ToList();
            return View(a);

        }
        public IActionResult ProductCategoryCreate(ProductCatagory obj)
        {
            return View(obj);
        }

        [HttpPost]
        public IActionResult AddProductCategory(ProductCatagory obj)
        {
            try
            {
                if (obj.ProductCategoryId == 0)
                {
                    _db.ProductCategory.Add(obj);
                    _db.SaveChanges();
                }
                else
                {
                    _db.Entry(obj).State = EntityState.Modified;
                    _db.SaveChanges();
                }
                return RedirectToAction("ShowProductCategoryList");
            }
            catch (Exception)
            {

                throw;
            }

        }

        public IActionResult Delete(int id)
        {
            var obj = _db.ProductCategory.Find(id);
            if (obj != null)
            {
                _db.ProductCategory.Remove(obj);
                _db.SaveChanges();
            }
            return RedirectToAction("ShowProductCategoryList");
        }
        //public IActionResult DeleteProductCategory(int id)
        //{
        //    try
        //    {
        //        var obj = _db.ProductCategory.Find(id);
        //        if (obj != null)
        //        {
        //            _db.ProductCategory.Remove(obj);
        //            _db.SaveChangesAsync();
        //        }

        //        return RedirectToAction("ShowProductCategoryList");
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

    }
}
