using DentalClinic.Domain.Repository;
using DentalClinic.Domain.Services;
namespace DentalClinic.Infrastructure.Services {
    public class PermissionService : IPermissionService {
        private IUnitOfWork UnitOfWork { get; set; }
        public PermissionService (IUnitOfWork unitOfWork) {
            UnitOfWork = unitOfWork;
        }
    }
}
