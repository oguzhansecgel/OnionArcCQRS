using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArcCQRS.Application.Features.CQRS.Commands.BrandCommand;
using OnionArcCQRS.Application.Features.CQRS.Handlers.BannerHandlers;
using OnionArcCQRS.Application.Features.CQRS.Handlers.BrandHandlers;

namespace OnionArcCQRS.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly CreateBrandCommandHandler _createBrandCommand;
        private readonly UpdateBrandCommandHandler _updateBrandCommand;
        private readonly RemoveBrandCommandHandler _removeBrandCommand;
        private readonly GetBrandGetByIdQueryHandler _BrandGetByIdCommand;
        private readonly GetBrandQueryHandler _brandCommand;

        public BrandController(CreateBrandCommandHandler createBrandCommand, 
            UpdateBrandCommandHandler updateBrandCommand,
            RemoveBrandCommandHandler removeBrandCommand,
            GetBrandGetByIdQueryHandler brandGetByIdCommand, 
            GetBrandQueryHandler brandCommand)
        {
            _createBrandCommand = createBrandCommand;
            _updateBrandCommand = updateBrandCommand;
            _removeBrandCommand = removeBrandCommand;
            _BrandGetByIdCommand = brandGetByIdCommand;
            _brandCommand = brandCommand;
        }

        [HttpGet]
        public async Task<IActionResult> GetBrand()
        {
            var value = await _brandCommand.Handle();
            return Ok(value);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdBrand(int id)
        {
            var value = await _BrandGetByIdCommand.Handle(new Application.Features.CQRS.Queries.BrandQueries.GetBrandByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommand command)
        {
            await _createBrandCommand.Handle(command);
            return Ok("Başarıyla Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandCommand command)
        {
            await _updateBrandCommand.Handle(command);
            return Ok("Başarıyla Güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            await _removeBrandCommand.Handle(new RemoveBrandCommand(id));
            return Ok("Başarıyla Silindi");
        }

    }
}
