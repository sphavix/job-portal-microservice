using AutoMapper;
using MediatR;
using Portal.Application.Categories.Dtos;
using Portal.Domain.Repositories;

namespace Portal.Application.Categories.Queries.GetCategory
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, CategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CategoryDto> Handle(GetCategoryQuery query, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetCategoryAsync(query.Id);

            // Map Dto to entity
            var categoryDto = _mapper.Map<CategoryDto>(category);

            return categoryDto;
        }
    }
}
