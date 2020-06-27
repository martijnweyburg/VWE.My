using System;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace VWE.My.Data
{
    public abstract class BaseRepository<T> where T : class
    {
        protected VWEDbContext context;
       
        public BaseRepository(VWEDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IQueryable<T> All()
        {
            return this.context.Set<T>();
        }

        public async Task<T> Find(int id)
        {
            return await this.context.FindAsync<T>(id);
        }

        public async Task<T> FindByAsync(Expression<Func<T, bool>> expression)
        {
            return await context.Set<T>().Where(expression).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }


        public async Task<bool> SaveChangesAsync()
        {
            return (await context.SaveChangesAsync()) >= 0;
        }
    }
}
