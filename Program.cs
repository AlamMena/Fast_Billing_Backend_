using API.Authentication;
using API.Exceptions;
using API.Extensions;
using API.Mappers;
using API.Services.Firebase;
using API.Services.Sales.Ncf;
using API.Services.Users;
using API.Swagger;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// adding dbcontext
builder.Services.BuildContext();

// auth services
builder.Services.AddJwtAuthentication();
builder.Services.AddSingleton<FirebaseInit>();
builder.Services.AddHttpContextAccessor();

// db services
builder.Services.AddScoped<IUserManagement, UserManagement>();
builder.Services.AddScoped<INcfService, NcfService>();


// lib services
builder.Services.AddAutoMapper();
builder.Services.AddSwagger();
builder.Services.AddLogging();

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

// cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "WebCors",
        builder =>
        {
            builder.WithHeaders("*");
            builder.WithMethods("*");
            builder.WithOrigins("*");
        });
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors("WebCors");

app.UseMiddleware<ExceptionHandler>();

app.MapControllers();

app.Run();
