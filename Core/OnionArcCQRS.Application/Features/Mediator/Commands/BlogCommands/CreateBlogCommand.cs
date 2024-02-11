using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.Mediator.Commands.BlogCommands
{
    public class CreateBlogCommand : IRequest
    {
        public string BlogTitle { get; set; }
        public string CoverImage { get; set; }
        public DateTime CreatedTime { get; set; }
        public int CategoryID { get; set; }
        public int AuthorID { get; set; }
    }
}
