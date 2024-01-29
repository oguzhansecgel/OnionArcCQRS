using OnionArcCQRS.Application.Features.CQRS.Queries.AboutQueries;
using OnionArcCQRS.Application.Features.CQRS.Queries.BannerQueries;
using OnionArcCQRS.Application.Features.CQRS.Results.AboutResults;
using OnionArcCQRS.Application.Features.CQRS.Results.BannerResults;
using OnionArcCQRS.Application.Interfaces;
using OnionArcCQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerByIdQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery query)
        {
            var values = _repository.GetByIdAsync(query.Id);
            return new GetBannerByIdQueryResult
            {
                BannerID=values.Result.BannerID,
                Description=values.Result.Description,
                Title=values.Result.Title,
                VideoDescription=values.Result.VideoDescription,
                VideoUrl=values.Result.VideoUrl,
            };
        }
    }
}
