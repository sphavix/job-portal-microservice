
using MediatR;
using Portal.Application.Categories.Dtos;

namespace Portal.Application.Categories.Queries.GetCategories
{
    public class GetCategoriesQuery : IRequest<IList<CategoryDto>>
    {
    }
}
