
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
        private readonly IPhotoGalleryService _photoGallaryService;
        public PhotoGallaryFunctionController(IPhotoGalleryService _photoGallaryService)
        {
            _photoGallaryService = _photoGallaryService;
        }
        [Route("api/PhotoGallaryFunction/GetPhotoGallaryFunction")]
        [HttpGet]
        public IActionResult GetPhotoGallaryFunction()
        {
            var responseData = _photoGallaryService.GetPhotoGallaryFunction();
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
                var responseData = _photoGallaryService.GetPhotoGallaryFunction();
                return Ok(responseData);
            }
            else
                return BadRequest();
        }
        [Route("api/PhotoGallaryFunction/PostPhotoGallaryFunction")]
        [HttpPost]
        public IActionResult PostPhotoGallaryFunction(PhotoGalleryFunction photoGallaryFunction)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            else
            {
                var responseData = _photoGallaryService.Add(photoGallaryFunction);
                return Ok(responseData);
            }
        }
        [Route("api/PhotoGallaryFunction/PutPhotoGallaryFunction")]
        [HttpPut]
        public IActionResult PutPhotoGallaryFunction(PhotoGalleryFunction photoGallaryFunction, int photoGallaryFunctionId)
        {
            if (!ModelState.IsValid && photoGallaryFunctionId != 0)
                return BadRequest(ModelState);
            else
            {
                var responseData = _photoGallaryService.Edit(photoGallaryFunctionId, photoGallaryFunction);
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
                var responseData = _photoGallaryService.Delete(photoGallaryFunctionId);
                return Ok(responseData);
            }
        }
    }
}
