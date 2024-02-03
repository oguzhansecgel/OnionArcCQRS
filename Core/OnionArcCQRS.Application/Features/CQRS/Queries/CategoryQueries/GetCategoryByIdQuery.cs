using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.CQRS.Queries.CategoruQueries
{
    public class GetCategoryByIdQuery
    {
        public GetCategoryByIdQuery(int categoryID)
        {
            CategoryID = categoryID;
        }

        public int CategoryID { get; set; }
 
    }
}
