using MediatR;
using OnionArcCQRS.Application.Features.Mediator.Queries.BlogQueries;
using OnionArcCQRS.Application.Features.Mediator.Results.BlogResults;
using OnionArcCQRS.Application.Interfaces;
using OnionArcCQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
    {
        private readonly IRepository<Blog> _repository;

        public GetBlogByIdQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.BlogId);
            return new GetBlogByIdQueryResult
            {
                BlogId = values.BlogId,
                AuthorID = values.AuthorID,
                CategoryID = values.CategoryID,
                CoverImage = values.CoverImage,
                CreatedTime = values.CreatedTime,
                BlogTitle = values.BlogTitle,
                Description=values.Description,
                
            };
        }
    }
}
