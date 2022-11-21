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
    public class CategoryMvcController : Controller
    {
        private readonly ILogger<CategoryMvcController> _logger;
        private IConfiguration configuration;
        public CategoryMvcController(ILogger<CategoryMvcController> logger, IConfiguration config)
        {
            _logger = logger;
            configuration = config;
        }

        public async Task<IActionResult> Index()
        {

            var model = await this.GetResponseFromApi<IEnumerable<Category>>(
                baseUri: configuration.GetConnectionString("CategoryApiUrl"),
                requestUrl: "api/Category");

            return View(model);
        }
        public IActionResult Create()
        {
            return View();


        }
        [HttpPost]
        public IActionResult Create(Category category)
        {



            var model = this.SendDataToApi<Category, Category>(
          baseUri: configuration.GetConnectionString("CategoryApiUrl"),
          requestUrl: $"api/Category", category);


            return RedirectToAction($"Index");
        }
        public IActionResult Edit()
        {
            return View();


        }
        [HttpPut]
        public IActionResult Edit(Category category)
        {
            var model = this.SendDataToApi<Category, Category>(
          baseUri: configuration.GetConnectionString("CategoryApiUrl"),
          requestUrl: $"api/Category/update/{category.CategoryId}", category);


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
