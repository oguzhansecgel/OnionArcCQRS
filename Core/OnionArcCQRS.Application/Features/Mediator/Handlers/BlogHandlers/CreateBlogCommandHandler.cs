using MediatR;
using OnionArcCQRS.Application.Features.Mediator.Commands.BlogCommands;
using OnionArcCQRS.Application.Interfaces;
using OnionArcCQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public CreateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Blog
            {
                AuthorID = request.AuthorID,
                CategoryID = request.CategoryID,
                CoverImage = request.CoverImage,
                CreatedTime = request.CreatedTime,
                BlogTitle = request.BlogTitle,
                Description = request.Description,
            });
        }
    }
}
