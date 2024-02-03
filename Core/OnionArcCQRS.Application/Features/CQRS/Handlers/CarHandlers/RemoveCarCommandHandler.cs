using OnionArcCQRS.Application.Features.CQRS.Commands.CarCommand;
using OnionArcCQRS.Application.Interfaces;
using OnionArcCQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.CQRS.Handlers.CarHandlers
{
    public class RemoveCarCommandHandler
    {
        private readonly IRepository<Car> _repository;
        public RemoveCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(DeleteCarCommand command)
        {
            var value = await _repository.GetByIdAsync(command.CarID);
            await _repository.RemoveAsync(value);
        }
    }
}
