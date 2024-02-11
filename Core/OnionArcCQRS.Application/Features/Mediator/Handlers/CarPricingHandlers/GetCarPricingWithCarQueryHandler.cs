using MediatR;
using OnionArcCQRS.Application.Features.Mediator.Queries.CarPricingQueries;
using OnionArcCQRS.Application.Features.Mediator.Results.CarPricingResults;
using OnionArcCQRS.Application.Features.Mediator.Results.LocationResults;
using OnionArcCQRS.Application.Interfaces.CarPricingInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingWithCarQueryHandler : IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingWithCarQueryResult>>
    {
        private readonly ICarPricingRepository _repository;

        public GetCarPricingWithCarQueryHandler(ICarPricingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarPricingWithCarQueryResult>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarPricingWithCars();
            return values.Select(x => new GetCarPricingWithCarQueryResult
            {
               Amount = x.Amount,
               Brand=x.Car.Brand.BrandName,
               CarPricingId=x.CarPricingID,
               CoverImageUrl=x.Car.CoverImageUrl,
               Model=x.Car.Model,
               CarId=x.Car.CarID

            }).ToList();
        }
    }
}
