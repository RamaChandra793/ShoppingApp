using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp;
using ShoppingDal;
using Microsoft.Extensions.Configuration;

namespace ShoppingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        OrderDataAccess da;
        // InstituteDataAccess dal;
        public OrderController(OrderDataAccess dataAccess)
        {
            da = dataAccess;
            // dal = new P rojectsDAL(configuration.GetConnectionString("ProjectsDbConnection"));
        }

        [HttpGet]
        //URL:  api/Admins
        public IActionResult Get()
        {
            return Ok(da.GetAllOrders());
        }

        [HttpGet("{orderid}")]
        //URL:  api/employees
        public IActionResult Get(int orderid)
        {
            return Ok(da.GetOrderById(orderid));
        }

        [HttpPost]
        //URL:  api/Admins
        [HttpPost]
        public IActionResult AddOrder(Order order)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            da.AddNewOrder(order);
            return Ok(order);
        }

        [HttpDelete("remove/{orderid}")]



        public IActionResult CancelOrder(int orderid)
        {
            da.CancelOrder(orderid);
            return Ok();
        }
    }
}
