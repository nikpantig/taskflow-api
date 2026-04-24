using System.Net;
using System.Text.Json;
using FluentValidation;
using TaskFlow.API.Common;

namespace TaskFlow.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                await HandleValidationException(context, ex);
            }
            catch (Exception)
            {
                await HandleGenericException(context);
            }
        }

        private static async Task HandleValidationException(HttpContext context, ValidationException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";

            var response = new ApiErrorResponse
            {
                StatusCode = context.Response.StatusCode,
                Message = "Validation failed.",
                Errors = ex.Errors.Select(e => new ApiValidationError
                {
                    Field = e.PropertyName,
                    Error = e.ErrorMessage
                })
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        private static async Task HandleGenericException(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var response = new ApiErrorResponse
            {
                StatusCode = context.Response.StatusCode,
                Message = "Something went wrong."
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
