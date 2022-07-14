using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TMS_PFA.Repositories
{
    public interface IRepository<T>
    {
		Task Add(T obj);

		Task<T> GetById(Guid id);

		Task<IList<T>> GetAll();

		Task Delete(T obj);

		Task Update(T obj);

		IList<T> GetIncludes(params Expression<Func<T, Object>>[] includes);

	}
}
