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
    public class ProductController : ControllerBase
    {
        ProductDataAccess da;
        // InstituteDataAccess dal;
        public ProductController(ProductDataAccess dataAccess)
        {
            da = dataAccess;

        }

        [HttpGet]
        //URL:  api/Admins
        public IActionResult Get()
        {
            return Ok(da.GetAllProducts());
        }

        [HttpGet("{productid}")]
        //URL:  api/employees
        public IActionResult Get(int productid)
        {
            return Ok(da.GetProductById(productid));
        }



        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            da.AddNewProduct(product);
            return Ok(product);
        }


        [HttpPut("update/{productid}")]
        public IActionResult UpdateProduct(int productid, Product product)
        {
            if (product == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                da.UpdateProduct(product);
            }
            catch (Exception ex)
            {
                //return Redirect("/error-development");
                throw;
            }
            return Ok();
        }



        [HttpDelete("remove/{productid}")]



        public IActionResult RemoveProduct(int productid)
        {
            da.RemoveProduct(productid);
            return Ok();
        }



    }
}
