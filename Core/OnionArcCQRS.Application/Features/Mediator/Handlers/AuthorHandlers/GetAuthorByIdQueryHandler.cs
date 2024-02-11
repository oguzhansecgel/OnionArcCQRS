using MediatR;
using OnionArcCQRS.Application.Features.Mediator.Queries.AuthorQueries;
using OnionArcCQRS.Application.Features.Mediator.Results.AuthorResults;
using OnionArcCQRS.Application.Interfaces;
using OnionArcCQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdQueryResult>
    {
        private readonly IRepository<Author> _repository;

        public GetAuthorByIdQueryHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.AuthorID);
            return new GetAuthorByIdQueryResult
            {
                AuthorID = values.AuthorID,
                AuthorName = values.AuthorName,
                Description = values.Description,
                ImageUrl = values.ImageUrl
            };
        }
    }
}
