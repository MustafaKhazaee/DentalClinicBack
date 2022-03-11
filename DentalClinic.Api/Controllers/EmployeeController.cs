using DentalClinic.Domain.Common;
using DentalClinic.Domain.Entities;
using DentalClinic.Domain.Services;
using DentalClinic.Domain.Static;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace DentalClinic.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController {
        public EmployeeController(IDomainServices domainServices) : base(domainServices) { }

        [HttpGet]
        [Authorize(Roles = Permissions.Employee.Get)]
        public async Task<PagedResult<Employee>> GetFilteredPagedAsync(string firstname, string lastname, int pageIndex, int pageSize) =>
            await domainServices.EmployeeService.GetFilteredPagedAsync(firstname, lastname, pageIndex, pageSize);

        [HttpPost]
        [Authorize(Roles = Permissions.Employee.Post)]
        public async Task<int> Add(Employee employee) => await domainServices.EmployeeService.AddAsync(employee);

        [HttpPut]
        [Authorize(Roles = Permissions.Employee.Put)]
        public async Task<int> Put(Employee employee, Guid id) => await domainServices.EmployeeService.UpdateAsync(employee, id);

        [HttpDelete]
        [Authorize(Roles = Permissions.Employee.Delete)]
        public async Task<int> Delete(Guid id) => await domainServices.EmployeeService.RemoveAsync(id);
    }
}
