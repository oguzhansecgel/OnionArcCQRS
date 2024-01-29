using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.CQRS.Commands.BannerCommand
{
    public class RemoveBannerCommand
    {
        public RemoveBannerCommand(int bannerID)
        {
            BannerID = bannerID;
        }

        public int BannerID { get; set; }
 
    }
}
