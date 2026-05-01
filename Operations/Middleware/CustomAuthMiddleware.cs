using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Operations.Middleware
{
    public class CustomAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Ejemplo simple
            Console.WriteLine("Middleware ejecutándose");

            await _next(context);
        }
    }
}
