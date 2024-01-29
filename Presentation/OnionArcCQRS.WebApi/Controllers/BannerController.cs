using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArcCQRS.Application.Features.CQRS.Commands.BannerCommand;
using OnionArcCQRS.Application.Features.CQRS.Handlers.BannerHandlers;
using OnionArcCQRS.Application.Features.CQRS.Queries.BannerQueries;

namespace OnionArcCQRS.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private readonly CreateBannerCommandHandler _createBannerCommand;
        private readonly UpdateBannerCommandHandler _updateBannerCommand;
        private readonly RemoveBannerCommandHandler _removeBannerCommand;
        private readonly GetBannerByIdQueryHandler _bannerGetByIdCommand;
        private readonly GetBannerQueryHandler _bannerCommand;

        public BannerController(CreateBannerCommandHandler createBannerCommand, 
            UpdateBannerCommandHandler updateBannerCommand, 
            RemoveBannerCommandHandler removeBannerCommand, 
            GetBannerByIdQueryHandler bannerGetByIdCommand, 
            GetBannerQueryHandler bannerCommand)
        {
            _createBannerCommand = createBannerCommand;
            _updateBannerCommand = updateBannerCommand;
            _removeBannerCommand = removeBannerCommand;
            _bannerGetByIdCommand = bannerGetByIdCommand;
            _bannerCommand = bannerCommand;
        }


        [HttpGet]
        public async Task<IActionResult> GetBanner()
        {
            var value = await _bannerCommand.Handle();
            return Ok(value);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdBanner(int id)
        {
            var value = await _bannerGetByIdCommand.Handle(new GetBannerByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
        {
            await _createBannerCommand.Handle(command);
            return Ok("Başarıyla Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
        {
            await _updateBannerCommand.Handle(command);
            return Ok("Başarıyla Güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBanner(int id)
        {
            await _removeBannerCommand.Handle(new RemoveBannerCommand(id));
            return Ok("Başarıyla Silindi");
        }
    }

}
