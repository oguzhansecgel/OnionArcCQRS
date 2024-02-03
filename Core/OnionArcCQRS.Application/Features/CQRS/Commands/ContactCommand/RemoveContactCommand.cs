using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.CQRS.Commands.ContactCommand
{
    public class RemoveContactCommand
    {
        public RemoveContactCommand(int contactID)
        {
            ContactID = contactID;
        }

        public int ContactID { get; set; }
 
    }
}
