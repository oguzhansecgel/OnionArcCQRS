using MediatR;
using OnionArcCQRS.Application.Features.Mediator.Queries.FooterAddressQueries;
using OnionArcCQRS.Application.Features.Mediator.Results.FooterAddressResults;
using OnionArcCQRS.Application.Interfaces;
using OnionArcCQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressByIdQueryHandler : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResults>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAddressByIdQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<GetFooterAddressByIdQueryResults> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetByIdAsync(request.FooterAddressID);
            return new GetFooterAddressByIdQueryResults
            {
                Address = values.Result.Address,
                FooterAddressID = values.Result.FooterAddressID,
                Description = values.Result.Description,
                Email = values.Result.Email,
                Phone = values.Result.Phone,
            };
        }
    }
}
