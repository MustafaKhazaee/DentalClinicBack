using DentalClinic.Domain.Common;
using DentalClinic.Domain.Entities;
namespace DentalClinic.Domain.Repository {
    public interface IEmployeeRepository : IGenericRepository<Employee> {
        public Task<List<Guid?>> Guids();
        public Task<PagedResult<Employee>> GetFilteredPagedAsync(string firstname, string lastname, int pageIndex, int pageSize);

    }
}
