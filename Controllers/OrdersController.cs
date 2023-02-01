using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
//using SLE_System.Models;
using System.Security.Claims;
using Kid_PalaceA2.Models;
using Kid_PalaceA2.Models.ViewModels;

using Kid_PalaceA2.Services;
using Microsoft.AspNetCore.Identity;

namespace Kid_PalaceA2.Controllers
{
    public class OrdersController : Controller
    {

        private readonly AppDbContext _db;
        private readonly ShoppingCartService _shoppingCart;
        private readonly IOrdersService _ordersService;



        public OrdersController(AppDbContext db, ShoppingCartService shoppingCart, IOrdersService ordersService)
        {
            _db = db;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                string b = User.Identity.Name.ToString();

                if ((b.Split('@')[0]) == "Admin786")
                {
                    var orderss = await _ordersService.GetOrders();
                    return View(orderss);
                }
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orders = await _ordersService.GetOrdersByUserIdAsync(userId);
            return View(orders);
        }

        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(response);
        }


        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _db.Products2.FirstOrDefaultAsync(n => n.Id == id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }

            return RedirectToAction(nameof(ShoppingCart));

        }

        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _db.Products2.FirstOrDefaultAsync(n => n.Id == id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public void AddRecievingAddress(RecievingAddress obj)
        {
            try
            {
                var items2 = _shoppingCart.GetShoppingCartItems();
                foreach (var item in items2)
                    obj.OrderId = item.Id;


                if (obj.Id == 0)
                {
                    _db.RecievingAddresses.Add(obj);
                    _db.SaveChanges();
                }
                else
                {
                    _db.Entry(obj).State = EntityState.Modified;
                    _db.SaveChanges();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<IActionResult> CompleteOrder(/*RegisterViewModel obj*/RecievingAddress obj)
        {

            List<RecievingAddress> list = new List<RecievingAddress>();
            list.Add(obj);
            var items = _shoppingCart.GetShoppingCartItems();

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var items2 = list;


            if (User.Identity.IsAuthenticated)
            {
                string userEmailAddress = User.Identity.Name.ToString();

                await _ordersService.StoreOrderAsync(items, items2, userId, userEmailAddress);

            }
            //else
            //{
            //    string userEmailAddress = "";
            //    await _ordersService.StoreOrderAsync(items,items2, userId, userEmailAddress);
            //}
            //if (items.Count == 0)
            //{
            //    return View("FalseMessage");

            //}
            await _shoppingCart.ClearShoppingCartAsync();

            return View("OrderStatusMessageshow");
        }


        public IActionResult CancelOrder(int Id, int status)
        {
            Order obj = new Order();
            List<Order> Orderstatuslist = new List<Order>() {
        new Order() { OrderstatusID = 1, Orderstatus = "Pending"} ,
        new Order() { OrderstatusID = 2, Orderstatus = "Processing"} ,
        new Order() { OrderstatusID = 3, Orderstatus = "Completed"} ,
        new Order() { OrderstatusID = 4, Orderstatus = "Cancelled"}
    };
            if (User.Identity.IsAuthenticated)
            {
                string b = User.Identity.Name.ToString();
                if ((b.Split('@')[0]) == "Admin786")
                {

                    var result2 = _db.Orders.SingleOrDefault(b => b.Id == Id);
                    if (result2 != null)
                    {

                        var re = Orderstatuslist.Where(s => s.OrderstatusID == status).Select(s => s.Orderstatus.ToString()).FirstOrDefault();
                        if (result2.Orderstatus == "Cancelled")
                        {
                            if (re != "Cancelled")
                            {
                                PrdquantitymanageforOther(Id);
                            }
                        }
                        if (re == "Cancelled")
                        {
                            PrdquantitymanageforCancel(Id);
                        }


                        result2.Orderstatus = re;

                        _db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
            }
            var result = _db.Orders.SingleOrDefault(b => b.Id == Id);
            if (result != null)
            {
                result.Orderstatus = "Cancelled";
                _db.SaveChanges();
                PrdquantitymanageforCancel(Id);
            }
            return RedirectToAction("Index");

        }

        public IActionResult Changeorderstatusfordashboard(int Id, int status)
        {
            Order obj = new Order();
            List<Order> Orderstatuslist = new List<Order>() {
        new Order() { OrderstatusID = 1, Orderstatus = "Pending"} ,
        new Order() { OrderstatusID = 2, Orderstatus = "Processing"} ,
        new Order() { OrderstatusID = 3, Orderstatus = "Completed"} ,
        new Order() { OrderstatusID = 4, Orderstatus = "Cancelled"}
    };
            if (User.Identity.IsAuthenticated)
            {
                string b = User.Identity.Name.ToString();
                if ((b.Split('@')[0]) == "Admin786")
                {

                    var result2 = _db.Orders.SingleOrDefault(b => b.Id == Id);
                    if (result2 != null)
                    {

                        var re = Orderstatuslist.Where(s => s.OrderstatusID == status).Select(s => s.Orderstatus.ToString()).FirstOrDefault();
                        if (result2.Orderstatus == "Cancelled")
                        {
                            if (re != "Cancelled")
                            {
                                PrdquantitymanageforOther(Id);
                            }
                        }
                        if (re == "Cancelled")
                        {
                            PrdquantitymanageforCancel(Id);
                        }


                        result2.Orderstatus = re;

                        _db.SaveChanges();
                    }
                    return RedirectToAction("AdminDashboard", "Home");
                }
            }
            var result = _db.Orders.SingleOrDefault(b => b.Id == Id);
            if (result != null)
            {
                result.Orderstatus = "Cancelled";
                _db.SaveChanges();
                PrdquantitymanageforCancel(Id);
            }
            return RedirectToAction("AdminDashboard", "Home");

        }

        public void PrdquantitymanageforCancel(int Id)
        {
            var ordritms = _db.OrderItems.Where(x => x.OrderId == Id).ToList();

            foreach (var it in ordritms)
            {
                var prdqnty = _db.Products2.Where(x => x.Id == it.ToyModelId).ToList();
                int q = 0;
                foreach (var qnty in prdqnty)
                {
                    q = qnty.PrdQuantity + it.Quantity;
                    qnty.PrdQuantity = q;
                    _db.SaveChanges();
                }
            }
        }
        public void PrdquantitymanageforOther(int Id)
        {
            var ordritms = _db.OrderItems.Where(x => x.OrderId == Id).ToList();

            foreach (var it in ordritms)
            {
                var prdqnty = _db.Products2.Where(x => x.Id == it.ToyModelId).ToList();
                int q = 0;
                foreach (var qnty in prdqnty)
                {
                    q = qnty.PrdQuantity - it.Quantity;
                    qnty.PrdQuantity = q;
                    _db.SaveChanges();
                }
            }
        }
        public async Task<IActionResult> Orderview(int Id)
        {
            var orderss = await _ordersService.GetOrdersByOrderidAsync(Id);
            var address = await _ordersService.GetAddressByUserIdAsync(Id);

            var date = _db.Orders.Where(x => x.Id == Id).ToList();
            Orderviewdata orderviewdata = new Orderviewdata();
            foreach (var d in date)
            {
                orderviewdata.orderdate = d.Date;
            }

            orderviewdata.Address = address.ToList();
            orderviewdata.Orderr = orderss.ToList();

            return View(orderviewdata);

        }
        public IActionResult CustomerAddress()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            if (items.Count == 0)
            {
                return View("AddProductsMessage");

            }
            return View();
        }
    }
}