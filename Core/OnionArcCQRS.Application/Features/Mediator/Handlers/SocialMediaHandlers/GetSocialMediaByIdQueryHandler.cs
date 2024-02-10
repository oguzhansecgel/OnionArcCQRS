using MediatR;
using OnionArcCQRS.Application.Features.Mediator.Queries.SocialMediaQueries;
using OnionArcCQRS.Application.Features.Mediator.Results.ServiceResults;
using OnionArcCQRS.Application.Features.Mediator.Results.SocialMediaResults;
using OnionArcCQRS.Application.Interfaces;
using OnionArcCQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.SocialMediaID);
            return new GetSocialMediaByIdQueryResult
            {
                Icon = values.Icon,
                SocialMediaID = values.SocialMediaID,
                Name = values.Name,
                Url = values.Url
            };
        }
    }
}
