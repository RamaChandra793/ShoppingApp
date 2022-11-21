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
    public class CategoryController : ControllerBase
    {
        CategoryDataAccess da;
        // InstituteDataAccess dal;
        public CategoryController(CategoryDataAccess dataAccess)
        {
            da = dataAccess;
            // dal = new ProjectsDAL(configuration.GetConnectionString("ProjectsDbConnection"));
        }

        [HttpGet]
        //URL:  api/Admins
        public IActionResult Get()
        {
            return Ok(da.GetAllCategories());
        }

        [HttpGet("{categoryid}")]
        //URL:  api/employees
        public IActionResult Get(int categoryid)
        {
            return Ok(da.GetCategoryById(categoryid));
        }


        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            da.AddNewCategory(category);
            return Ok(category);
        }


        [HttpPut("update/{categoryid}")]
        public IActionResult UpdateCategory(int categoryid, Category category)
        {
            if (category == null)
                return BadRequest();



            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                da.UpdateCategory(category);
            }
            catch (Exception ex)
            {
                //return Redirect("/error-development");
                throw;
            }
            return Ok();
        }



        [HttpDelete("remove/{categoryid}")]



        public IActionResult RemoveCategory(int categoryid)
        {
            da.RemoveCategory(categoryid);
            return Ok();
        }


    }
}
