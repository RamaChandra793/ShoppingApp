using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp;
using ShoppingDal;
using Microsoft.Extensions.Configuration;
using System;

namespace ShoppingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        CustomerDataAccess da;
        // InstituteDataAccess dal;
        public CustomerController(CustomerDataAccess dataAccess)
        {
            da = dataAccess;
            // dal = new P rojectsDAL(configuration.GetConnectionString("ProjectsDbConnection"));
        }

        [HttpGet]
        //URL:  api/Admins
        public IActionResult Get()
        {
            return Ok(da.GetAllCustomers());
        }

        [HttpGet("{CustomerId}")]
        //URL:  api/employees
        public IActionResult Get(int CustomerId)
        {
            return Ok(da.GetCustomerById(CustomerId));
        }


        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            da.AddNewCustomer(customer);
            return Ok(customer);
        }


        [HttpPut("update/{customerid}")]
        public IActionResult UpdateCustomer(int customerid, Customer customer)
        {
            if (customer == null)
                return BadRequest();



            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                da.UpdateCustomer(customer);
            }
            catch (Exception ex)
            {
                //return Redirect("/error-development");
                throw;
            }
            return Ok();
        }

    }
}
