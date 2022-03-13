using AutoMapper;
using Blog.Models;
using Blog.Models.Dtos;

namespace Blog.Service.AutoMapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoriesDto>().ReverseMap(); //Category->CategoryDto'ya ve CategoryDto->Category'ye map edilebilecek...
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
