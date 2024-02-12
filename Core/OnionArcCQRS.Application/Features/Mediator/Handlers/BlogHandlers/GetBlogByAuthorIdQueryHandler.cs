using MediatR;
using OnionArcCQRS.Application.Features.Mediator.Queries.BlogQueries;
using OnionArcCQRS.Application.Features.Mediator.Results.BlogResults;
using OnionArcCQRS.Application.Interfaces.BlogInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogByAuthorIdQueryHandler : IRequestHandler<GetBlogByAuthorIdQuery, List<GetBlogByAuthorIdQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetBlogByAuthorIdQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogByAuthorIdQueryResult>> Handle(GetBlogByAuthorIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetBlogsByAuthorId(request.BlogId);
            return values.Select(x => new GetBlogByAuthorIdQueryResult
            {
                AuthorID = x.AuthorID,
                BlogId = x.BlogId,
                AuthorName = x.Author.AuthorName,
                AuthorDescription=x.Author.Description,
                AuthorImageUrl = x.Author.ImageUrl,
            }).ToList();
        }
    }
}
