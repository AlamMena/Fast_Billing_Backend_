
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Net;

namespace API.Exceptions
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }
        public class Record
        {
            public int Id { get; set; }
        }
        public async Task InvokeAsync(HttpContext context)
        {
            //var originalBodyResponse = context.Response.Body;
            //using var newBodyResponse = new MemoryStream();
            //context.Response.Body = newBodyResponse;

            try
            {
                await _next(context);
            }
            catch (ValidationException error)
            {
                context.Response.ContentType = "application/problem+json";

                await BuildResponse(context, HttpStatusCode.BadRequest, "Validation error", error.Message);
            }
            catch (UnauthorizedAccessException error)
            {
                context.Response.ContentType = "application/problem+json";

                await BuildResponse(context, HttpStatusCode.Unauthorized, "Unauthorized", error.Message);
            }
            catch (Exception error)
            {
                //var exceptionDetails = httpContext.Features.Get<IExceptionHandlerFeature>();
                //var error = exceptionDetails?.Error;

                context.Response.ContentType = "application/problem+json";

                //if (error?.GetType().Name == nameof(ArgumentException))
                //{
                //    await BuildResponse(context, HttpStatusCode.Unauthorized, "Unauthorized User", error.Message);
                //}
                // else if (error?.GetType().Name == nameof(NotFoundException))
                // {
                //     await BuildResponse(context, HttpStatusCode.NotFound, "Not found", error.Message);
                // }
                // else if (error?.GetType().Name == nameof(ForbidenException))
                // {
                //     await BuildResponse(context, HttpStatusCode.Forbidden, "Unauthorized Action", error.Message);
                // }
                // else
                // {
                await BuildResponse(context, HttpStatusCode.InternalServerError, "Unhandler server error", error?.InnerException?.ToString()!);

                // // save log
                // var contextDb = (POSContext)context.RequestServices.GetService(typeof(POSContext))!;
                // await contextDb.AddAsync(new Error()
                // {
                //     Message = error?.Message!,
                //     Exception = Newtonsoft.Json.JsonConvert.SerializeObject(error?.InnerException),
                //     Fecha = DateTime.Now,
                // });
                // await contextDb.SaveChangesAsync();
                // }
            }
            finally
            {
                //// Getting service
                ////var logService = (AuditLogService)context.RequestServices.GetService(typeof(AuditLogService))!;

                //// reseting postion in the response 
                //newBodyResponse.Seek(0, SeekOrigin.Begin);

                //// reading the response inside the original context
                //var bodyResponse = await new StreamReader(newBodyResponse).ReadToEndAsync();

                //// saving log asynchronous
                ////logService.Log(context.Request.Path, bodyResponse, context.Request.Method);

                //await newBodyResponse.CopyToAsync(originalBodyResponse);
                //context.Response.Body = newBodyResponse;
                //context.Response.Body.Position = 0;
            }
        }
        private static async Task BuildResponse(HttpContext context, HttpStatusCode code, string tittle, string errorMessage, object? details = null)
        {
            var stream = context.Response.Body;
            var traceId = Activity.Current?.Id ?? context.TraceIdentifier;

            context.Response.StatusCode = (int)code;

            await System.Text.Json.JsonSerializer.SerializeAsync(stream,
                new { status = code, message = errorMessage, title = tittle, traceId = traceId, details });

        }
    }
}
