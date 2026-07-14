using AutoMapper;
using CodeWorldEducation.Application.Common.Course;
using CodeWorldEducation.Application.Common.Courses;
using CodeWorldEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Mappings
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, GetCourseListDto>()
                .ForMember(dest => dest.CategoryName,
                    opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<Course, GetCourseDetailDto>()
                .ForMember(dest => dest.CategoryName,
                    opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.Mentors,
                    opt => opt.MapFrom(src =>
                        src.MentorCourses.Select(mc => mc.Mentor).ToList()));

            CreateMap<CreateCourseDto, Course>();
            CreateMap<UpdateCourseDto, Course>();
        }
    }
}
