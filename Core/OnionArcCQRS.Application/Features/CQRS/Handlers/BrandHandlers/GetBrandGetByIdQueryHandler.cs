using OnionArcCQRS.Application.Features.CQRS.Queries.BannerQueries;
using OnionArcCQRS.Application.Features.CQRS.Queries.BrandQueries;
using OnionArcCQRS.Application.Features.CQRS.Results.BannerResults;
using OnionArcCQRS.Application.Features.CQRS.Results.BrandResults;
using OnionArcCQRS.Application.Interfaces;
using OnionArcCQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandGetByIdQueryHandler
    {
        private readonly IRepository<Brand> _repository;

        public GetBrandGetByIdQueryHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }
        public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery query)
        {
            var values = _repository.GetByIdAsync(query.BrandID);
            return new GetBrandByIdQueryResult
            {
                BrandID = values.Result.BrandID,
                BrandName=values.Result.BrandName
            };
        }

    }
}
