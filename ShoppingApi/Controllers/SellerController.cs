using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingDal;
using Microsoft.Extensions.Configuration;
using ShoppingApp;
using System;

namespace ShoppingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        SellerDataAccess da;
        // InstituteDataAccess dal;
        public SellerController(SellerDataAccess dataAccess)
        {
            da = dataAccess;
            // dal = new P rojectsDAL(configuration.GetConnectionString("ProjectsDbConnection"));
        }

        [HttpGet]
        //URL:  api/Admins
        public IActionResult Get()
        {
            return Ok(da.GetAllSellers());
        }

        [HttpGet("{sellerid}")]
        //URL:  api/employees
        public IActionResult Get(int sellerid)
        {
            return Ok(da.GetSellerById(sellerid));
        }


        [HttpPost]
        public IActionResult AddSeller(Seller seller)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            da.AddNewSeller(seller);
            return Ok(seller);
        }


        [HttpPut("update/{sellerid}")]
        public IActionResult UpdateSeller(int sellerid, Seller seller)
        {
            if (seller == null)
                return BadRequest();



            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                da.UpdateSeller(seller);
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
