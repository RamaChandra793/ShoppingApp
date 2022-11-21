using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingMVC.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using ShoppingApp;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace ShoppingMVC.Controllers
{

    [Authorize]
    public class ProductMvcController : Controller
    {
        private readonly ILogger<ProductMvcController> _logger;
        private IConfiguration configuration;
        public ProductMvcController(ILogger<ProductMvcController> logger, IConfiguration config)
        {
            _logger = logger;
            configuration = config;
        }

        public async Task<IActionResult> Index()
        {

            var model = await this.GetResponseFromApi<IEnumerable<Product>>(
                baseUri: configuration.GetConnectionString("ProductApiUrl"),
                requestUrl: "api/Product");

            return View(model);
        }
        public IActionResult Create()
        {
            return View();


        }
        [HttpPost]
        public IActionResult Create(Product product)
        {

            var model = this.SendDataToApi<Product, Product>(
          baseUri: configuration.GetConnectionString("ProductApiUrl"),
          requestUrl: $"api/Product", product);


            return RedirectToAction($"Index");
        }
        public async Task<IActionResult> GetProductByID(int id)
        {
            var model = await this.GetResponseFromApi<Product>(
            baseUri: configuration.GetConnectionString("ProductApiUrl"),
            requestUrl: $"/api/Product/{id}");
            return View(model);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var model = await this.GetResponseFromApi<Product>(
            baseUri: configuration.GetConnectionString("ProductApiUrl"),
            requestUrl: $"/api/Product/{id}");
            return View(model);

        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            var model = this.SendDataToApi<Product, Product>(
          baseUri: configuration.GetConnectionString("ProductApiUrl"),
          requestUrl: $"api/Product/update/{product.ProductId}", product);


            return RedirectToAction($"Index");
        }





        public IActionResult Delete()
        {
            return View();


        }
        [HttpPost]
        public IActionResult Delete(Product product)
        {

            var model = this.SendDataToApi<Product, Product>(
          baseUri: configuration.GetConnectionString("ProductApiUrl"),
          requestUrl: $"api/Product/remove", product);


            return RedirectToAction($"Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
