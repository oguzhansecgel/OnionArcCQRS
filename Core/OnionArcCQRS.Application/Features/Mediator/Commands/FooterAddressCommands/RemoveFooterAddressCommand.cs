using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.Mediator.Commands.FooterAddressCommands
{
    public class RemoveFooterAddressCommand : IRequest
    {
        public RemoveFooterAddressCommand(int footerAddressID)
        {
            FooterAddressID = footerAddressID;
        }

        public int FooterAddressID { get; set; }
        
    }
}
