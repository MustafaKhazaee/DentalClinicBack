namespace DentalClinic.Domain.Entities {
    public class Permission {
        public Guid Id { get; set; }
        public string Code { set; get; }
        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}
