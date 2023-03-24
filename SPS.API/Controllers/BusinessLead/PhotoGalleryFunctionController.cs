
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPS.Data.Models;
using SPS.Repository.Interface;
using SPS.Services.Interface;
using SPS.Services.Services;

namespace SPS.API.Controllers
{

    [ApiController]
    public class PhotoGalleryFunctionController : ControllerBase
    {
        private readonly IPhotoGalleryFunctionService _photoGalleryFunctionService;
        public PhotoGalleryFunctionController(IPhotoGalleryFunctionService photoGalleryFunctionService)
        {

            _photoGalleryFunctionService = photoGalleryFunctionService;
        }
        [Route("api/PhotoGalleryFunction/GetPhotoGalleryFunction")]
        [HttpGet]
        public IActionResult GetPhotoGalleryFunction()
        {
            var responseData = _photoGalleryFunctionService.GetPhotoGalleryFunction();
            if (responseData == null)
                return NoContent();
            else
                return Ok(responseData);
        }
        [Route("api/PhotoGalleryFunction/GetPhotoGalleryFunctionById")]
        [HttpGet]
        public IActionResult GetPhotoGalleryFunctionById(int photoGalleryFunctionId)
        {
            if (photoGalleryFunctionId != 0)
            {
                var responseData = _photoGalleryFunctionService.GetPhotoGalleryFunction();
                return Ok(responseData);
            }
            else
                return BadRequest();
        }
        [Route("api/PhotoGalleryFunction/PostPhotoGalleryFunction")]
        [HttpPost]
        public IActionResult PostPhotoGalleryFunction(PhotoGalleryFunction photoGalleryFunction,int subscriberMasterId)
        {
            if (!ModelState.IsValid && subscriberMasterId !=0)
                return BadRequest(ModelState);
            else
            {
                var responseData = _photoGalleryFunctionService.Add(photoGalleryFunction, subscriberMasterId);
                return Ok(responseData);
            }
        }
        [Route("api/PhotoGalleryFunction/PutPhotoGalleryFunction")]
        [HttpPut]
        public IActionResult PutPhotoGalleryFunction(PhotoGalleryFunction photoGalleryFunction, int photoGalleryFunctionId)
        {
            if (!ModelState.IsValid && photoGalleryFunctionId != 0)
                return BadRequest(ModelState);
            else
            {
                var responseData = _photoGalleryFunctionService.Edit(photoGalleryFunctionId, photoGalleryFunction);
                return Ok(responseData);
            }
        }
        [Route("api/PhotoGalleryFunction/DeletePhotoGalleryFunction")]
        [HttpDelete]
        public IActionResult DeletePhotoGalleryFunction(int photoGalleryFunctionId)
        {
            if (photoGalleryFunctionId == 0)
                return BadRequest();
            else
            {
                var responseData = _photoGalleryFunctionService.Delete(photoGalleryFunctionId);
                return Ok(responseData);
            }
        }
    }
}
