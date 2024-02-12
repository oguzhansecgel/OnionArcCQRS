using MediatR;
using OnionArcCQRS.Application.Features.Mediator.Queries.TagCloudQueries;
using OnionArcCQRS.Application.Features.Mediator.Results.TagCloudResults;
using OnionArcCQRS.Application.Interfaces.TagCloudInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudByBlogIdQueryHandler : IRequestHandler<GetTagCloudByBlogIdQuery, List<GetTagCloudByBlogIdQueryResult>>
    {
        private readonly ITagCloudRepository _repository;

        public GetTagCloudByBlogIdQueryHandler(ITagCloudRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTagCloudByBlogIdQueryResult>> Handle(GetTagCloudByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetTagCloudsByBlogID(request.TagCloudId);
            return values.Select(x => new GetTagCloudByBlogIdQueryResult
            {
                BlogID = x.BlogID,
                TagCloudId = x.TagCloudId,
                TagCloudTitle = x.TagCloudTitle,
            }).ToList();
        }
    }
}
