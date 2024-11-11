using Microsoft.AspNetCore.Mvc;
using ST10390916CLDVPOE.Models;

namespace ST10390916CLDVPOE.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Products()
        {
            return View();
        }

        public IActionResult Orders()
        {
            return View();
        }

        //add product to product table
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product) //async task can run in background
        {
            product.InsertProduct(product);

            return RedirectToAction("Products");
        }

        //add new order to sql database
        [HttpPost]
        public async Task<IActionResult> ProcessOrder(Order order)
        {
            order.Message = $"Order {order.OrderID} was processed";
            order.InsertOrder(order);

            return RedirectToAction("Products");
        }

        //poe part 2 code that is deleted
        //add product image to blob
        [HttpPost]
        public async Task<IActionResult> UploadImage()
        {
            return RedirectToAction("Products");
        }

    }
}
