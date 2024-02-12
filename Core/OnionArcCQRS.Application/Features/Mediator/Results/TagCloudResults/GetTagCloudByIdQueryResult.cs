using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.Mediator.Results.TagCloudResults
{
    public class GetTagCloudByIdQueryResult
    {
        public int TagCloudId { get; set; }
        public string TagCloudTitle { get; set; }
        public int BlogID { get; set; }
    }
}
