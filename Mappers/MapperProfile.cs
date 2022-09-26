using API.DbModels.Inventory.Categories;
using API.DbModels.Inventory.SubCategories;
using API.DbModels.Products;
using API.DbModels.System.Branches;
using API.DbModels.System.Companies;
using API.Dtos.Inventory.Categories;
using API.Dtos.Inventory.SubCategories;
using API.Dtos.Products;
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

            // subcategory
            CreateMap<SubCategory, SubCategoryDto>().ReverseMap();

            // products
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
