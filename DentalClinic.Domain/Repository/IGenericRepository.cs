using System.Linq.Expressions;
namespace DentalClinic.Domain.Repository {
    public interface IGenericRepository<T> {
        public Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate);
        public Task<T> FindAsync(Guid Id);
        public Task<T> FindAsync(Expression<Func<T, bool>> predicate);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<object> AddAsync(T entity);
        public Task AddRangeAsync(IEnumerable<T> entities);
        public Task RemoveAsync(Guid Id);
        public void RemoveRange(IEnumerable<T> entities);
        public Task<int> CountAsync();
        public void MarkAsDetached(T entity);
        public void MarkAsUnchanged(T entity);
        public void MarkAsModified(T entity);
        public void MarAsDeleted(T entity);
        public void MarAsAdded(T entity);
    }
}
