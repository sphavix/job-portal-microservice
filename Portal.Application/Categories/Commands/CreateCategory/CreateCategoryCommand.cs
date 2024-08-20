
using MediatR;
using Portal.Application.Categories.Dtos;
using Portal.Domain.Entities;

namespace Portal.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CategoryDto>
    {
        public string CategoryName { get; set; }
        public ICollection<Vacancy> Vacancies { get; set; }
    }
}
