using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.CQRS.Commands.CarCommand
{
    public class DeleteCarCommand
    {
        public DeleteCarCommand(int carID)
        {
            CarID = carID;
        }

        public int CarID { get; set; }
    }
}
