using OnionArcCQRS.Application.Features.CQRS.Queries.ContactQueries;
using OnionArcCQRS.Application.Features.CQRS.Results.CategoryResults;
using OnionArcCQRS.Application.Features.CQRS.Results.ContactResults;
using OnionArcCQRS.Application.Interfaces;
using OnionArcCQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactByIdQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query)
        {
            var values = _repository.GetByIdAsync(query.ContactID);
            return new GetContactByIdQueryResult
            {
                 ContactID = values.Result.ContactID,
                 Subject = values.Result.Subject,
                 SendDate = values.Result.SendDate,
                 Name = values.Result.Name,
                 Email = values.Result.Email,
                 Message = values.Result.Message
            };
        }
    }
}
