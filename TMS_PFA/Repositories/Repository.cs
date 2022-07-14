
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TMS_PFA.Data;
using TMS_PFA.Models;

namespace TMS_PFA.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        public ApplicationDbContext Context { get; }
        private DbSet<T> table = null;

        public Repository(ApplicationDbContext appDbContext)
        {
            Context = appDbContext;
            table = appDbContext.Set<T>();

        }

        public async Task<IList<T>> GetAll()
        {
            try
            {
                return await Context.Set<T>().ToListAsync();
            }
            catch (Exception)
            {
                return new List<T>();
            }
        }

        public async Task<T> GetById(Guid id)
        {

            return await table.AsNoTracking().SingleOrDefaultAsync(e => e.Id == id);


        }

        public async Task Add(T obj)
        {

            await table.AddAsync(obj);
            Context.SaveChanges();

            //table.Add(obj);
            //return Task.FromResult(Context.SaveChanges());

        }

        public async Task Delete(T obj)
        {

            table.Remove(obj);
            //await Context.SaveChangesAsync();
            await Task.FromResult(Context.SaveChanges());
           

        }




        public async Task Update(T obj)
        {


            table.Update(obj);
            //await Context.SaveChangesAsync();
            await Task.FromResult(Context.SaveChanges());



        }

        public IList<T> GetIncludes(params Expression<Func<T, object>>[] includes)
        {

            IQueryable<T> query = table.Include(includes[0]);
            foreach (var include in includes.Skip(1))
            {
                query = query.Include(include);
            }
            return query.ToList();
        }
    }
}
