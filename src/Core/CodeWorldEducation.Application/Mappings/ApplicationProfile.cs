using AutoMapper;
using CodeWorldEducation.Application.Common.Applications;

namespace CodeWorldEducation.Application.Mappings
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<CodeWorldEducation.Domain.Entities.Application, GetApplicationDto>()
                .ForMember(dest => dest.CourseName,
                    opt => opt.MapFrom(src => src.Course != null ? src.Course.Name : null));

            CreateMap<CreateApplicationDto, CodeWorldEducation.Domain.Entities.Application>()
                .ForMember(dest => dest.CvFilePath, opt => opt.Ignore())
                .ForMember(dest => dest.CvOriginalFileName, opt => opt.Ignore());
        }
    }
}