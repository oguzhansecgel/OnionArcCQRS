using MediatR;
using OnionArcCQRS.Application.Features.Mediator.Queries.LocationQueries;
using OnionArcCQRS.Application.Features.Mediator.Results.FooterAddressResults;
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
    public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, List<GetLocationQueryResults>>
    {
        private readonly IRepository<Location> _repository;

        public GetLocationQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLocationQueryResults>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {

            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetLocationQueryResults
            {
                LocationID = x.LocationID,
                LocationName = x.LocationName,
            }).ToList();
        }
    }
}
