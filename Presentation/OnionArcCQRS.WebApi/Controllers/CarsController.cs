using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArcCQRS.Application.Features.CQRS.Commands.CarCommand;
using OnionArcCQRS.Application.Features.CQRS.Handlers.CarHandlers;

namespace OnionArcCQRS.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CreateCarCommandHandler _createCarCommand;
        private readonly UpdateCarCommandHandler _updateCarCommand;
        private readonly RemoveCarCommandHandler _removeCarCommand;
        private readonly GetCarByIdQueryHandler _CarGetByIdCommand;
        private readonly GetCarQueryHandler _brandCommand;
        private readonly GetCarWithBrandQueryHandler _getCarWithBrandCommand;
        private readonly GetLast5CarWithBrandQueryHandler _getLast5CarWithBrandQueryHandler;
        public CarsController(CreateCarCommandHandler createCarCommand,
            UpdateCarCommandHandler updateCarCommand,
            RemoveCarCommandHandler removeCarCommand,
            GetCarByIdQueryHandler brandGetByIdCommand,
            GetCarQueryHandler brandCommand,
            GetCarWithBrandQueryHandler getCarWithBrandCommand,
            GetLast5CarWithBrandQueryHandler getLast5CarWithBrandQueryHandler)
        {
            _createCarCommand = createCarCommand;
            _updateCarCommand = updateCarCommand;
            _removeCarCommand = removeCarCommand;
            _CarGetByIdCommand = brandGetByIdCommand;
            _brandCommand = brandCommand;
            _getCarWithBrandCommand = getCarWithBrandCommand;
            _getLast5CarWithBrandQueryHandler = getLast5CarWithBrandQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetCar()
        {
            var value = await _brandCommand.Handle();
            return Ok(value);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCar(int id)
        {
            var value = await _CarGetByIdCommand.Handle(new Application.Features.CQRS.Queries.CarQueries.GetCarByIdQuery(id));
            return Ok(value);
        }
        [HttpGet("")]
        public IActionResult GetCarWithBrand()
        {
            var values = _getCarWithBrandCommand.Handle();
            return Ok(values);
        }
        [HttpGet("")]
        public IActionResult GetLast5CarsWithBrands()
        {
            var values = _getLast5CarWithBrandQueryHandler.Handle();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
            await _createCarCommand.Handle(command);
            return Ok("Başarıyla Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
        {
            await _updateCarCommand.Handle(command);
            return Ok("Başarıyla Güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _removeCarCommand.Handle(new DeleteCarCommand(id));
            return Ok("Başarıyla Silindi");
        }
       
    }
}
