using DentalClinic.Domain.Common;
using DentalClinic.Domain.Entities;
namespace DentalClinic.Domain.Repository {
    public interface IRoleRepository : IGenericRepository<Role> {
        public Task<PagedResult<Role>> GetFilteredPagedAsync(string rolename, int pageIndex, int pageSize);

    }
}
