using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.Mediator.Commands.BlogCommands
{
    public class RemoveBlogCommand : IRequest
    {
        public RemoveBlogCommand(int blogId)
        {
            BlogId = blogId;
        }

        public int BlogId { get; set; }

    }
}
