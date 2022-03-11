using DentalClinic.Domain.Common;
using DentalClinic.Domain.Entities;
namespace DentalClinic.Domain.Repository {
    public interface IVisitRepository : IGenericRepository<Visit> {
        public Task<PagedResult<Visit>> GetFilteredPagedAsync(string patientName, string patientMobile, string doctorName, int pageIndex, int pageSize);
        public Task<PagedResult<Visit>> GetTodaysVisits();
        public Task<List<Object>> GetVisitsCountRangeAsync(DateTime startDate, DateTime endDate);
    }
}
