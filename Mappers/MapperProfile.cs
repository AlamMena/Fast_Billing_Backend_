using API.DbModels.Inventory.Brands;
using API.DbModels.Inventory.Categories;
using API.DbModels.Inventory.SubCategories;
using API.DbModels.Inventory.Warehouses;
using API.DbModels.Invoices;
using API.DbModels.Products;
using API.DbModels.System.Branches;
using API.DbModels.System.Companies;
using API.Dtos.Inventory.Brands;
using API.Dtos.Inventory.Categories;
using API.Dtos.Inventory.SubCategories;
using API.Dtos.Inventory.Warehouses;
using API.Dtos.Products;
using API.Dtos.Sales.Invoices;
using API.Dtos.System;
using API.Dtos.System.Branches;
using API.Dtos.System.Companies;
using AutoMapper;

namespace API.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // company
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<Company, CompanyCreateDto>().ReverseMap();

            // branch
            CreateMap<Branch, BranchDto>().ReverseMap();

            // category
            CreateMap<Category, CategoryDto>().ReverseMap();

            // brand
            CreateMap<Brand, BrandDto>().ReverseMap();

            // subcategory
            CreateMap<SubCategory, SubCategoryDto>().ReverseMap();

            // products
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductImage, ProductImageDto>().ReverseMap();

            // warehouse
            CreateMap<Warehouse, WarehouseDto>().ReverseMap();

            // invoice 
            CreateMap<Invoice, InvoiceDto>().ReverseMap();
            CreateMap<InvoiceDetail, InvoiceDetailDto>().ReverseMap();
        }
    }
}
