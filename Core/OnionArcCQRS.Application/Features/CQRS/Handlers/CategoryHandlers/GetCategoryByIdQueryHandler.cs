using OnionArcCQRS.Application.Features.CQRS.Queries.BrandQueries;
using OnionArcCQRS.Application.Features.CQRS.Queries.CategoruQueries;
using OnionArcCQRS.Application.Features.CQRS.Results.BrandResults;
using OnionArcCQRS.Application.Features.CQRS.Results.CategoryResults;
using OnionArcCQRS.Application.Interfaces;
using OnionArcCQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly IRepository<Category> _repository;

        public GetCategoryByIdQueryHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }
        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
        {
            var values = _repository.GetByIdAsync(query.CategoryID);
            return new GetCategoryByIdQueryResult
            {
                CategoryID = values.Result.CategoryID,
                CategoryName=values.Result.CategoryName
            };
        }
    }
}
