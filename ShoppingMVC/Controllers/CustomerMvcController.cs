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

    public class CustomerMvcController : Controller
    {
        private readonly ILogger<CustomerMvcController> _logger;
        private IConfiguration configuration;
        public CustomerMvcController(ILogger<CustomerMvcController> logger, IConfiguration config)
        {
            _logger = logger;
            configuration = config;
        }

        public async Task<IActionResult> Index()
        {

            var model = await this.GetResponseFromApi<IEnumerable<Customer>>(
                baseUri: configuration.GetConnectionString("CustomerApiUrl"),
                requestUrl: "api/Customer");

            return View(model);
        }
        public IActionResult Create()
        {
            return View();


        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {



            var model = this.SendDataToApi<Customer, Customer>(
          baseUri: configuration.GetConnectionString("CustomerApiUrl"),
          requestUrl: $"api/Customer", customer);


            return RedirectToAction($"Index");
        }
        public IActionResult Edit()
        {
            return View();


        }
        [HttpPut]
        public IActionResult Edit(Customer customer)
        {
            var model = this.SendDataToApi<Customer, Customer>(
          baseUri: configuration.GetConnectionString("CustomerApiUrl"),
          requestUrl: $"api/Customer/update/{customer.CustomerId}", customer);


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
