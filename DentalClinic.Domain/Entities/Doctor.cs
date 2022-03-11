using DentalClinic.Domain.Common;
using DentalClinic.Domain.Enums;

namespace DentalClinic.Domain.Entities {
    public class Doctor : AuditableEntity {
        public Doctor() {
            this.Visits = new List<Visit>();
        }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; } = 0; // 0 is male
        public DateTime? DateOfBirth { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
        public Guid? AppUserId { get; set; }
        public virtual AppUser? AppUser { get; set; }
    }
}
