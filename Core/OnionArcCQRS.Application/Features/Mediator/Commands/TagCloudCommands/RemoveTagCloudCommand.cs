using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.Mediator.Commands.TagCloudCommands
{
    public class RemoveTagCloudCommand :IRequest
    {
        public RemoveTagCloudCommand(int tagCloudId)
        {
            TagCloudId = tagCloudId;
        }

        public int TagCloudId { get; set; }

    }
}
