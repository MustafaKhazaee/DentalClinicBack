using DentalClinic.Domain.Common;
using DentalClinic.Domain.Entities;
using DentalClinic.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Infrastructure.Repository {
    public class VisitRepository : GenericRepository<Visit>, IVisitRepository {
        public VisitRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) {
            
        }

        public async Task<PagedResult<Visit>> GetFilteredPagedAsync(string patientName, string patientMobile, string doctorName, int pageIndex, int pageSize) =>
            await context.Visits.Where(v => (v.Patient.FirstName.Contains(patientName) || patientName.Equals("null")) &&
                (v.Patient.Mobile.Contains(patientMobile) || patientMobile.Equals("null")) && 
                (v.Doctor.FirstName.Contains(doctorName) || doctorName.Equals("null"))).GetPaged<Visit>(pageIndex, pageSize);

        public async Task<PagedResult<Visit>> GetTodaysVisits () =>
            await context.Visits.Select(v => new Visit {
                DoneDate = v.DoneDate,
                Description = v.Description,
                Operation = v.Operation,
                PostOperationFee = v.PostOperationFee,
                PreOperationFee = v.PreOperationFee,
                Room = v.Room,
                ScheduleDate = v.ScheduleDate,
                PriorityLevel = v.PriorityLevel,
                Doctor = new Doctor { FirstName = v.Doctor.FirstName, LastName = v.Doctor.LastName },
                Patient = new Patient { FirstName = v.Patient.FirstName, LastName = v.Patient.LastName },
            }).Where(v => v.ScheduleDate >= DateTime.Now).GetPaged<Visit>(0, 20);

        public async Task<List<Object>> GetVisitsCountRangeAsync(DateTime startDate, DateTime endDate) =>
            await Task.FromResult(context.Visits.Where(v => v.DoneDate >= startDate && v.DoneDate <= endDate)
            .GroupBy(v => v.Operation).Select(v => new { 
                operation = v.Key, 
                sum = v.Count(),
            }).ToList<Object>());
    }
}
