﻿using OnionArcCQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.CQRS.Commands.BrandCommand
{
    public class CreateBrandCommand
    {
        public string BrandName { get; set; }
    }
}
