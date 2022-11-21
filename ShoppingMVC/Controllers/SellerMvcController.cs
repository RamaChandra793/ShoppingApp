using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingMVC.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using ShoppingApp;
using Microsoft.Extensions.Configuration;

namespace ShoppingMVC.Controllers
{
    public class SellerMvcController : Controller
    {
        private readonly ILogger<SellerMvcController> _logger;
        private IConfiguration configuration;
        public SellerMvcController(ILogger<SellerMvcController> logger, IConfiguration config)
        {
            _logger = logger;
            configuration = config;
        }

        public async Task<IActionResult> Index()
        {

            var model = await this.GetResponseFromApi<IEnumerable<Seller>>(
                baseUri: configuration.GetConnectionString("SellerApiUrl"),
                requestUrl: "api/Seller");

            return View(model);
        }
        public IActionResult Create()
        {
            return View();


        }
        [HttpPost]
        public IActionResult Create(Seller seller)
        {

            var model = this.SendDataToApi<Seller, Seller>(
          baseUri: configuration.GetConnectionString("SellerApiUrl"),
          requestUrl: $"api/Seller", seller);


            return RedirectToAction($"Index");
        }
        public IActionResult Edit()
        {
            return View();


        }
        [HttpPut]
        public IActionResult Edit(Seller seller)
        {
            var model = this.SendDataToApi<Seller, Seller>(
          baseUri: configuration.GetConnectionString("SellerApiUrl"),
          requestUrl: $"api/Seller/update/{seller.SellerId}", seller);


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
