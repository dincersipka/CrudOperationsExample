using COE.Application.Abstractions.Wrappers;
using COE.Application.Exceptions;
using COE.Application.Wrappers;
using Newtonsoft.Json;
using System.Net;

namespace COE.WebApi.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate Next;
        public GlobalExceptionMiddleware(RequestDelegate _Next)
        {
            Next = _Next;
        }
        public async Task InvokeAsync(HttpContext Context)
        {
            try
            {
                await Next(Context);
            }
            catch (UserNotFoundException Ex)
            {
                await HandleExceptionAsync(Context, Ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext Context, Exception Exception)
        {
            Context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            Context.Response.ContentType = "application/json";

            IServiceResponse Response = new ErrorResponse(Exception);

            await Context.Response.WriteAsync(JsonConvert.SerializeObject(Response));
        }
    }
}
