using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPS.Data.Models;
using SPS.Services.Interface;
using SPS.Services.Services;
using System.Net;

namespace SPS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public IActionResult GetCategory()
        {
            var responseData = _categoryService.GetCategory();
            return Ok(responseData);
        }


    }
}
