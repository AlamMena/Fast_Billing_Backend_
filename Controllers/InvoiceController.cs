using API.DbModels.Contexts;
using API.DbModels.Invoices;
using API.Dtos.Sales.Invoices;
using API.Services.Sales.Ncf;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api")]
    public class InvoiceController : ControllerBase
    {
       
    }
}