using DEVinCar.Service.DTOs;
using DEVinCar.Service.Exceptions;
using System.Net;

namespace DEVinCar.Controller.Config
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(Exception ex)
            {
                await ExceptionTreatment(httpContext, ex);
            }
        }

        private Task ExceptionTreatment(HttpContext context, Exception exception)
        {
            HttpStatusCode status;
            string message;

            switch (exception)
            {
                case ObjectNotFoundException:
                    status = HttpStatusCode.NotFound;
                    message = exception.Message;
                    break;
                default:
                    status = HttpStatusCode.InternalServerError;
                    message = "An internal error ocurred. Please contact IT";
                    break;
            }

            ErrorDTO response = new(message);
            context.Response.StatusCode = (int)status;
            return context.Response.WriteAsJsonAsync(response);
        }
    }
}
