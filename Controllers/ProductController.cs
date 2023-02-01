using Kid_PalaceA2.Models;
using Kid_PalaceA2.Models.ProductM;
using Kid_PalaceA2.Models.Supplier;
using Kid_PalaceA2.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace Kid_PalaceA2.Controllers
{
    public class ProductController : Controller
    {
        //ToyModel obj = new ToyModel();
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IProductServices _IProductServices;


        public ProductController(AppDbContext db, IWebHostEnvironment hostEnviroment, IProductServices iProductServices)
        {
            _db = db;
            this._hostEnvironment = hostEnviroment;
            _IProductServices = iProductServices;
        }


        public IActionResult Products(int id, string searchString)
        {
            try
            {
                var toys = from m in _db.Products2.Where(x => x.IsDeleted == false)
                           select m;
                ProductViewdata viewdata = new ProductViewdata();

                if (!String.IsNullOrEmpty(searchString))
                {
                    toys = toys.Where(s => s.ToyName!.Contains(searchString));

                    //  var prdlst1 = getprddata();
                    var prdcatlst1 = _IProductServices.getprdCatdata();
                    var sprdlst1 = _IProductServices.selectedcatprddata(id);
                    int scatid1 = _IProductServices.Scatid(id);


                    viewdata.product = toys.ToList();
                    viewdata.prdCategory = prdcatlst1;
                    viewdata.SelectedprdCat = sprdlst1;
                    viewdata.prdCatId = scatid1;

                    return View(viewdata);
                }

                var prdlst = _IProductServices.getprddata();
                var prdcatlst = _IProductServices.getprdCatdata();
                var sprdlst = _IProductServices.selectedcatprddata(id);
                int scatid = _IProductServices.Scatid(id);

                viewdata.product = prdlst;
                viewdata.prdCategory = prdcatlst;
                viewdata.SelectedprdCat = sprdlst;
                viewdata.prdCatId = scatid;

                return View(viewdata);

            }
            catch (Exception)
            {
                throw;
            }

        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Showtoys()
        {
            try
            {
                var ClsList = from a in _db.Products2.Where(x => x.IsDeleted == false)
                              join b in _db.ProductCategory
                              on a.ProdCategoryid equals b.ProductCategoryId
                              into toy
                              from b in toy.DefaultIfEmpty()

                              join s in _db.SupplierDetails
                              on a.SupplierId equals s.Id into t
                              from s in t.DefaultIfEmpty()

                              select new ToyModel
                              {
                                  Id = a.Id,
                                  ToyName = a.ToyName,
                                  ToyPrice = a.ToyPrice,
                                  Discount = a.Discount,
                                  SalePrice = a.SalePrice,
                                  ToyImg = a.ToyImg,
                                  PrdQuantity = a.PrdQuantity,
                                  ProdCategoryid = a.ProdCategoryid,
                                  PCategoryName = b == null ? "" : b.ProductCategoryName,
                                  SupplierName = s == null ? "" : s.SupplierName


                              };
                return View(ClsList);
            }
            catch (Exception)
            {

                throw;
            }
            // return View();
        }

        private void loadCategory()
        {
            try
            {
                ViewBag.Plist = _IProductServices.loadCategory();
            }
            catch (Exception)
            {
                throw;

            }
        }
        private void loadSupplier()
        {
            try
            {
                List<SupplierDetail> Pobj = new List<SupplierDetail>();
                Pobj = _db.SupplierDetails.Where(x => x.IsDeleted.Equals(false)).ToList();
                Pobj.Insert(0, new SupplierDetail { Id = 0, SupplierName = "Please Select" });
                ViewBag.Slist = Pobj;
            }
            catch (Exception)
            {
                throw;

            }
        }
        public IActionResult Create(ToyModel obj)
        {
            if (obj.Id > 0)
            {
                ToyModel updtoy = new ToyModel();
                updtoy = _db.Products2.FirstOrDefault(x => x.Id == obj.Id);
                obj.ProdCategoryid = updtoy.ProdCategoryid;
                obj.ToyImg = updtoy.ToyImg;
                obj.Discount = updtoy.Discount;
                obj.PrdQuantity = updtoy.PrdQuantity;

            }
            loadCategory();
            loadSupplier();
            return View(obj);
        }
        [RequestSizeLimit(52428800)]
        public async Task<IActionResult> AddToy(ToyModel obj)

        {

            try
            {
                ToyModel toy = _db.Products2.FirstOrDefault(x => x.Id == obj.Id);

                if (obj.Id == 0)
                {

                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(obj.ImageFile.FileName);
                    string extension = Path.GetExtension(obj.ImageFile.FileName);
                    obj.ToyImg = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/img/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await obj.ImageFile.CopyToAsync(fileStream);
                    }
                    if (obj.Discount > 0)
                    {
                        int dis = (obj.ToyPrice * obj.Discount) / 100;
                        obj.SalePrice = obj.ToyPrice - dis;
                    }
                    else
                    {
                        obj.SalePrice = obj.ToyPrice;

                    }
                    obj.IsDeleted = false;
                    obj.Creationdate = DateTime.Now;
                    _db.Products2.Add(obj);
                    await _db.SaveChangesAsync();


                }
                else
                {

                    if (obj.ImageFile != null)
                    {

                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        string fileName = Path.GetFileNameWithoutExtension(obj.ImageFile.FileName);
                        string extension = Path.GetExtension(obj.ImageFile.FileName);
                        obj.ToyImg = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        string path2 = Path.Combine(wwwRootPath + "/img/", toy.ToyImg);
                        if (System.IO.File.Exists(path2))
                        {
                            System.IO.File.Delete(path2);
                        }
                        string path = Path.Combine(wwwRootPath + "/img/", fileName);

                        using (var fileStream = new FileStream(path, FileMode.Append))
                        {
                            await obj.ImageFile.CopyToAsync(fileStream);
                        }

                        toy.ToyImg = obj.ToyImg;
                    }

                    toy.ToyName = obj.ToyName;
                    toy.ToyPrice = obj.ToyPrice;
                    toy.Discount = obj.Discount;
                    toy.PrdQuantity = obj.PrdQuantity;
                    if (obj.Discount > 0)
                    {
                        int dis = (obj.ToyPrice * obj.Discount) / 100;
                        toy.SalePrice = obj.ToyPrice - dis;
                    }
                    else
                    {
                        toy.SalePrice = obj.ToyPrice;

                    }
                    toy.ProdCategoryid = obj.ProdCategoryid;

                    toy.LastModificationTime = DateTime.Now;
                    _db.Entry(toy).State = EntityState.Modified;
                    await _db.SaveChangesAsync();

                    // return RedirectToAction("Showtoys");
                }
                return RedirectToAction("Showtoys");
                //return View(obj);
            }
            catch (Exception)
            {

                return RedirectToAction("Showtoys");
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var imageModel = await _db.Products2.Where(x => x.Id == id).ToListAsync();
                foreach (var item in imageModel)
                {
                    item.IsDeleted = true;
                    item.Deletiondate = DateTime.Now;
                }
                //delete image from wwwroot/image
                //if (imageModel.ToyImg.Length>0)
                //{
                //    var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "img", imageModel.ToyImg);
                //    if (System.IO.File.Exists(imagePath))
                //    {
                //        System.IO.File.Delete(imagePath);
                //    }

                //    //delete the record
                //}
                // _db.Products2.Remove(imageModel);
                await _db.SaveChangesAsync();

                return RedirectToAction("Showtoys");
            }
            catch (Exception e)
            {

                return RedirectToAction("Showtoys", e);
            }
        }

        public async Task<IActionResult> srch(string searchString)
        {
            var movies = from m in _db.Products2.Where(x => x.IsDeleted == false)
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.ToyName!.Contains(searchString));
                //movies = movies.Where(s => s.PCategoryName.Contains(searchString));
            }

            return View("Products", await movies.ToListAsync());
        }


    }

}
