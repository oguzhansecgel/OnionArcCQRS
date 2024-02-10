using MediatR;
using OnionArcCQRS.Application.Features.Mediator.Results.SocialMediaResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.Mediator.Queries.SocialMediaQueries
{
    public class GetSocialMediaByIdQuery : IRequest<GetSocialMediaByIdQueryResult>
    {
        public GetSocialMediaByIdQuery(int socialMediaID)
        {
            SocialMediaID = socialMediaID;
        }

        public int SocialMediaID { get; set; }
    }
}
