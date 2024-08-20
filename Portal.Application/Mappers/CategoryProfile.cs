using AutoMapper;
using Portal.Application.Categories.Commands.CreateCategory;
using Portal.Application.Categories.Dtos;
using Portal.Domain.Entities;

namespace Portal.Application.Mappers
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(v => v.Vacancies, opt => opt.MapFrom(src => src.Vacancies))
                .ReverseMap();

            CreateMap<CreateCategoryCommand, Category>().ReverseMap();
        }
    }
}
