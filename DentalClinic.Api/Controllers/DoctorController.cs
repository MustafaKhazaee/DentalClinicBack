using DentalClinic.Domain.Common;
using DentalClinic.Domain.Entities;
using DentalClinic.Domain.Services;
using DentalClinic.Domain.Static;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace DentalClinic.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : BaseController {
        public DoctorController (IDomainServices domainServices) : base (domainServices) {}

        [HttpGet("all")]
        [Authorize(Roles = Permissions.Doctor.Get)]
        public async Task<IEnumerable<Doctor>> Get() => await domainServices.DoctorService.GetAllAsync();

        [HttpGet]
        [Authorize(Roles = Permissions.Doctor.Get)]
        public async Task<PagedResult<Doctor>> GetFilteredPagedAsync(string firstname, string lastname, int pageIndex, int pageSize) =>
            await domainServices.DoctorService.GetFilteredPagedAsync(firstname, lastname, pageIndex, pageSize);

        [HttpPost]
        [Authorize(Roles = Permissions.Doctor.Post)]
        public async Task<int> Add(Doctor doctor) => await domainServices.DoctorService.AddAsync(doctor);

        [HttpPut]
        [Authorize(Roles = Permissions.Doctor.Put)]
        public async Task<int> Put(Doctor doctor, Guid id) => await domainServices.DoctorService.UpdateAsync(doctor, id);

        [HttpDelete]
        [Authorize(Roles = Permissions.Doctor.Delete)]
        public async Task<int> Delete(Guid id) => await domainServices.DoctorService.RemoveAsync(id);
    }
}
