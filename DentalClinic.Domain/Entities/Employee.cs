using DentalClinic.Domain.Common;
using DentalClinic.Domain.Enums;

namespace DentalClinic.Domain.Entities {
    public class Employee : AuditableEntity {
        public Employee() {

        }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; } = 0;
        public DateTime? DateOfBirth { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public Guid? AppUserId { get; set; }
        public virtual AppUser? AppUser { get; set; }
    }
}
