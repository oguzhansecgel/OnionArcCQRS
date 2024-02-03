using OnionArcCQRS.Application.Features.CQRS.Queries.BrandQueries;
using OnionArcCQRS.Application.Features.CQRS.Queries.CarQueries;
using OnionArcCQRS.Application.Features.CQRS.Results.BrandResults;
using OnionArcCQRS.Application.Features.CQRS.Results.CarResults;
using OnionArcCQRS.Application.Interfaces;
using OnionArcCQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
        {
            var values = _repository.GetByIdAsync(query.CarID);
            return new GetCarByIdQueryResult
            {
                BrandID = values.Result.BrandID,
                BigImageUrl=values.Result.BigImageUrl,
                CoverImageUrl=values.Result.CoverImageUrl,
                Fuel=values.Result.Fuel,
                CarID=values.Result.CarID,
                Transmission=values.Result.Transmission,
                Seat=values.Result.Seat,
                Km=values.Result.Km,
                Luggage=values.Result.Luggage,
                Model=values.Result.Model,
            };
        }
    }
}
