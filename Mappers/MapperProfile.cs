using API.DbModels.Core;
using API.DbModels.Inventory.Brands;
using API.DbModels.Inventory.Categories;
using API.DbModels.Inventory.GoodsReceipt;
using API.DbModels.Inventory.SubCategories;
using API.DbModels.Inventory.Suppliers;
using API.DbModels.Inventory.Warehouses;
using API.DbModels.Invoices;
using API.DbModels.Ncf;
using API.DbModels.Payments;
using API.DbModels.Products;
using API.DbModels.Sales.Clients;
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
            CreateMap<SubCategory, SubCategoryDto>().ForMember(dest => dest.CategoryName, src => src.MapFrom(m => m.Category.Name));
            CreateMap<SubCategoryDto, SubCategory>();

            // products
            CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.Price, src => src.MapFrom(m => m.Prices.First().Price))
            .ForMember(dest => dest.Cost, src => src.MapFrom(m => m.Prices.First().Cost))
            .ForMember(dest => dest.Stock, src => src.MapFrom(m => m.Stocks.Sum(d => d.Stock)))
            .ForMember(dest => dest.MarginBenefit, src => src.MapFrom(m => m.Prices.First().MarginBenefit))
            .ForMember(dest => dest.BrandName, src => src.MapFrom(m => m.Brand.Name))
            .ForMember(dest => dest.CategoryName, src => src.MapFrom(m => m.Category.Name))
            .ForMember(dest => dest.CategoryName, src => src.MapFrom(m => m.Category.Name))
            .ForMember(dest => dest.SubCategoryName, src => src.MapFrom(m => m.SubCategory.Name));

            CreateMap<ProductDto, Product>();
            CreateMap<ProductUpdateDto, Product>().ReverseMap();

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
            CreateMap<ClientAddress, AddressDto>().ReverseMap();
            CreateMap<ClientContact, ContactDto>().ReverseMap();

            // supplier 
            CreateMap<Supplier, SupplierDto>().ReverseMap();
            CreateMap<SupplierAddress, AddressDto>().ReverseMap();
            CreateMap<SupplierContact, ContactDto>().ReverseMap();


            // payments 
            CreateMap<Payment, PaymentDto>().ReverseMap();
            CreateMap<PaymentType, TypeDto>().ReverseMap();

        }
    }
}
