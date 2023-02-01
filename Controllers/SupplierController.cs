using Kid_PalaceA2.Models;
using Kid_PalaceA2.Models.ProductM;
using Kid_PalaceA2.Models.Supplier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kid_PalaceA2.Controllers
{
    public class Supplier : Controller
    {
        private readonly AppDbContext _db;

        public Supplier(AppDbContext db)
        {
            _db = db;
        }


        public IActionResult showSupplierDetail()
        {
            var a = _db.SupplierDetails.Where(x=>x.IsDeleted.Equals(false)).ToList();
        
            return View(a);

        }
        
        public IActionResult SupplierCreate(SupplierDetail obj)
        {
            return View(obj);
        }

        [HttpPost]
        public IActionResult AddSupplier(SupplierDetail obj)
        {
            try
            {
                if (obj.Id == 0)
                {
                    obj.IsDeleted = false;
                    _db.SupplierDetails.Add(obj);
                    _db.SaveChanges();
                }
                else
                {
                    _db.Entry(obj).State = EntityState.Modified;
                    _db.SaveChanges();
                }
                return RedirectToAction("showSupplierDetail");
            }
            catch (Exception)
            {

                throw;
            }

        }
        public IActionResult Delete(int id)
        {
            var obj = _db.SupplierDetails.Find(id);
            if (obj != null)
            {
                obj.IsDeleted=true;
                _db.SaveChanges();
            }
            return RedirectToAction("showSupplierDetail");
        }
     
    }
}
