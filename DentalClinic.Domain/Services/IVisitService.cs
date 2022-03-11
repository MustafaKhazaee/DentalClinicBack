using DentalClinic.Domain.Common;
using DentalClinic.Domain.Entities;
using DentalClinic.Domain.Models;

namespace DentalClinic.Domain.Services {
    public interface IVisitService {
        public Task<PagedResult<Visit>> GetFilteredPagedAsync(string patientName, string patientMobile, string doctorName, int pageIndex, int pageSize);
        public Task<int> AddAsync(VisitModel visit);
        public Task<int> RemoveAsync(Guid Id);
        public Task<int> UpdateAsync(VisitModel visit, Guid id);
        public Task<PagedResult<Visit>> GetTodaysVisits();
    }
}
