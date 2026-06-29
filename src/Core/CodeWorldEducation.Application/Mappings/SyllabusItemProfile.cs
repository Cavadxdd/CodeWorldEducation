using AutoMapper;
using CodeWorldEducation.Application.Common.SyllabusItem;
using CodeWorldEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Mappings
{
    public class SyllabusItemProfile : Profile
    {
        public SyllabusItemProfile()
        {
            CreateMap<SyllabusItem, GetSyllabusItemDto>();
            CreateMap<CreateSyllabusItemDto, SyllabusItem>();
            CreateMap<UpdateSyllabusItemDto, SyllabusItem>();
        }
    }
}
