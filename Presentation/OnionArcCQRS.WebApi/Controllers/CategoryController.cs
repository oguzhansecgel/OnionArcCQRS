using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArcCQRS.Application.Features.CQRS.Commands.BrandCommand;
using OnionArcCQRS.Application.Features.CQRS.Commands.CategoryCommand;
using OnionArcCQRS.Application.Features.CQRS.Handlers.BrandHandlers;
using OnionArcCQRS.Application.Features.CQRS.Handlers.CategoryHandlers;
using OnionArcCQRS.Application.Features.CQRS.Queries.CategoruQueries;

namespace OnionArcCQRS.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CreateCategoryCommandHandler _createCategoryCommand;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommand;
        private readonly RemoveCategoryCommandHandler _removeCategoryCommand;
        private readonly GetCategoryByIdQueryHandler _categoryGetByIdCommand;
        private readonly GetCategoryQueryHandler _categoryCommand;

        public CategoryController(CreateCategoryCommandHandler createCategoryCommand, 
            UpdateCategoryCommandHandler updateCategoryCommand, 
            RemoveCategoryCommandHandler removeCategoryCommand,
            GetCategoryByIdQueryHandler categoryGetByIdCommand,
            GetCategoryQueryHandler categoryCommand)
        {
            _createCategoryCommand = createCategoryCommand;
            _updateCategoryCommand = updateCategoryCommand;
            _removeCategoryCommand = removeCategoryCommand;
            _categoryGetByIdCommand = categoryGetByIdCommand;
            _categoryCommand = categoryCommand;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategory()
        {
            var value = await _categoryCommand.Handle();
            return Ok(value);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCategory(int id)
        {
            var value = await _categoryGetByIdCommand.Handle(new GetCategoryByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            await _createCategoryCommand.Handle(command);
            return Ok("Başarıyla Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            await _updateCategoryCommand.Handle(command);
            return Ok("Başarıyla Güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _removeCategoryCommand.Handle(new RemoveCategoryCommand(id));
            return Ok("Başarıyla Silindi");
        }
    }
}
