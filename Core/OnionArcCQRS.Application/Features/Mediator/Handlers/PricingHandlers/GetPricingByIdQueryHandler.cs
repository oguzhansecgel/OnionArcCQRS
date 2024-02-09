using MediatR;
using OnionArcCQRS.Application.Features.Mediator.Queries.PricingQueries;
using OnionArcCQRS.Application.Features.Mediator.Results.PricingResults;
using OnionArcCQRS.Application.Interfaces;
using OnionArcCQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class GetPricingByIdQueryHandler : IRequestHandler<GetPricingByIdQuery, GetPricingByIdQueryResult>
    {
        private readonly IRepository<Pricing> _repository;

        public GetPricingByIdQueryHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task<GetPricingByIdQueryResult> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetByIdAsync(request.PricingID);
            return new GetPricingByIdQueryResult
            {
                PricingID = values.Result.PricingID,
                Name = values.Result.Name,


            };
        }
    }
}
