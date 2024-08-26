using Microsoft.AspNetCore.Mvc;
using ST10390916CLDVPOE.Models;

namespace ST10390916CLDVPOE.Controllers
{
    public class CustomerController : Controller
    {

        private readonly TableService _tableService;
        private readonly FileService _fileService;

        public CustomerController(TableService tableService, FileService fileService)
        {
            _tableService = tableService;
            _fileService = fileService;
        }

        public IActionResult Customer()
        {
            return View();
        }

        //add customer to customer table
        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                await _tableService.AddEntityAsync(customer);
            }
            return RedirectToAction("Customer");
        }

        //upload contract to file share
        [HttpPost]
        public async Task<IActionResult> UploadContract(IFormFile file)
        {
            if (file != null)
            {
                using var stream = file.OpenReadStream();
                await _fileService.UploadFileAsync("contracts", file.FileName, stream);
            }
            return RedirectToAction("Customer");
        }

    }
}
