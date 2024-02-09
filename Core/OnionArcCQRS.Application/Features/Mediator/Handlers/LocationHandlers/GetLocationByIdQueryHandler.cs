using MediatR;
using OnionArcCQRS.Application.Features.Mediator.Queries.LocationQueries;
using OnionArcCQRS.Application.Features.Mediator.Results.LocationResults;
using OnionArcCQRS.Application.Interfaces;
using OnionArcCQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
    {
        private readonly IRepository<Location> _repository;

        public GetLocationByIdQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetByIdAsync(request.LocationID);
            return new GetLocationByIdQueryResult
            {
                LocationID = values.Result.LocationID,
                LocationName = values.Result.LocationName,
            };
        }
    }
}
