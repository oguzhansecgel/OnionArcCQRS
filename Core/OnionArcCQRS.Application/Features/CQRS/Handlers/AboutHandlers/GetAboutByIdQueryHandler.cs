using OnionArcCQRS.Application.Features.CQRS.Queries.AboutQueries;
using OnionArcCQRS.Application.Features.CQRS.Results.AboutResults;
using OnionArcCQRS.Application.Interfaces;
using OnionArcCQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutByIdQueryHandler
    {
        private readonly IRepository<About> _repository;

        public GetAboutByIdQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery query)
        {
            var values = _repository.GetByIdAsync(query.Id);
            return new GetAboutByIdQueryResult
            {
                AboutID = values.Result.AboutID,
                Title = values.Result.Title,
                Description = values.Result.Description,
                ImageUrl = values.Result.ImageUrl,
            };
        }
    }
}
