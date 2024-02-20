using MediatR;
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
    public class GetBrandCountQueryHandler : IRequestHandler<GetBrandCountQuery, GetBrandCountQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetBrandCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBrandCountQueryResult> Handle(GetBrandCountQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetBrandCount();
            return new GetBrandCountQueryResult
            {
                BrandCount = value,
            };
        }
    }
}
