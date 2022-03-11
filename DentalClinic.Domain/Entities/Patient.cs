using DentalClinic.Domain.Common;
using DentalClinic.Domain.Enums;

namespace DentalClinic.Domain.Entities {
    public class Patient : AuditableEntity {
        public Patient() {
            this.Visits = new List<Visit>();
        }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public Gender Gender { get; set; } = 0; // 0 is male
        public byte? Age { get; set; }
        public string? Mobile { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
