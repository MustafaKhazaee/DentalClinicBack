using DentalClinic.Domain.Common;
using DentalClinic.Domain.Entities;
namespace DentalClinic.Domain.Repository {
    public interface IDoctorRepository : IGenericRepository<Doctor> {
        public Task<List<Guid?>> Guids();
        public Task<PagedResult<Doctor>> GetFilteredPagedAsync(string firstname, string lastname, int pageIndex, int pageSize);

    }
}
