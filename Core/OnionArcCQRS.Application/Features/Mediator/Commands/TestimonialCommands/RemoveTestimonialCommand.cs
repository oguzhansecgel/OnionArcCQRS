using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.Mediator.Commands.TestimonialCommands
{
    public class RemoveTestimonialCommand : IRequest
    {
        public RemoveTestimonialCommand(int testimonialID)
        {
            TestimonialID = testimonialID;
        }

        public int TestimonialID { get; set; }

    }
}
