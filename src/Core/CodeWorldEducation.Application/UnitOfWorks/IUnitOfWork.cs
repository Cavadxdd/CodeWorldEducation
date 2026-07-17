using CodeWorldEducation.Application.Repositories;
using CodeWorldEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.UnitOfWorks
{
	public interface IUnitOfWork : IAsyncDisposable
	{
        IGenericRepository<Category> CategoryRepository { get; }
        ICourseRepository CourseRepository { get; }
        IGenericRepository<Domain.Entities.Application> ApplicationRepository { get; }
        IMentorRepository MentorRepository { get; }
        IGenericRepository<MentorCourse> MentorCourseRepository { get; }
        IAlumniRepository AlumniRepository { get; }
        IEndpointRepository EndpointRepository { get; }
        IGenericRepository<EndpointRole> EndpointRoleRepository { get; }
        Task<int> SaveChangesAsync();
	}
}
