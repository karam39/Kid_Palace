using Kid_PalaceA2.Services;
using Kid_PalaceA2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kid_PalaceA2.Services
{

    public interface IOrdersService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, List<RecievingAddress> items2, string userId, string userEmailAddress);
        Task<List<Order>> GetOrdersByUserIdAsync(string userId);
    
        Task<List<Order>> GetOrders();

        //Task<Order> CancelOrder(int Orderid);
        Task<List<OrderItem>> GetOrdersByOrderidAsync(int Orderid);
        Task<List<RecievingAddress>> GetAddressByUserIdAsync(int Orderid);
        //Task AddRecievingAddresses(List<RecievingAddress> items, Order orderr);
    }


    public class OrdersService : IOrdersService
    {
        private readonly AppDbContext _context;

        public OrdersService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrdersByUserIdAsync(string userId)
        {
            var orders = await _context.Orders.Include(n => n.OrderItems)/*.ThenInclude(n => n.ToyModel)*/.Where(n => n.UserId == userId).ToListAsync();

            return orders;


        }
        public async Task<List<Order>> GetOrders()
        {
            var orders = await _context.Orders.Include(n => n.OrderItems)/*.ThenInclude(n => n.ToyModel)*/.ToListAsync();
            return orders;


        }
        //public  Task<Order> CancelOrder(int Orderid)
        //{

        //    var result = _context.Orders.SingleOrDefault(b => b.Id == Orderid);
        //    if (result != null)
        //    {
        //        result.Orderstatus = "Cancelled";
        //        _context.SaveChanges();
        //    }
        //    return null;



        //}
        public async Task<List<OrderItem>> GetOrdersByOrderidAsync(int Orderid)
        {
            var orders = await (from s in _context.OrderItems where (s.OrderId == Orderid) select s).ToListAsync();

            return orders;


        }
        public async Task<List<RecievingAddress>> GetAddressByUserIdAsync(int Orderid)
        {
            var orders = await(from s in _context.RecievingAddresses where (s.OrderId == Orderid) select s).ToListAsync();

            return orders;
        }
        //public async Task AddRecievingAddresses(List<RecievingAddress> items2, Order orderr)
        //{

        //    foreach (var item in items)
        //    {
        //        var addressdetail = new RecievingAddress()
        //        {
        //            OrderId = orderr.Id,
        //            CustomerName = item.CustomerName,
        //            PhoneNo = item.PhoneNo,
        //            Address = item.Address,
        //            SpecialInstructions = item.SpecialInstructions

        //        };
        //        await _context.RecievingAddresses.AddAsync(addressdetail);
        //    }
        //    await _context.SaveChangesAsync();
        //}




        public async Task StoreOrderAsync(List<ShoppingCartItem> items, List<RecievingAddress> items2, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress,
                Orderstatus = "Pending",
                Date = DateTime.Now
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {

                var orderItem = new OrderItem()
                {
                    Quantity = item.Quantity,
                      ToyModelId = item.ToyModel.Id,
                    OrderId = order.Id,
                    Price = item.ToyModel.SalePrice,
                    ToyImg = item.ToyModel.ToyImg,
                    ToyName = item.ToyModel.ToyName
                   

                };
                PrdQuantityManage(orderItem.ToyModelId, orderItem.Quantity);
                await _context.OrderItems.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync();

            foreach (var item in items2)
            {
                var addressdetail = new RecievingAddress()
                {
                    OrderId = order.Id,
                    CustomerName = item.CustomerName,
                    PhoneNo = item.PhoneNo,
                    Address = item.Address,
                    SpecialInstructions = item.SpecialInstructions

                };
                await _context.RecievingAddresses.AddAsync(addressdetail);
            }
            await _context.SaveChangesAsync();
        }
        public void PrdQuantityManage(int Id, int qntit)
        {
            var prdqnty = _context.Products2.Where(x => x.Id == Id).ToList();
            int q = 0;
            foreach (var qnty in prdqnty)
            {
                q = qnty.PrdQuantity - qntit;
                qnty.PrdQuantity = q;
                _context.SaveChanges();
            }
        }

    }
}
