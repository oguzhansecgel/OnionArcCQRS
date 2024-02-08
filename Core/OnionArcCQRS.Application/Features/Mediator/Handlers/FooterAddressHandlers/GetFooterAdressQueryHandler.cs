using MediatR;
using OnionArcCQRS.Application.Features.Mediator.Queries.FooterAddressQueries;
using OnionArcCQRS.Application.Features.Mediator.Results.FeatuesResults;
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
    public class GetFooterAdressQueryHandler : IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressQueryResults>>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAdressQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFooterAddressQueryResults>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetFooterAddressQueryResults
            {
               Address = x.Address,
               Description = x.Description,
               Email = x.Email,
               FooterAddressID = x.FooterAddressID,
               Phone = x.Phone
            }).ToList();
        }
    }
}
