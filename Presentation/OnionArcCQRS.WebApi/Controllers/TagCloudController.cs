using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionArcCQRS.Application.Features.Mediator.Commands.TagCloudCommands;
using OnionArcCQRS.Application.Features.Mediator.Queries.TagCloudQueries;

namespace OnionArcCQRS.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TagCloudController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagCloudController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> TagCloudList()
        {
            var values = await _mediator.Send(new GetTagCloudQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTagCloud(int id)
        {
            var values = await _mediator.Send(new GetTagCloudByIdQuery(id));
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTagCloudByBlogId(int id)
        {
            var values = await _mediator.Send(new GetTagCloudByBlogIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTagCloud(CreateTagCloudCommand command)
        {
            await _mediator.Send(command);
            return Ok("Özellik başarıyla eklendi");
        }
        [HttpDelete("")]
        public async Task<IActionResult> RemoveTagCloud(int id)
        {
            await _mediator.Send(new RemoveTagCloudCommand(id));
            return Ok("Özellik başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTagCloud(UpdateTagCloudCommand command)
        {
            await _mediator.Send(command);
            return Ok("Özellik başarıyla güncellendi");
        }
    }
}
