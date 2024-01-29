using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.CQRS.Commands.AboutCommand
{
    public class RemoveAboutCommand
    {
        public RemoveAboutCommand(int aboutID)
        {
            AboutID = aboutID;
        }

        public int AboutID { get; set; }
 
    }
}
