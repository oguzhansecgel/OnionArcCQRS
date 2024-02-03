using OnionArcCQRS.Application.Features.CQRS.Commands.CategoryCommand;
using OnionArcCQRS.Application.Interfaces;
using OnionArcCQRS.Domain.Entities;

namespace OnionArcCQRS.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;

        public RemoveCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveCategoryCommand command)
        {
            var value = await _repository.GetByIdAsync(command.CategoryID);
            await _repository.RemoveAsync(value);
        }
    }
}
