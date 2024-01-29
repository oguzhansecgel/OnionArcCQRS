using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArcCQRS.Application.Features.CQRS.Commands.AboutCommand;
using OnionArcCQRS.Application.Features.CQRS.Handlers.AboutHandlers;
using OnionArcCQRS.Application.Features.CQRS.Queries.AboutQueries;

namespace OnionArcCQRS.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly CreateAboutCommandHandler _createAboutCommandHandler;
        private readonly UpdateAboutCommandHandler _updateAboutCommandHandler;
        private readonly RemoveAboutCommandHandler _deleteAboutCommandHandler;
        private readonly GetAboutByIdQueryHandler _getAboutByIdCommandHandler;
        private readonly GetAboutQueryHandler _getAboutCommandHandler;

        public AboutsController(CreateAboutCommandHandler createAboutCommandHandler, 
            UpdateAboutCommandHandler updateAboutCommandHandler,
            RemoveAboutCommandHandler deleteAboutCommandHandler, 
            GetAboutByIdQueryHandler getAboutByIdCommandHandler, 
            GetAboutQueryHandler getAboutCommandHandler)
        {
            _createAboutCommandHandler = createAboutCommandHandler;
            _updateAboutCommandHandler = updateAboutCommandHandler;
            _deleteAboutCommandHandler = deleteAboutCommandHandler;
            _getAboutByIdCommandHandler = getAboutByIdCommandHandler;
            _getAboutCommandHandler = getAboutCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var values = await _getAboutCommandHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbout(int id)
        {
            var values = await _getAboutByIdCommandHandler.Handle(new GetAboutByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutCommand command)
        {
            await _createAboutCommandHandler.Handle(command);
            return Ok("Başarıyla Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            await _deleteAboutCommandHandler.Handle(new RemoveAboutCommand(id));
            return Ok("Başarıyla Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command)
        {
            await _updateAboutCommandHandler.Handle(command);
            return Ok("Başarıyla Güncellendi");
        }
    }
}
