﻿using MediatR;
using OnionArcCQRS.Application.Features.Mediator.Commands.TestimonialCommands;
using OnionArcCQRS.Application.Interfaces;
using OnionArcCQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _repository;

        public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.TestimonialID);
            values.Title = request.Title;
            values.TestimonialID = request.TestimonialID;
            values.Comment = request.Comment;
            values.Name = request.Name;
            values.ImageUrl = request.ImageUrl;
            await _repository.UpdateAsync(values);
        }
    }
}
