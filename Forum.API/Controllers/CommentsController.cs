using Forum.Application.DTOs;
using Forum.Application.Interfaces;
using Forum.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Forum.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private ApiResponse _response;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
            _response = new();
        }

        [HttpGet("/comments")]
        public async Task<IActionResult> AllCommentsOfTopic(int topicId)
        {
            var result = await _commentService.GetAllCommentsOfTopicAsync(topicId);
            _response.Result = result;
            _response.IsSuccess = true;
            _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            _response.Message = "Request completed successfully";

            return StatusCode(_response.StatusCode, _response);
        }

        [HttpGet("/comments/{id}")]
        public async Task<IActionResult> TodoById(int id)
        {
            var result = await _commentService.GetSingleCommentAsync(id);
            _response.Result = result;
            _response.IsSuccess = true;
            _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            _response.Message = "Request completed successfully";

            return StatusCode(_response.StatusCode, _response);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddComment(CommentForCreatingDTO model)
        {
            await _commentService.AddCommentAsync(model);
            _response.Result = model;
            _response.IsSuccess = true;
            _response.StatusCode = Convert.ToInt32(HttpStatusCode.Created);
            _response.Message = "Request completed successfully";

            return StatusCode(_response.StatusCode, _response);
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteComment(int id)
        {
            await _commentService.DeleteCommentAsync(id);
            _response.Result = id;
            _response.IsSuccess = true;
            _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            _response.Message = "Comment deleted successfully";


            return StatusCode(_response.StatusCode, _response);
        }
    }
}
