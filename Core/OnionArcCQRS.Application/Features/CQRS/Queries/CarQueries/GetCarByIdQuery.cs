using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.CQRS.Queries.CarQueries
{
    public class GetCarByIdQuery
    {
        public GetCarByIdQuery(int carID)
        {
            CarID = carID;
        }

        public int CarID { get; set; }
    }
}
