using DentalClinic.Domain.Common;
using DentalClinic.Domain.Entities;
namespace DentalClinic.Domain.Repository {
    public interface IAppUserRepository : IGenericRepository<AppUser> {
        public Task<PagedResult<AppUser>> GetFilteredPagedAsync(string username, int pageIndex, int pageSize);
        public Task<IEnumerable<Guid>> GetGuidsByRoleName(string rolename);
    }
}
