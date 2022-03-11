using DentalClinic.Domain.Common;
using DentalClinic.Domain.Entities;

namespace DentalClinic.Domain.Services {
    public interface IPatientService {
        public Task<IEnumerable<Patient>> GetAllAsync();
        public Task<PagedResult<Patient>> GetFilteredPagedAsync(string firstname, string lastname, string mobile, int pageIndex, int pageSize);
        public Task<int> AddAsync(Patient patient);
        public Task<int> RemoveAsync(Guid Id);
        public Task<int> UpdateAsync(Patient patient, Guid id);
    }
}
