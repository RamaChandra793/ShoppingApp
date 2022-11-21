using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingMVC.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using ShoppingApp;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace ShoppingMVC.Controllers
{
    [Authorize]
    public class OrderMvcController : Controller
    {
        private readonly ILogger<OrderMvcController> _logger;
        private IConfiguration configuration;
        public OrderMvcController(ILogger<OrderMvcController> logger, IConfiguration config)
        {
            _logger = logger;
            configuration = config;
        }

        public async Task<IActionResult> Index()
        {

            var model = await this.GetResponseFromApi<IEnumerable<Order>>(
                baseUri: configuration.GetConnectionString("OrderApiUrl"),
                requestUrl: "api/Order");

            return View(model);
        }
        public IActionResult Create()
        {
            return View();


        }
        [HttpPost]
        public IActionResult Create(Order order)
        {



            var model = this.SendDataToApi<Order, Order>(
          baseUri: configuration.GetConnectionString("OrderApiUrl"),
          requestUrl: $"api/Order", order);


            return RedirectToAction($"Index");
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return View();
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
