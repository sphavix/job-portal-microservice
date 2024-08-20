using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Categories.Commands.CreateCategory;
using Portal.Application.Categories.Commands.DeleteCategory;
using Portal.Application.Categories.Dtos;
using Portal.Application.Categories.Queries.GetCategories;
using Portal.Application.Categories.Queries.GetCategory;

namespace Portal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacanciesController : ControllerBase
    {
        private readonly IMediator mediator;
        public VacanciesController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetCategories()
        {
            var categories = new GetCategoriesQuery();
            var results = await mediator.Send(categories);
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(Guid id)
        {
            var category = new GetCategoryQuery(id);
            var result = await mediator.Send(category);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> CreateCategory([FromBody] CreateCategoryCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var result = new DeleteCategoryCommand { Id = id };
            return Ok(await mediator.Send(result));
        }
    
    }
}
