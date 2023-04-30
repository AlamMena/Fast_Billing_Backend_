using API.Authentication;
using API.Exceptions;
using API.Extensions;
using API.Mappers;
using API.Services.Firebase;
using API.Services.Sales.Ncf;
using API.Services.Sales.Invoices;
using API.Services.Users;
using API.Swagger;
using Microsoft.OpenApi.Models;
using API.Services.Inventory;
using API.Services.Sales.Reports;
using API.Services.Accounts.Reports;

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
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<IGoodReceiptService, GoodReceiptService>();
builder.Services.AddScoped<ISalesReportService, SalesReportService>();
builder.Services.AddScoped<IAccountReportService, AccountsReportService>();


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
// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI();
// }


app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors("WebCors");

app.UseMiddleware<ExceptionHandler>();

app.MapControllers();

app.Run();










//"local": "Server=LAPTOP-DES11\\SQLEXPRESS;DataBase=FastBillingDB; trusted_connection=true;",

//  USE [FastBillingDB]
// GO
// /****** Object:  StoredProcedure [dbo].[sp_get_ncf_sequence]    Script Date: 28/9/2022 5:11:30 p. m. ******/
// SET ANSI_NULLS ON
// GO
// SET QUOTED_IDENTIFIER ON
// GO
// ALTER PROCEDURE [dbo].[sp_get_ncf_sequence] (@ncf_type int,
// @company int,
// @branch int,
// @ncf varchar(20) OUTPUT,
// @expiration_date Datetime OUTPUT)
// AS
// BEGIN
//   SET NOCOUNT ON;
//   -- UPDATE SEQUENCE -- 
//   UPDATE sales_ncf_sequences
//   SET LastNumber = LastNumber + 1
//   WHERE CompanyId = @company
//   AND BranchId = @branch
//   AND NCFTypeId = @ncf_type;

//   -- SELECT SEQUENCE --
//   SELECT
//     @ncf = Prefix + FORMAT(LastNumber,'00000000'),
// 	@expiration_date = ExpirationDate
//   FROM sales_ncf_sequences AS s
//   WHERE CompanyId = @Company
//   AND BranchId = @Branch
//   AND NCFTypeId = @Ncf_type
//   AND SequenceUntil > (LastNumber + 1);
// END;