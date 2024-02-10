using MediatR;
using OnionArcCQRS.Application.Features.Mediator.Queries.ServiceQueries;
using OnionArcCQRS.Application.Features.Mediator.Results.ServiceResults;
using OnionArcCQRS.Application.Interfaces;
using OnionArcCQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
    {
        private readonly IRepository<Service> _repository;

        public GetServiceByIdQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetByIdAsync(request.ServiceID);
            return new GetServiceByIdQueryResult
            {
                ServiceID = values.Result.ServiceID,
                Description = values.Result.Description,
                IconUrl = values.Result.IconUrl,
                Title = values.Result.Title,
            };
        }
    }
}
