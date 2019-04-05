using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SSGeek.Web.DAL;
using SSGeek.Web.Models;

namespace SSGeek.Web.Controllers
{
    public class StoreController : Controller
    {
        private ProductSqlDAL productSqlDAL;

        public StoreController(ProductSqlDAL productSqlDAL)
        {
            this.productSqlDAL = productSqlDAL;
        }

        public IActionResult Index()
        {
            List<Product> products = productSqlDAL.GetProducts();
            
            return View(products);
        }

        public IActionResult Detail(int id)
        {
            Product product = productSqlDAL.GetProduct(id);

            return View(product);
        } 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddToCart(Product product, int quantity)
        {
            product = productSqlDAL.GetProduct(product.ProductId);

            ShoppingCart cart = GetActiveShoppingCart();
            cart.AddToCart(product, quantity);

            SaveActiveShoppingCart(cart);

            return RedirectToAction("ViewCart");
        }

        public IActionResult ViewCart()
        {
            ShoppingCart cart = GetActiveShoppingCart();
            return View(cart);
        }

        private ShoppingCart GetActiveShoppingCart()
        {
            ShoppingCart cart = null;

            if (HttpContext.Session.GetString("Shopping_Cart") == null)
            {
                cart = new ShoppingCart();
                
                SaveActiveShoppingCart(cart);
            }
            else
            {
                string shopping_cart_string = HttpContext.Session.GetString("Shopping_Cart");
                cart = JsonConvert.DeserializeObject<ShoppingCart>(shopping_cart_string);
            }

            return cart;
        }

        private void SaveActiveShoppingCart(ShoppingCart cart)
        {
            string shopping_cart_string = JsonConvert.SerializeObject(cart);
            HttpContext.Session.SetString("Shopping_Cart", shopping_cart_string);
        }
    }
}