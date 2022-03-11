using DentalClinic.Domain.Common;
using DentalClinic.Domain.Enums;
namespace DentalClinic.Domain.Entities {
    public class AppUser : AuditableEntity {
        public AppUser() {
            this.AppUserRoles = new List<AppUserRole>();
        }
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Salt { get; set; }
        public bool isLocked { get; set; } = false;
        public UserType UserType { get; set; }
        public virtual ICollection<AppUserRole> AppUserRoles { get; set; }
    }
}
