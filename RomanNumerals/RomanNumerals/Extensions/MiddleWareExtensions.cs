using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using RomanNumerals.Models;

namespace RomanNumerals.Extensions
{
    public static class MiddleWareExtensions
    {
        public static void UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        string err = new ErrorDetails()
                            {
                                StatusCode = context.Response.StatusCode,
                                Message = "An internal error occurred"
                            }.ToString();
                        // In a real app we'd want to log these somehow
                        //logger.LogError($"Error: {contextFeature.Error}");

                        await context.Response.WriteAsync(err);
                    }
                });
            });
        }
    }
}
