using CodeWorldEducation.Application.Repositories;
using CodeWorldEducation.Application.UnitOfWorks;
using CodeWorldEducation.Domain.Entities;
using CodeWorldEducation.Persistence.Contexts;
using CodeWorldEducation.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Persistence.UnitOfWorks
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDbContext _context;
        public IGenericRepository<Category> CategoryRepository { get; private set; }
        public ICourseRepository CourseRepository { get; private set; }
        public IGenericRepository<Domain.Entities.Application> ApplicationRepository { get; private set; }
        public IMentorRepository MentorRepository { get; private set; }
        public IGenericRepository<MentorCourse> MentorCourseRepository { get; private set; }
		public IAlumniRepository AlumniRepository { get; private set; }
        public IEndpointRepository EndpointRepository { get; private set; }
        public IGenericRepository<EndpointRole> EndpointRoleRepository { get; private set; }

        public UnitOfWork(AppDbContext context)
		{
			_context = context;
            CategoryRepository = new GenericRepository<Category>(_context);
            CourseRepository = new CourseRepository(_context);
            ApplicationRepository = new GenericRepository<Domain.Entities.Application>(_context);
            MentorRepository = new MentorRepository(_context);
            MentorCourseRepository = new GenericRepository<MentorCourse>(_context);
			AlumniRepository = new AlumniRepository(_context);
            EndpointRepository = new EndpointRepository(_context);
            EndpointRoleRepository = new GenericRepository<EndpointRole>(_context);
        }

		public async Task<int> SaveChangesAsync()
		{
			return await _context.SaveChangesAsync();
		}

		public async ValueTask DisposeAsync()
		{
			await _context.DisposeAsync();
			GC.SuppressFinalize(this);
		}
	}
}
