using DentalClinic.Domain.Common;
using DentalClinic.Domain.Entities;
namespace DentalClinic.Domain.Services {
    public interface IRoleService {
        public Task<PagedResult<Role>> GetFilteredPagedAsync(string rolename, int pageIndex, int pageSize);
        public Task<int> AddAsync(string rolename, IEnumerable<string> permissions);
        public Task<int> RemoveAsync(Guid Id);
        public Task<int> UpdateAsync(Guid roleId, string name, IEnumerable<string> list);
        public Task<IEnumerable<Role>> GetAllAsync();
        public Task<Role> GetByIdAsync(Guid id);
    }
}
