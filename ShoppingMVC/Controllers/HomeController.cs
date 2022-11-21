using Microsoft.AspNetCore.Mvc;

namespace ShoppingMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
