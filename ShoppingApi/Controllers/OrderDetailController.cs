using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingDal;
using Microsoft.Extensions.Configuration;
using ShoppingApp;

namespace ShoppingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        OrderDetailDataAccess da;
        // InstituteDataAccess dal;
        public OrderDetailController(OrderDetailDataAccess dataAccess)
        {
            da = dataAccess;
            // dal = new ProjectsDAL(configuration.GetConnectionString("ProjectsDbConnection"));
        }

        [HttpGet]
        //URL:  api/Admins
        public IActionResult Get()
        {
            return Ok(da.GetAllOrderDetails());
        }

        [HttpGet("{orderid}")]
        //URL:  api/employees
        public IActionResult Get(int orderid)
        {
            return Ok(da.GetOrderDetailById(orderid));
        }


        /*[HttpPost]
        //URL:  api/Admins
        public IActionResult CreateProduct(Product model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            da.AddNewProduct(model);
            return Ok(model);
        }*/
        

    }
}
