using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Dto.BlogDtos
{
    public class ResultAllBlogsWithAuthorDto
    {
        public int blogId { get; set; }
        public string blogTitle { get; set; }
        public string authorName { get; set; }
        public string AuthorDescription { get; set; }
        public string AuthorImageUrl { get; set; }
        public object categoryName { get; set; }
        public string coverImage { get; set; }
        public DateTime createdTime { get; set; }
        public int categoryID { get; set; }
        public int authorID { get; set; }
        public string Description { get; set; }


    }
}
