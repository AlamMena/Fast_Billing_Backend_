using API.DbModels.Contexts;
using API.DbModels.Inventory.Products;
using API.DbModels.Products;
using API.Dtos.Core;
using API.Dtos.Products;
using API.Enums;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API.Controllers
{
    [ApiController]
    [Route("api")]
    public class ProductController : ControllerBase
    {
        private readonly FbContext _context;
        private readonly IMapper _mapper;
        public ProductController(FbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected async Task<bool> ValidateAsync(Product request)
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

        [HttpPost("product")]
        public async Task<IActionResult> PostAsync(ProductDto request)
        {
            await _context.Database.BeginTransactionAsync();

            var product = _mapper.Map<Product>(request);

            await ValidateAsync(product);

            // adding initial price
            product.Prices.Add(new ProductPrice
            {
                Cost = request.Cost,
                Price = request.Price,
                MarginBenefit = request.MarginBenefit,

            });

            var wareHouseExists = await _context.Warehouses.AnyAsync(d => d.Id == request.WarehouseId);
            if (!wareHouseExists)
            {
                throw new ValidationException("The warehouse is not valid");
            }

            // adding initial stock
            product.Stocks.Add(new ProductStock
            {
                WarehouseId = request.WarehouseId,
                Stock = request.Stock,
            });

            // generating the initial transaction
            product.Transactions.Add(new ProductTransaction()
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
                Document = "INITIAL TRANSACTION",
                ExpirationDate = null,
                CompanyId = _context.tenant.CompanyId,
                BranchId = _context.tenant.BranchId,
            });

            await _context.AddAsync(product);
            await _context.SaveChangesAsync();

            await _context.Database.CommitTransactionAsync();

            var response = _mapper.Map<ProductDto>(product);
            return Created("", response);
        }


        [HttpPut("product")]
        public async Task<IActionResult> PutAsync(ProductUpdateDto request)
        {
            var product = await _context.Products.Include(d => d.Prices).FirstOrDefaultAsync(d => d.Id == request.Id);

            if (product is null)
            {
                return NotFound();
            }

            _mapper.Map(request, product);

            await ValidateAsync(product);

            await _context.SaveChangesAsync();

            var responseEntity = _mapper.Map<ProductDto>(product);

            return Ok(responseEntity);
        }

        [HttpGet("products")]
        public virtual async Task<IActionResult> GetAllAsync([FromQuery] PaginatedFilteredRequest request)
        {
            var products = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(request.Value))
            {
                products = _context.Products.Where(d => d.Name.Contains(request.Value));
            }
            var response = new PaginatedResponse<ProductDto>
            {
                Data = await products
                 .Include(d => d.Prices)
                 .Include(d => d.Stocks)
                 .Skip((request.Page - 1) * request.Limit)
                 .Take(request.Limit)
                 .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                 .ToListAsync(),

                DataQuantity = await products.CountAsync()
            };

            return Ok(response);
        }

        [HttpGet("product/{id}")]
        public virtual async Task<IActionResult> GetByIdAsync(int id)
        {
            var dbEntity = await _context.Products
                .Include(d => d.Category)
                .Include(d => d.SubCategory)
                .Include(d => d.Brand)
                .Include(d => d.Prices)
                .Include(d => d.Stocks)
                .FirstOrDefaultAsync(d => d.Id == id);

            var response = _mapper.Map<ProductDto>(dbEntity);

            if (response is null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpDelete("product/{id}")]
        public virtual async Task<IActionResult> DeleteProduct(int id)
        {
            var dbEntity = await _context.Products.FirstOrDefaultAsync(d => d.Id == id);

            if (dbEntity is null)
            {
                return NotFound();
            }

            dbEntity.IsDeleted = true;

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
