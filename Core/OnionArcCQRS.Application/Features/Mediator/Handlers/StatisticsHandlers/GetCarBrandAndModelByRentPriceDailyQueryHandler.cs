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
    public class GetCarBrandAndModelByRentPriceDailyQueryHandler : IRequestHandler<GetCarBrandAndModelByRentPriceDailyQuery, BrandStatisticsQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarBrandAndModelByRentPriceDailyQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<BrandStatisticsQueryResult> Handle(GetCarBrandAndModelByRentPriceDailyQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarBrandAndModelByRentPriceDailyMax();
            return new BrandStatisticsQueryResult
            {
                GetCarBrandAndModelByRentPriceDailyMax = value
            };
        }
    }
}
