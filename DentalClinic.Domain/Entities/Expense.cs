using DentalClinic.Domain.Common;
namespace DentalClinic.Domain.Entities {
    public class Expense : AuditableEntity {
        public Guid Id { get; set; }
        public string ItemName { get; set; }
        public int PricePerItem { set; get; }
        public int Count { set; get; }
        public DateTime? Date { get; set; }
        public string? Description { set; get; }
    }
}
