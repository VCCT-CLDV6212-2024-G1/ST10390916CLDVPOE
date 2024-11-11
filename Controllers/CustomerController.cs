using Microsoft.AspNetCore.Mvc;
using ST10390916CLDVPOE.Models;

namespace ST10390916CLDVPOE.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Customer()
        {
            return View();
        }

        //add customer to sql database table
        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customer customer)
        {
            customer.InsertCustomer(customer);
            
            return RedirectToAction("Customer");
        }

        //poe part 2 code that is deleted
        //upload contract to file share
        [HttpPost]
        public async Task<IActionResult> UploadContract()
        {
            return RedirectToAction("Customer");
        }

    }
}
