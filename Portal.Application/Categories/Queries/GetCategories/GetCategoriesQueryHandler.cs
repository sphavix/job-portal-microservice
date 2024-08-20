using AutoMapper;
using MediatR;
using Portal.Application.Categories.Dtos;
using Portal.Domain.Repositories;

namespace Portal.Application.Categories.Queries.GetCategories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IList<CategoryDto>>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public GetCategoriesQueryHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IList<CategoryDto>> Handle(GetCategoriesQuery query, CancellationToken cancellationToken)
        {
            var categories = await _repository.GetCategoriesAsync();

            // Map Dto to entity
            var categoriesDto = _mapper.Map<IList<CategoryDto>>(categories);

            return categoriesDto;
        }
    }
}
