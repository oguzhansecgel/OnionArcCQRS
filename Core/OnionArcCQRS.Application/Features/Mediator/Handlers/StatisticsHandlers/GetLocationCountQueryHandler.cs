using MediatR;
using OnionArcCQRS.Application.Features.Mediator.Queries.LocationQueries;
using OnionArcCQRS.Application.Features.Mediator.Queries.StatisticsQueries;
using OnionArcCQRS.Application.Features.Mediator.Results.StatisticsResults;
using OnionArcCQRS.Application.Interfaces.StatisticsInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetLocationCountQueryHandler : IRequestHandler<GetLocationCountQuery, GetLocationCountQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetLocationCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetLocationCountQueryResult> Handle(GetLocationCountQuery request, CancellationToken cancellationToken)
        {
            var value =  _repository.GetLocationCount();
            return new GetLocationCountQueryResult
            {
                LocationCount = value,
            };

        }
    }
}
