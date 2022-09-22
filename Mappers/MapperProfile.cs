using API.DbModels.Inventory.Categories;
using API.DbModels.System.Branches;
using API.DbModels.System.Companies;
using API.Dtos.Inventory.Categories;
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

        }
    }
}
