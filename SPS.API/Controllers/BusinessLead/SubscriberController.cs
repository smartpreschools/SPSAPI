using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPS.Data.Models;
using SPS.Repository.Interface;
using SPS.Services.Interface;
using SPS.Services.Services;

namespace SPS.API.Controllers
{
    
    [ApiController]
    public class SubscriberController : ControllerBase
    {
        private readonly ISubscriberService _subscriberService;
        public SubscriberController(ISubscriberService subscriberService)
        {

            _subscriberService = subscriberService;
        }
        [Route("api/Subscriber/GetSubscriber")]
        [HttpGet]
        public IActionResult GetSubscriber()
        {
            var responseData = _subscriberService.GetSubscriber();
            if (responseData == null)
                return NoContent();
            else
                return Ok(responseData);
        }
        [Route("api/Subscriber/GetSubscriberById")]
        [HttpGet]
        public IActionResult GetSubscriberById(int subscriberId)
        {
            if (subscriberId != 0)
            {
                var responseData = _subscriberService.GetSubscriber();
                return Ok(responseData);
            }
            else
                return BadRequest();
        }
        [Route("api/Subscriber/PostSubscriber")]
        [HttpPost]
        public IActionResult PostSubscriber(Subscriber subscriber)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            else
            {
                var responseData = _subscriberService.Add(subscriber);
                return Ok(responseData);
            }
        }
        [Route("api/Subscriber/PutSubscriber")]
        [HttpPut]
        public IActionResult PutSubscriber(Subscriber subscriber, int subscriberId)
        {
            if (!ModelState.IsValid && subscriberId != 0)
                return BadRequest(ModelState);
            else
            {
                var responseData = _subscriberService.Edit(subscriberId, subscriber);
                return Ok(responseData);
            }
        }
    }
}
