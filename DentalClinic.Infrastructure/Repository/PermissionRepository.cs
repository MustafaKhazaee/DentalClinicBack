using DentalClinic.Domain.Entities;
using DentalClinic.Domain.Repository;
namespace DentalClinic.Infrastructure.Repository {
    public class PermissionRepository : GenericRepository<Permission>, IPermissionRepository{
        public PermissionRepository(ApplicationDbContext applicationDbContext) : base (applicationDbContext) {

        }
    }
}
