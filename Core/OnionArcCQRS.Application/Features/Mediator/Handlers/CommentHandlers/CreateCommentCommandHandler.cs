using MediatR;
using OnionArcCQRS.Application.Features.Mediator.Commands.CommentCommands;
using OnionArcCQRS.Application.Interfaces;
using OnionArcCQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommands>
    {
        private readonly IRepository<Comment> _repository;

        public CreateCommentCommandHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCommentCommands request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Comment
            {
                Description = request.Description,
                BlogId = request.BlogID,
                CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString()),
                Name = request.Name,
            });
        }
    }
}
