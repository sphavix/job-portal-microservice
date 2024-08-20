using AutoMapper;
using MediatR;
using Portal.Application.Categories.Dtos;
using Portal.Domain.Entities;
using Portal.Domain.Repositories;

namespace Portal.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CategoryDto> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            // Map entity to Dto
            var category = _mapper.Map<Category>(command);

            var newCategory = await _categoryRepository.CreateCategoryAsync(category);

            // Map Dto to entity
            var response = _mapper.Map<CategoryDto>(newCategory);

            return response;
        }
    }
}
