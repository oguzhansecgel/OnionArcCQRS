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
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<GetBlogQueryResult>>
    {
        private readonly IRepository<Blog> _repository;

        public GetBlogQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogQueryResult>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetBlogQueryResult
            {
                BlogId = x.BlogId,
                AuthorID = x.AuthorID,
                CategoryID = x.CategoryID,
                CoverImage = x.CoverImage,
                CreatedTime = x.CreatedTime,
                BlogTitle = x.BlogTitle
            }).ToList();
        }
    }
}
