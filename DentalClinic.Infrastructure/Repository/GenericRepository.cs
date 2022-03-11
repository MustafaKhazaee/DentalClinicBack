using System.Linq.Expressions;
using DentalClinic.Domain.Repository;
using Microsoft.EntityFrameworkCore;
namespace DentalClinic.Infrastructure.Repository {
    public class GenericRepository<T> : IGenericRepository<T> where T : class {
        protected readonly ApplicationDbContext context;
        public GenericRepository (ApplicationDbContext applicationDbContext) => context = applicationDbContext;
        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate) =>
            await Task.FromResult(context.Set<T>().Where<T>(predicate).ToList<T>());
        public async Task<T> FindAsync (Guid Id) => await context.Set<T>().FindAsync(Id);
        public async Task<IEnumerable<T>> GetAllAsync () => await Task.FromResult(context.Set<T>().ToList());
        public async Task<object> AddAsync(T entity) => await context.Set<T>().AddAsync(entity);
        public async Task AddRangeAsync (IEnumerable<T> entities) => await context.AddRangeAsync(entities);
        public async Task RemoveAsync (Guid Id) => await Task.FromResult(context.Set<T>().Remove(await FindAsync(Id)));
        public void RemoveRange (IEnumerable<T> entities) => context.RemoveRange(entities);
        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate) => 
            await Task.FromResult(context.Set<T>().FirstOrDefault(predicate));
        public async Task<int> CountAsync() => await context.Set<T>().CountAsync();
        public void MarkAsDetached (T entity) => context.Entry(entity).State = EntityState.Detached;
        public void MarkAsUnchanged (T entity) => context.Entry(entity).State = EntityState.Unchanged;
        public void MarkAsModified (T entity) => context.Entry(entity).State = EntityState.Modified;
        public void MarAsDeleted (T entity) => context.Entry(entity).State = EntityState.Deleted;
        public void MarAsAdded (T entity) => context.Entry(entity).State = EntityState.Added;
    }
}
