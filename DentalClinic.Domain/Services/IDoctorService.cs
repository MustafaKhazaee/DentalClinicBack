using DentalClinic.Domain.Common;
using DentalClinic.Domain.Entities;
namespace DentalClinic.Domain.Services {
    public interface IDoctorService {
        public Task<PagedResult<Doctor>> GetFilteredPagedAsync(string firstname, string lastname, int pageIndex, int pageSize);
        public Task<int> AddAsync(Doctor doctor);
        public Task<IEnumerable<Doctor>> GetAllAsync();
        public Task<Doctor> FindByUserId(Guid Id);
        public Task<int> RemoveAsync(Guid Id);
        public Task<int> UpdateAsync(Doctor doctor, Guid id);
    }
}
