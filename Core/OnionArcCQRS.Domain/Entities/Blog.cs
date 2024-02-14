using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Domain.Entities
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string CoverImage { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Description { get; set; }

        public List<TagCloud> TagClouds { get; set; }
        public List<Comment> Comments{ get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public int AuthorID { get; set; }
        public Author Author { get; set; }

    }
}
