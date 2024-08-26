using Microsoft.AspNetCore.Mvc;
using ST10390916CLDVPOE.Models;

namespace ST10390916CLDVPOE.Controllers
{
    public class ProductController : Controller
    {

        private readonly BlobService _blobService;
        private readonly TableService _tableService;
        private readonly QueueService _queueService;

        public ProductController(BlobService blobService, TableService tableService, QueueService queueService)
        {
            _blobService = blobService;
            _tableService = tableService;
            _queueService = queueService;
        }

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
            if (ModelState.IsValid)
            {
                await _tableService.AddEntityAsync(product); ///await - UI stays responsive
            }
            return RedirectToAction("Products");
        }

        //add product image to blob
        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file != null)
            {
                using var stream = file.OpenReadStream();
                await _blobService.UploadBlobAsync("images", file.FileName, stream);
            }
            return RedirectToAction("Products");
        }

        //send string to Azure Queue
        [HttpPost]
        public async Task<IActionResult> ProcessOrder(string orderId)
        {
            await _queueService.SendMessageAsync("order-processing", $"Processing order {orderId}");
            return RedirectToAction("Products");
        }

    }
}
