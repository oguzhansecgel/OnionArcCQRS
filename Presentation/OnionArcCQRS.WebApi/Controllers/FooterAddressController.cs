﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArcCQRS.Application.Features.Mediator.Commands.FeatureCommands;
using OnionArcCQRS.Application.Features.Mediator.Commands.FooterAddressCommands;
using OnionArcCQRS.Application.Features.Mediator.Queries.FeatureQueries;
using OnionArcCQRS.Application.Features.Mediator.Queries.FooterAddressQueries;

namespace OnionArcCQRS.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FooterAddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FooterAddressController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> FooterAddressList()
        {
            var values = await _mediator.Send(new GetFooterAddressQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFooterAddress(int id)
        {
            var values = await _mediator.Send(new GetFooterAddressByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFooterAddress(CreateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Özellik başarıyla eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveFooterAddress(int id)
        {
            await _mediator.Send(new RemoveFooterAddressCommand(id));
            return Ok("Özellik başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Özellik başarıyla güncellendi");
        }
    }
}
