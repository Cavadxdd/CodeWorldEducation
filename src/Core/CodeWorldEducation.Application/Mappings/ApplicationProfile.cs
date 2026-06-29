using AutoMapper;
using CodeWorldEducation.Application.Common.Application;
using CodeWorldEducation.Application.Common.Applications;
using CodeWorldEducation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Mappings
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Domain.Entities.Application, GetApplicationDto>()
                .ForMember(dest => dest.CourseName,
                    opt => opt.MapFrom(src =>
                        src.Course != null ? src.Course.Name : null));

            CreateMap<CreateApplicationDto, Domain.Entities.Application>()
                .ForMember(dest => dest.Status,
                    opt => opt.MapFrom(src => ApplicationStatus.New))
                .ForMember(dest => dest.SubmittedAt,
                    opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<UpdateApplicationDto, Domain.Entities.Application>();
        }
    }
}
