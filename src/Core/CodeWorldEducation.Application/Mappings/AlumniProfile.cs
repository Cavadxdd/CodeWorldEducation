using AutoMapper;
using CodeWorldEducation.Application.Common.Alumni;
using CodeWorldEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Mappings
{
    public class AlumniProfile : Profile
    {
        public AlumniProfile()
        {
            CreateMap<Alumni, GetAlumniDto>();
            CreateMap<CreateAlumniDto, Alumni>();
            CreateMap<UpdateAlumniDto, Alumni>();
        }
    }
}
