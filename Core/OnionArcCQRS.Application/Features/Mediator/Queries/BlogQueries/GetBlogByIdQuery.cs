using MediatR;
using OnionArcCQRS.Application.Features.Mediator.Results.BlogResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetBlogByIdQuery : IRequest<GetBlogByIdQueryResult>
    {
        public GetBlogByIdQuery(int blogId)
        {
            BlogId = blogId;
        }

        public int BlogId { get; set; }

    }
}
