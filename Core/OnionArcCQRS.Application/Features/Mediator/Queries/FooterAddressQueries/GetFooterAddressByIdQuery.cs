using MediatR;
using OnionArcCQRS.Application.Features.Mediator.Results.FooterAddressResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.Mediator.Queries.FooterAddressQueries
{
    public class GetFooterAddressByIdQuery : IRequest<GetFooterAddressByIdQueryResults>
    {
        public GetFooterAddressByIdQuery(int footerAddressID)
        {
            FooterAddressID = footerAddressID;
        }

        public int FooterAddressID { get; set; }
    }
}
