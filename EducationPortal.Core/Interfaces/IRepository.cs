namespace EducationPortal.Core.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRepository<T>
        where T : class
    {
        Task AddAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entities);

        Task UpdateAsync(T entity);

        void ModifyState(T entity);

        Task<IEnumerable<T>> FindAsync(ExpressionSpecification<T> expressionSpecification);

        Task<T> GetByIdAsync(int id);

        Task<T> GetAsync(ExpressionSpecification<T> expressionSpecification);

        Task<IEnumerable<T>> GetAllAsync(ExpressionSpecification<T> expressionSpecification = default);

        void RemoveRange(IEnumerable<T> entities);

        void Remove(T entity);

        Task SaveChangesAsync();

        //void Include(ExpressionSpecification<T> expressionSpecification);
    }
}