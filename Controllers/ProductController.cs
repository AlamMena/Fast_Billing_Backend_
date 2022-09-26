using API.DbModels.Contexts;
using API.DbModels.Inventory.Core;
using API.DbModels.Products;
using API.Dtos.Products;
using API.Enums;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API.Controllers
{
    public class ProductController : CoreController<Product, ProductDto>
    {
        private readonly FbContext _context;
        private readonly IMapper _mapper;
        public ProductController(FbContext context, IMapper mapper)
            : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [NonAction]
        public override async Task<bool> ValidateAsync(ProductDto request)
        {
            var prodcutExists = await _context.Products.AnyAsync(d => d.Id != request.Id && d.Name == request.Name);
            if (prodcutExists)
            {
                throw new ValidationException("The product name is not avaliable");
            }
            var barCodeExists = await _context.Products.AnyAsync(d => d.Id != request.Id && d.BarCode == request.BarCode);
            if (barCodeExists)
            {
                throw new ValidationException("The bar code is not avaliable");
            }

            var categoryExist = await _context.Categories.AnyAsync(d => d.Id == request.CategoryId);
            if (!categoryExist)
            {
                throw new ValidationException("The category is not valid");
            }

            var subCategoryExists = await _context.SubCategories.AnyAsync(d => d.Id == request.SubCategoryId);
            if (!subCategoryExists)
            {
                throw new ValidationException("The subcategory is not valid");
            }

            var brandExists = await _context.Brands.AnyAsync(d => d.Id == request.BrandId);
            if (!brandExists)
            {
                throw new ValidationException("The brand is not valid");
            }

            return true;
        }

        [HttpPost]
        public override async Task<IActionResult> PostAsync(ProductDto request)
        {
            await _context.Database.BeginTransactionAsync();

            await ValidateAsync(request);

            var product = _mapper.Map<Product>(request);

            product.Prices.Add(new ProductPrice
            {
                Cost = request.Cost,
                Price = request.Price,
                MarginBenefit = request.MarginBenefit

            });

            product.Stock.Add(new ProductStock
            {
                WarehouseId = request.WarehouseId,
                Stock = request.Stock,
            });

            await _context.AddAsync(product);
            await _context.SaveChangesAsync();

            await _context.AddAsync(new InventoryTransaction()
            {
                WarehouseId = request.WarehouseId,
                ProductId = product.Id,
                ProductCost = request.Cost,
                ProductPrice = request.Price,
                Quantity = request.Stock,
                Sign = TransactionType.Income,
                OldQuantity = 0,
                NewQuantity = request.Stock,
                NewCost = request.Cost,
                Note = "Initial transaction",
                Document = "IT",
                ExpirationDate = null
            });

            await _context.SaveChangesAsync();
            await _context.Database.CommitTransactionAsync();

            return Created("", product);
        }
    }
}
