using Azure;
using Forum.Core.Common.Exceptions;
using System.Net;

namespace Forum.API
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private Task HandleException(HttpContext context, Exception ex)
        {
            ApiResponse apiResponse = new();
            switch (ex)
            {
                case CommentNotFoundException exception:
                    apiResponse.Result = null;
                    apiResponse.IsSuccess = false;
                    apiResponse.StatusCode = Convert.ToInt32(HttpStatusCode.NotFound);
                    apiResponse.Message = exception.Message;
                    break;
                case TopicNotFoundException exception:
                    apiResponse.Result = null;
                    apiResponse.IsSuccess = false;
                    apiResponse.StatusCode = Convert.ToInt32(HttpStatusCode.NotFound);
                    apiResponse.Message = exception.Message;
                    break;
                case UserNotFoundException exception:
                    apiResponse.Result = null;
                    apiResponse.IsSuccess = false;
                    apiResponse.StatusCode = Convert.ToInt32(HttpStatusCode.NotFound);
                    apiResponse.Message = exception.Message;
                    break;
                case RegistrationFailureException exception:
                    apiResponse.Result = null;
                    apiResponse.IsSuccess = false;
                    apiResponse.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
                    apiResponse.Message = exception.Message;
                    break;
                case
                    UnauthorizedAccessException exception:
                    apiResponse.Result = null;
                    apiResponse.IsSuccess = false;
                    apiResponse.StatusCode = Convert.ToInt32(HttpStatusCode.Forbidden);
                    apiResponse.Message = exception.Message;
                    break;
                case
                    ArgumentNullException exception:
                    apiResponse.Result = null;
                    apiResponse.IsSuccess = false;
                    apiResponse.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
                    apiResponse.Message = exception.Message;
                    break;
                case
                    ArgumentOutOfRangeException exception:
                    apiResponse.Result = null;
                    apiResponse.IsSuccess = false;
                    apiResponse.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
                    apiResponse.Message = exception.Message;
                    break;
                case
                    Exception exception:
                    apiResponse.Result = null;
                    apiResponse.IsSuccess = false;
                    apiResponse.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);
                    apiResponse.Message = exception.Message;
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = apiResponse.StatusCode;

            return context.Response.WriteAsJsonAsync(apiResponse);
        }
    }
}
