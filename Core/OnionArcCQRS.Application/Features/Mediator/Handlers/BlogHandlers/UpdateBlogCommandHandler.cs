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
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public UpdateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.BlogId);
            values.AuthorID = request.AuthorID;
            values.CreatedTime = request.CreatedTime;
            values.CategoryID = request.CategoryID;
            values.CoverImage = request.CoverImage;
            values.BlogTitle = request.BlogTitle;
            await _repository.UpdateAsync(values);
        }
    }
}
