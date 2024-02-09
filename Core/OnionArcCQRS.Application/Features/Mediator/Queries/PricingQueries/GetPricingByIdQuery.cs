using MediatR;
using OnionArcCQRS.Application.Features.Mediator.Results.PricingResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.Mediator.Queries.PricingQueries
{
    public class GetPricingByIdQuery : IRequest<GetPricingByIdQueryResult>
    {
        public GetPricingByIdQuery(int pricingID)
        {
            PricingID = pricingID;
        }

        public int PricingID { get; set; }
    }
}
