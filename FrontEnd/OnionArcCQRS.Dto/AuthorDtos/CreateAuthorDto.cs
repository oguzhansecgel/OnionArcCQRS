﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Dto.AuthorDtos
{
    public class CreateAuthorDto
    {
        public string AuthorName { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
