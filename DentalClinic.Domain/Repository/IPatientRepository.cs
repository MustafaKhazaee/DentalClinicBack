using DentalClinic.Domain.Common;
using DentalClinic.Domain.Entities;
namespace DentalClinic.Domain.Repository {
    public interface IPatientRepository : IGenericRepository<Patient>{
        public Task<PagedResult<Patient>> GetFilteredPagedAsync(string firstname, string lastname, string mobile, int pageIndex, int pageSize);
    }
}
