using AutoMapper;
using CodeWorldEducation.Application.Common.Mentor;
using CodeWorldEducation.Application.Common.Mentors;
using CodeWorldEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Mappings
{
    
    public class MentorProfile : Profile
    {
        public MentorProfile()
        {
            CreateMap<Mentor, GetMentorDto>()
                .ForMember(dest => dest.Technologies,
                    opt => opt.MapFrom(src =>
                    JsonSerializer.Deserialize<List<string>>(src.Technologies,
                    new JsonSerializerOptions())));

            CreateMap<CreateMentorDto, Mentor>()
                .ForMember(dest => dest.Technologies,
                    opt => opt.MapFrom(src =>
                    JsonSerializer.Serialize(src.Technologies,
                    new JsonSerializerOptions())));

            CreateMap<UpdateMentorDto, Mentor>()
                .ForMember(dest => dest.Technologies,
                    opt => opt.MapFrom(src =>
                        JsonSerializer.Serialize(src.Technologies,
                            new JsonSerializerOptions())));
        }
    }
}
