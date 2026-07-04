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
        Task<int> SaveChangesAsync();
	}
}
