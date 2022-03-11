using DentalClinic.Domain.Common;
namespace DentalClinic.Infrastructure.Repository {
    public static class PagedResultExtensionMethod {
        public async static Task<PagedResult<T>> GetPaged<T>(this IQueryable<T> query, int pageIndex, int pageSize) {
            PagedResult<T> result = new PagedResult<T> (pageIndex, pageSize, await Task.FromResult(query.Count()));
            result.list = await Task.FromResult(query.Skip((pageIndex) * pageSize).Take(pageSize).ToList());
            return result;
        }
    }
}