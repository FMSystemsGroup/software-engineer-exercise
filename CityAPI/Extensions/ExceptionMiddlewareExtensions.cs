using Contracts;
using Entities;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace CityAPI.Extensions
{
    /// <summary>
    /// This class contains an extension method for the WebApplication class that can configure the exception handler middleware
    /// </summary>
    public static class ExceptionMiddlewareExtensions
    {
        /// <summary>
        /// This method adds the exception handler middleware to the web application pipeline and injects the dependency for the logger manager
        /// </summary>
        /// <param name="app"></param>
        /// <param name="logger"></param>
        public static void ConfigureExceptionHandler(this WebApplication app, ILoggerManager logger) 
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
                        logger.LogError($"Something went wrong: {contextFeature.Error}"); 
                        await context.Response.WriteAsync(new ErrorDetails() 
                        { 
                            StatusCode = context.Response.StatusCode, Message = "Internal Server Error.", 
                        }.ToString()); 
                    } 
                }); 
            }); 
        }
    }
}
