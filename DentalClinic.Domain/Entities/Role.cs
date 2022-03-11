using DentalClinic.Domain.Common;
namespace DentalClinic.Domain.Entities {
    public class Role {
        public Role() {
            this.AppUserRoles = new List<AppUserRole>();
            this.RolePermissions = new List<RolePermission>();
        }
        public Guid Id { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<AppUserRole> AppUserRoles { get; set; }
        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}
