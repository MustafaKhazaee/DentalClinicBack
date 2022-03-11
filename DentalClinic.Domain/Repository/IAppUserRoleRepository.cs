using DentalClinic.Domain.Entities;

namespace DentalClinic.Domain.Repository {
    public interface IAppUserRoleRepository : IGenericRepository<AppUserRole> {
        public Task<IEnumerable<AppUserRole>> GetRolesAndPermissionsByUserId(Guid Id);
    }
}

