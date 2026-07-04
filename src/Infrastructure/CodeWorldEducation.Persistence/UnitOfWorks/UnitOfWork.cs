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

        public UnitOfWork(AppDbContext context)
		{
			_context = context;
            CategoryRepository = new GenericRepository<Category>(_context);
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
