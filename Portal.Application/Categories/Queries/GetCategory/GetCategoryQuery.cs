using MediatR;
using Portal.Application.Categories.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Categories.Queries.GetCategory
{
    public class GetCategoryQuery : IRequest<CategoryDto>
    {
        public Guid Id { get; set; }

        public GetCategoryQuery(Guid id) {
            Id = id;
        }
    }
}
