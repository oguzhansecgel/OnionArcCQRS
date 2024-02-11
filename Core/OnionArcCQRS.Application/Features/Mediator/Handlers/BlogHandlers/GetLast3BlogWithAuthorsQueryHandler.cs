using MediatR;
using OnionArcCQRS.Application.Features.Mediator.Queries.BlogQueries;
using OnionArcCQRS.Application.Features.Mediator.Results.BlogResults;
using OnionArcCQRS.Application.Interfaces;
using OnionArcCQRS.Application.Interfaces.BlogInterfaces;
using OnionArcCQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetLast3BlogWithAuthorsQueryHandler : IRequestHandler<GetLast3BlogsWithAuthorsQuery, List<GetLast3BlogWithAuthorsQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetLast3BlogWithAuthorsQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLast3BlogWithAuthorsQueryResult>> Handle(GetLast3BlogsWithAuthorsQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetLast3BlogsWithAuthors();
            return values.Select(x => new GetLast3BlogWithAuthorsQueryResult
            {
                AuthorID = x.AuthorID,
                BlogId = x.BlogId,
                CategoryID = x.CategoryID,
                CoverImage = x.CoverImage,
                CreatedTime = x.CreatedTime,
                BlogTitle = x.BlogTitle,
                AuthorName = x.Author.AuthorName
            }).ToList();
        }
    }
}
