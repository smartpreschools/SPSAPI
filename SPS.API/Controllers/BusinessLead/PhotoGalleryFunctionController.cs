
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPS.Data.Models;
using SPS.Repository.Interface;
using SPS.Services.Interface;
using SPS.Services.Services;

namespace SPS.API.Controllers
{

    [ApiController]
    public class PhotoGallaryFunctionController : ControllerBase
    {
        private readonly IPhotoGallaryFunctionService _photoGallaryFunctionService;
        public PhotoGallaryFunctionController(IPhotoGallaryFunctionService photoGallaryFunctionService)
        {

            _photoGallaryFunctionService = photoGallaryFunctionService;
        }
        [Route("api/PhotoGallaryFunction/GetPhotoGallaryFunction")]
        [HttpGet]
        public IActionResult GetPhotoGallaryFunction()
        {
            var responseData = _photoGallaryFunctionService.GetPhotoGallaryFunction();
            if (responseData == null)
                return NoContent();
            else
                return Ok(responseData);
        }
        [Route("api/PhotoGallaryFunction/GetPhotoGallaryFunctionById")]
        [HttpGet]
        public IActionResult GetPhotoGallaryFunctionById(int photoGallaryFunctionId)
        {
            if (photoGallaryFunctionId != 0)
            {
                var responseData = _photoGallaryFunctionService.GetPhotoGallaryFunction();
                return Ok(responseData);
            }
            else
                return BadRequest();
        }
        [Route("api/PhotoGallaryFunction/PostPhotoGallaryFunction")]
        [HttpPost]
        public IActionResult PostPhotoGallaryFunction(PhotoGallaryFunction photoGallaryFunction)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            else
            {
                var responseData = _photoGallaryFunctionService.Add(photoGallaryFunction);
                return Ok(responseData);
            }
        }
        [Route("api/PhotoGallaryFunction/PutPhotoGallaryFunction")]
        [HttpPut]
        public IActionResult PutPhotoGallaryFunction(PhotoGallaryFunction photoGallaryFunction, int photoGallaryFunctionId)
        {
            if (!ModelState.IsValid && photoGallaryFunctionId != 0)
                return BadRequest(ModelState);
            else
            {
                var responseData = _photoGallaryFunctionService.Edit(photoGallaryFunctionId, photoGallaryFunction);
                return Ok(responseData);
            }
        }
        [Route("api/PhotoGallaryFunction/DeletePhotoGallaryFunction")]
        [HttpDelete]
        public IActionResult DeletePhotoGallaryFunction(int photoGallaryFunctionId)
        {
            if (photoGallaryFunctionId == 0)
                return BadRequest();
            else
            {
                var responseData = _photoGallaryFunctionService.Delete(photoGallaryFunctionId);
                return Ok(responseData);
            }
        }
    }
}
