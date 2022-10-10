using API.DbModels.Contacts;
using API.DbModels.Inventory.Brands;
using API.DbModels.Inventory.Categories;
using API.DbModels.Inventory.GoodsReceipt;
using API.DbModels.Inventory.SubCategories;
using API.DbModels.Inventory.Warehouses;
using API.DbModels.Invoices;
using API.DbModels.Ncf;
using API.DbModels.Payments;
using API.DbModels.Products;
using API.DbModels.Suppliers;
using API.DbModels.System.Branches;
using API.DbModels.System.Companies;
using API.Dtos.Core;
using API.Dtos.Inventory.Brands;
using API.Dtos.Inventory.Categories;
using API.Dtos.Inventory.GoodReceipt;
using API.Dtos.Inventory.SubCategories;
using API.Dtos.Inventory.Suppliers;
using API.Dtos.Inventory.Warehouses;
using API.Dtos.Payments;
using API.Dtos.Products;
using API.Dtos.Sales.Clients;
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
            CreateMap<InvoiceType, TypeDto>().ReverseMap();

            // good receipts
            CreateMap<GoodReceipt, GoodReceiptDto>().ReverseMap();
            CreateMap<GoodReceiptDetail, GoodReceiptDetailDto>().ReverseMap();

            // ncf
            CreateMap<NcfType, TypeDto>().ReverseMap();

            // client
            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<TypeDto, ClientType>().ReverseMap();

            // supplier 
            CreateMap<Supplier, SupplierDto>();

            // payments 
            CreateMap<Payment, PaymentDto>().ReverseMap();
            CreateMap<PaymentType, TypeDto>().ReverseMap();




        }
    }
}
