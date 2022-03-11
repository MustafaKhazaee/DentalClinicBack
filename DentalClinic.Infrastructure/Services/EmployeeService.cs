using DentalClinic.Domain.Common;
using DentalClinic.Domain.Entities;
using DentalClinic.Domain.Repository;
using DentalClinic.Domain.Services;
using System.Net;

namespace DentalClinic.Infrastructure.Services {
    public class EmployeeService : IEmployeeService {
        private IUnitOfWork UnitOfWork { get; set; }
        public EmployeeService(IUnitOfWork unitOfWork) => UnitOfWork = unitOfWork;
        public async Task<Employee> FindByUserId(Guid Id) => await UnitOfWork.EmployeeRepository.FindAsync(e => e.AppUserId == Id);

        public async Task<PagedResult<Employee>> GetFilteredPagedAsync(string firstname, string lastname, int pageIndex, int pageSize) =>
            await UnitOfWork.EmployeeRepository.GetFilteredPagedAsync(firstname, lastname, pageIndex, pageSize);

        public async Task<int> AddAsync(Employee employee) {
            Employee e = await UnitOfWork.EmployeeRepository.FindAsync(e => e.FirstName == employee.FirstName && e.LastName == employee.LastName);
            if (e != null)
                return await Task.FromResult((int) HttpStatusCode.Conflict);
            await UnitOfWork.EmployeeRepository.AddAsync(employee);
            await UnitOfWork.CompleteAsync();
            return await Task.FromResult((int) HttpStatusCode.Created);
        }

        public async Task<int> RemoveAsync(Guid Id) {
            await UnitOfWork.EmployeeRepository.RemoveAsync(Id);
            return await UnitOfWork.CompleteAsync();
        }

        public async Task<int> UpdateAsync(Employee employee, Guid id) {
            Employee e = await UnitOfWork.EmployeeRepository.FindAsync(id);
            e.FirstName = employee.FirstName;
            e.LastName = employee.LastName;
            e.Email = employee.Email;
            e.Mobile = employee.Mobile;
            e.Address = employee.Address;
            e.AppUserId = employee.AppUserId;
            e.Gender = employee.Gender;
            e.DateOfBirth = employee.DateOfBirth;
            return await UnitOfWork.CompleteAsync();
        }
    }
}
