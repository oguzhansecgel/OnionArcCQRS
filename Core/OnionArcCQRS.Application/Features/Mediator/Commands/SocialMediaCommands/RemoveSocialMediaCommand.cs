using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.Mediator.Commands.SocialMediaCommands
{
    public class RemoveSocialMediaCommand : IRequest
    {
        public RemoveSocialMediaCommand(int socialMediaID)
        {
            SocialMediaID = socialMediaID;
        }

        public int SocialMediaID { get; set; }
    }
}
