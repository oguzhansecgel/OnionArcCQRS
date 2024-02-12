﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.Mediator.Results.BlogResults
{
    public class GetBlogByAuthorIdQueryResult 
    {
        public int BlogId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorDescription { get; set; }
        public string AuthorImageUrl { get; set; } 
        public int AuthorID { get; set; }

    }
}
