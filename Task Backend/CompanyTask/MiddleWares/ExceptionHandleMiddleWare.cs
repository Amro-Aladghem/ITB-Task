using System.Text.Json;

namespace CompanyTask.MiddleWares
{
    public class ExceptionHandleMiddleWare
    {
        private readonly RequestDelegate _next;

        public ExceptionHandleMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                context.Response.StatusCode = 500; 
                context.Response.ContentType = "application/json";

                var response = new
                {
                    message = "Server Error, Failed to process!"
                };


                var json = JsonSerializer.Serialize(response);

                await context.Response.WriteAsync(json);
            }
        }
    }
}
