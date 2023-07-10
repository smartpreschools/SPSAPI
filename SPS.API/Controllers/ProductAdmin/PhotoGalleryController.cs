using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPS.Data.Models;
using SPS.Services.Interface;

namespace SPS.API.Controllers.ProductAdmin
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoGalleryController : ControllerBase
    {
        private readonly IPhotoGalleryService _photoGallaryService;
        public PhotoGalleryController(IPhotoGalleryService _photoGallaryService)
        {
            _photoGallaryService = _photoGallaryService;
        }
        [Route("api/PhotoGallaryFunction/GetPhotoGallaryFunction")]
        [HttpGet]
        public IActionResult GetPhotoGallaryFunction()
        {
            var responseData = _photoGallaryService.GetPhotoGalleryFunction();
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
                var responseData = _photoGallaryService.GetPhotoGalleryFunction();
                return Ok(responseData);
            }
            else
                return BadRequest();
        }
        [Route("api/PhotoGallaryFunction/PostPhotoGallaryFunction")]
        [HttpPost]
        public IActionResult PostPhotoGallaryFunction(PhotoGalleryFunction photoGallaryFunction, int subscriberMasterId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            else
            {
                var responseData = _photoGallaryService.Add(photoGallaryFunction, subscriberMasterId);
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
