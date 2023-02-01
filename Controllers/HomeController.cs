using Kid_PalaceA2.Models;
using Kid_PalaceA2.Models.ViewModels;
using Kid_PalaceA2.Models.ProductM;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Kid_PalaceA2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly UserManager<IdentityUser> _userManager;
        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager, AppDbContext db, IWebHostEnvironment hostEnviroment)
        {
            _db = db;
            _userManager = userManager;
            _logger = logger;
            this._hostEnvironment = hostEnviroment;
        }

        public List<ToyModel> LatestArrival()
        {
            var latesttoys = _db.Products2.Where(x => x.IsDeleted == false).OrderByDescending(x => x.Id).Take(12).ToList();

            return (latesttoys);
        }
        public IActionResult Index()
        {
            HomeViewdata viewdata = new HomeViewdata();

            viewdata.LatestProduct = LatestArrival();

            //if (User.Identity.IsAuthenticated)
            //{
            //    string b = User.Identity.Name.ToString();
            //    if ((b.Split('@')[0]) == "Admin786")
            //    {
            //        return RedirectToAction("AdminDashboard");
            //    }
            //}
            return View(viewdata);

        }

        public IActionResult AdminDashboard()
        {
            var totalprdcts = _db.Products2.ToList();
            var sales = _db.Orders.Where(x => x.Orderstatus == "Completed").ToList();
            var dilivery = _db.Orders.Where(x => x.Orderstatus == "Processing").ToList();
            var pendingorder = _db.Orders.Include(n => n.OrderItems).Where(n => n.Orderstatus.Equals("Pending")).ToList();

            AdminViewmodel obj = new AdminViewmodel();

            obj.totalproducts = totalprdcts.Count();
            obj.Sales = sales.Count();
            obj.Dilevery = dilivery.Count();
            obj.PendingOrders = pendingorder.ToList();

            return View(obj);
        }


        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Getusers()
        {
            var i = _userManager.Users.ToList();
            return View(i);
        }
    }
}
