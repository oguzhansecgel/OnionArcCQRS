using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArcCQRS.Application.Features.CQRS.Commands.CategoryCommand;
using OnionArcCQRS.Application.Features.CQRS.Commands.ContactCommand;
using OnionArcCQRS.Application.Features.CQRS.Handlers.CategoryHandlers;
using OnionArcCQRS.Application.Features.CQRS.Handlers.ContactHandlers;
using OnionArcCQRS.Application.Features.CQRS.Queries.CategoruQueries;
using OnionArcCQRS.Application.Features.CQRS.Queries.ContactQueries;

namespace OnionArcCQRS.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly CreateContactCommandHandler _createContactCommand;
        private readonly UpdateContactCommandHandler _updateContactCommand;
        private readonly RemoveContactCommandHandler _removeContactCommand;
        private readonly GetContactByIdQueryHandler _contactGetByIdCommand;
        private readonly GetContactQueryHandler _contactCommand;

        public ContactController(CreateContactCommandHandler createContactCommand, 
            UpdateContactCommandHandler updateContactCommand, 
            RemoveContactCommandHandler removeContactCommand, 
            GetContactByIdQueryHandler contactGetByIdCommand, 
            GetContactQueryHandler contactCommand)
        {
            _createContactCommand = createContactCommand;
            _updateContactCommand = updateContactCommand;
            _removeContactCommand = removeContactCommand;
            _contactGetByIdCommand = contactGetByIdCommand;
            _contactCommand = contactCommand;
        }
        [HttpGet]
        public async Task<IActionResult> GetContact()
        {
            var value = await _contactCommand.Handle();
            return Ok(value);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdContact(int id)
        {
            var value = await _contactGetByIdCommand.Handle(new GetContactByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommand command)
        {
            await _createContactCommand.Handle(command);
            return Ok("Başarıyla Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
        {
            await _updateContactCommand.Handle(command);
            return Ok("Başarıyla Güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteContact(int id)
        {
            await _removeContactCommand.Handle(new RemoveContactCommand(id));
            return Ok("Başarıyla Silindi");
        }
    }
}
