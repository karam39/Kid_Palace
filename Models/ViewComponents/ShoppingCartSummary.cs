
using Kid_PalaceA2.Models.ViewModels;
using Kid_PalaceA2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kid_PalaceA2.Services;

namespace Kid_PalaceA2.Data.ViewComponents
{
    public class ShoppingCartSummary:ViewComponent
    {
        private readonly ShoppingCartService _shoppingCart;
        public ShoppingCartSummary(ShoppingCartService shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();

            return View(items.Count);
        }
    }
}
