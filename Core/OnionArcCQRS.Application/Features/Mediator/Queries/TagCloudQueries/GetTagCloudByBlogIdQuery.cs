using MediatR;
using OnionArcCQRS.Application.Features.Mediator.Results.TagCloudResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.Mediator.Queries.TagCloudQueries
{
    public class GetTagCloudByBlogIdQuery :IRequest<List<GetTagCloudByBlogIdQueryResult>>
    {
        public GetTagCloudByBlogIdQuery(int tagCloudId)
        {
            TagCloudId = tagCloudId;
        }

        public int TagCloudId { get; set; }

    }
}
