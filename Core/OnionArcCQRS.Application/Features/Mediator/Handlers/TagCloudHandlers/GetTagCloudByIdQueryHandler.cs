using MediatR;
using OnionArcCQRS.Application.Features.Mediator.Queries.TagCloudQueries;
using OnionArcCQRS.Application.Features.Mediator.Results.TagCloudResults;
using OnionArcCQRS.Application.Interfaces;
using OnionArcCQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudByIdQueryHandler : IRequestHandler<GetTagCloudByIdQuery, GetTagCloudByIdQueryResult>
    {
        private readonly IRepository<TagCloud> _repository;

        public GetTagCloudByIdQueryHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task<GetTagCloudByIdQueryResult> Handle(GetTagCloudByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.TagCloudId);
            return new GetTagCloudByIdQueryResult
            {
                TagCloudId = values.TagCloudId,
                TagCloudTitle = values.TagCloudTitle,
                BlogID = values.BlogID
            };
        }
    }
}
