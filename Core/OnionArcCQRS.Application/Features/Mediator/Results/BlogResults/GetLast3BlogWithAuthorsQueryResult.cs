using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.Mediator.Results.BlogResults
{
    public class GetLast3BlogWithAuthorsQueryResult
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string CoverImage { get; set; }
        public DateTime CreatedTime { get; set; }
        public int CategoryID { get; set; }
        public int AuthorID { get; set; }
        public string AuthorName { get; set; }
    }
}
