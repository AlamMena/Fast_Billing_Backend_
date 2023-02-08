
using API.DbModels.Contexts;
using API.DbModels.Errors;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Net;
using System.Text.Json;

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
                context.Response.ContentType = "application/problem+json";

                var builder = new DbContextOptionsBuilder<FbContext>();
                var connection = context.RequestServices.GetRequiredService<IConfiguration>();
                builder.UseSqlServer(connection.GetConnectionString("development"));
                var contextDb = new FbContext(builder.Options);

                await contextDb.AddAsync(new Error()
                {
                    Message = error?.Message!,
                    Exception = Newtonsoft.Json.JsonConvert.SerializeObject(error?.InnerException),
                    CreationDate = DateTime.Now,
                });

                await contextDb.SaveChangesAsync();

                await BuildResponse(context, HttpStatusCode.InternalServerError, error?.ToString()!, error?.InnerException?.ToString()!);
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
