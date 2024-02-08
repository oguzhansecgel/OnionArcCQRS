using MediatR;
using OnionArcCQRS.Application.Features.Mediator.Results.FeatuesResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.Mediator.Queries.FeatureQueries
{
    public class GetFeatureByIdQuery : IRequest<GetFeatureByIdQueryResult>
    {
        public GetFeatureByIdQuery(int featureID)
        {
            FeatureID = featureID;
        }

        public int FeatureID { get; set; }

    }
}
