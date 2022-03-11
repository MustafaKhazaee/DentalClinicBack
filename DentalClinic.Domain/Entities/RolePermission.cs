﻿
namespace DentalClinic.Domain.Entities {
    public class RolePermission {
        public RolePermission() {

        }
        public Guid RoleId { get; set; }
        public virtual Role Role { get; set; }
        public Guid PermissionId { get; set; }
        public virtual Permission Permission { get; set; }
    }
}