using EducationPortal.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Infrastructure.Data
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly DbContext context;

        public Repository(DbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(T entity)
        {
            await this.context.Set<T>().AddAsync(entity);
            await this.context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await this.context.Set<T>().AddRangeAsync(entities);
            await this.context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(ExpressionSpecification<T> expressionSpecification)
        {
            return await this.context.Set<T>().Where(expressionSpecification.Expression).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await this.context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id) => await this.context.Set<T>().FindAsync(id);

        public async Task<T> GetAsync(ExpressionSpecification<T> expressionSpecification)
        {
            var query = this.context.Set<T>().Where(expressionSpecification.Expression);

            if (expressionSpecification.Includes != null)
            {
                foreach (var include in expressionSpecification.Includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.FirstOrDefaultAsync();
        }

        private void Include(ExpressionSpecification<T> expressionSpecification)
        {
            throw new NotImplementedException();
        }

        public void ModifyState(T entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            this.context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            this.context.Set<T>().RemoveRange(entities);
        }

        public async Task SaveChangesAsync() => await this.context.SaveChangesAsync();

        public async Task UpdateAsync(T entity)
        {
            this.context.Set<T>().Update(entity);
            await this.context.SaveChangesAsync();
        }
    }
}