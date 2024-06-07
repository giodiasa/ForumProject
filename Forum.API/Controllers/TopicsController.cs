using Forum.Application.DTOs;
using Forum.Application.Interfaces;
using Forum.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Forum.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        private readonly ITopicService _topicService;
        private ApiResponse _response;

        public TopicsController(ITopicService topicService)
        {
            _topicService = topicService;
            _response = new();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTopics()
        {
            var result = await _topicService.GetAllTopicsAsync();
            _response.Result = result;
            _response.IsSuccess = true;
            _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            _response.Message = "Request completed successfully";

            return StatusCode(_response.StatusCode, _response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> TopicById(int id)
        {
            var result = await _topicService.GetSingleTopicAsync(id);
            _response.Result = result;
            _response.IsSuccess = true;
            _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            _response.Message = "Request completed successfully";

            return StatusCode(_response.StatusCode, _response);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddTopic([FromForm]TopicForCreatingDTO model)
        {
            await _topicService.AddTopicAsync(model);
            _response.Result = model;
            _response.IsSuccess = true;
            _response.StatusCode = Convert.ToInt32(HttpStatusCode.Created);
            _response.Message = "Request completed successfully";

            return StatusCode(_response.StatusCode, _response);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteTopic(int id)
        {
            await _topicService.DeleteTopicAsync(id);
            _response.Result = id;
            _response.IsSuccess = true;
            _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            _response.Message = "Topic deleted successfully";

            return StatusCode(_response.StatusCode, _response);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateTopic([FromForm]TopicForUpdatingDTO model)
        {
            await _topicService.UpdateTopicAsync(model);
            _response.Result = model;
            _response.IsSuccess = true;
            _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            _response.Message = "Topic updated successfully";


            return StatusCode(_response.StatusCode, _response);
        }
    }
}
