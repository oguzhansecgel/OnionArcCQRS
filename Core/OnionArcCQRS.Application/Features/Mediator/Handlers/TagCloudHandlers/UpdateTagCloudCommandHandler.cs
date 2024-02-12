using MediatR;
using OnionArcCQRS.Application.Features.Mediator.Commands.TagCloudCommands;
using OnionArcCQRS.Application.Interfaces;
using OnionArcCQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class UpdateTagCloudCommandHandler : IRequestHandler<UpdateTagCloudCommand>
    {
        private readonly IRepository<TagCloud> _repository;

        public UpdateTagCloudCommandHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTagCloudCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.TagCloudId);
            values.TagCloudTitle = request.TagCloudTitle;
            values.BlogID = request.BlogID;
            await _repository.UpdateAsync(values);
        }
    }
}
