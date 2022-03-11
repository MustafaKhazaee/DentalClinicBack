
using DentalClinic.Domain.Entities;
using DentalClinic.Domain.Enums;

namespace DentalClinic.Domain.Models {
    public class VisitModel {
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        public Guid PatientId { get; set; }
        public Patient? Patient { get; set; }
        public string? Room { set; get; }
        public int? PreOperationFee { get; set; }
        public int? PostOperationFee { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public DateTime? DoneDate { get; set; }
        public Operation Operation { get; set; }
        public string? Description { get; set; }
        public PriorityLevel PriorityLevel { set; get; }
    }
}
