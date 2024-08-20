using AutoMapper;
using MediatR;
using Portal.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public async Task<bool> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetCategoryAsync(command.Id);
            if (category == null)
            {
                return default;
            }

            await _categoryRepository.DeleteCategoryAsync(category.Id);
            return true;
        }
    }
}
