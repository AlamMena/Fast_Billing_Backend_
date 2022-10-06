using API.DbModels.Contexts;
using API.DbModels.Inventory.Brands;
using API.Dtos.Inventory.Brands;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API.Controllers
{
    public class BrandController : CoreController<Brand, BrandDto>
    {
        public BrandController(FbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
        protected override async Task<bool> ValidateAsync(Brand request)
        {
            var brandExists = await _context.Brands
                 .AnyAsync(d => d.Id != request.Id && d.Name == request.Name);
            if (brandExists)
            {
                throw new ValidationException("The brand name is not avaliable");
            }
            return true;
        }


    }

}