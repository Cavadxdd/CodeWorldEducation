using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Courses.Queries.GetCourseById
{
    public class GetCourseByIdQueryRequest : IRequest<GetCourseByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
