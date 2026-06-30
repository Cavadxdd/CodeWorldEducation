using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.UnitOfWorks
{
	public interface IUnitOfWork : IAsyncDisposable
	{
		Task<int> SaveChangesAsync();
	}
}
