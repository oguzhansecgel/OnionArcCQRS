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
    public class GetAvgRentPriceForDailyQueryHandler : IRequestHandler<GetAvgRentPriceForDailyQuery, GetAvgPriceForDailyQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetAvgRentPriceForDailyQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAvgPriceForDailyQueryResult> Handle(GetAvgRentPriceForDailyQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetAvgRentPriceForDaily();
            return new GetAvgPriceForDailyQueryResult
            {
                AvgPriceForDaily = value,
            };
        }
    }
}
