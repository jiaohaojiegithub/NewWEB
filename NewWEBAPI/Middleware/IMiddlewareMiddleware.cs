using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using NewWEBAPI.Models;

namespace NewWEBAPI.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class IMiddlewareMiddleware: IMiddleware
    {
        private readonly NewWEBContext _next;

        public IMiddlewareMiddleware(NewWEBContext next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var keyValue = context.Request.Query["key"];
            if (!string.IsNullOrWhiteSpace(keyValue))
            {
               // _next.
            }
            await next(context);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    //public static class IMiddlewareMiddlewareExtensions
    //{
    //    public static IApplicationBuilder UseConventionalMiddleware(
    //       this IApplicationBuilder builder)
    //    {
    //        return builder.UseMiddleware<ConventionalMiddleware>();
    //    }

    //    public static IApplicationBuilder UseIMiddlewareMiddleware(
    //        this IApplicationBuilder builder)
    //    {
    //        return builder.UseMiddleware<IMiddlewareMiddleware>();
    //    }
    //}
}
