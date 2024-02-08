using MediatR;
using OnionArcCQRS.Application.Features.CQRS.Results.BrandResults;
using OnionArcCQRS.Application.Features.Mediator.Queries.FeatureQueries;
using OnionArcCQRS.Application.Features.Mediator.Results.FeatuesResults;
using OnionArcCQRS.Application.Interfaces;
using OnionArcCQRS.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class GetFeatureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
    {
        private readonly IRepository<Feature> _repository;

        public GetFeatureByIdQueryHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetByIdAsync(request.FeatureID);
            return new GetFeatureByIdQueryResult
            {
                FeatureID = values.Result.FeatureID,
                FeatureName=values.Result.FeatureName,
            };
        }
    }
}
