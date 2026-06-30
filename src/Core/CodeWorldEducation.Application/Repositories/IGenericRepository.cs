using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Repositories
{
	public interface IGenericRepository<T> where T : class
	{
		Task<List<T>> GetAllAsync(bool asNoTracking = true);
		Task<T?> GetByIdAsync(Guid id);
		Task<T?> GetAsync(Expression<Func<T, bool>> predicate, bool asNoTracking = true);
		Task AddAsync(T entity);
		void Update(T entity);
		void Delete(T entity);
	}
}
