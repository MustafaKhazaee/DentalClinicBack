using DentalClinic.Domain.Common;
using DentalClinic.Domain.Entities;
using DentalClinic.Domain.Repository;

namespace DentalClinic.Infrastructure.Repository {
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository {
        public EmployeeRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) {

        }

        public async Task<PagedResult<Employee>> GetFilteredPagedAsync(string firstname, string lastname, int pageIndex, int pageSize) =>
            await context.Employees.Where(e => (e.FirstName.Contains(firstname) || firstname.Equals("null")) &&
                (e.LastName.Contains(lastname) || lastname.Equals("null"))).GetPaged<Employee>(pageIndex, pageSize);

        public async Task<List<Guid?>> Guids() => await Task.FromResult(context.Employees.Select(e => e.AppUserId).ToList());
    }
}
