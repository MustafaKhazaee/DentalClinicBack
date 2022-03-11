using DentalClinic.Domain.Common;
using DentalClinic.Domain.Entities;
namespace DentalClinic.Domain.Services {
    public interface IEmployeeService {
        public Task<Employee> FindByUserId(Guid Id);
        public Task<PagedResult<Employee>> GetFilteredPagedAsync(string firstname, string lastname, int pageIndex, int pageSize);
        public Task<int> AddAsync(Employee employee);
        public Task<int> RemoveAsync(Guid Id);
        public Task<int> UpdateAsync(Employee employee, Guid id);
    }
}
