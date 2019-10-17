﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.TemplateFeature.Queries.GetTemplateAll
{
    public class TemplateDto : IMapFrom<TemplateEntity>
    {
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TemplateEntity, TemplateDto>();
        }
    }


}
