using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.Mediator.Commands.PricingCommands
{
    public class RemovePricingCommand : IRequest
    {
        public RemovePricingCommand(int pricingID)
        {
            PricingID = pricingID;
        }

        public int PricingID { get; set; }
    }
}
