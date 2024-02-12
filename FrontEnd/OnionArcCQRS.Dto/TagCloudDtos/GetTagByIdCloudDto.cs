using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Dto.TagCloudDtos
{
    public class GetTagByIdCloudDto
    {

        public int TagCloudId { get; set; }
        public string TagCloudTitle { get; set; }
        public int BlogID { get; set; }

    }
}
