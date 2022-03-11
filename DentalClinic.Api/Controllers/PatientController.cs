using DentalClinic.Domain.Common;
using DentalClinic.Domain.Entities;
using DentalClinic.Domain.Services;
using DentalClinic.Domain.Static;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace DentalClinic.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : BaseController {
        public PatientController (IDomainServices domainServices) : base (domainServices) { }

        [HttpGet("all")]
        [Authorize(Roles = Permissions.Patient.Get)]
        public async Task<IEnumerable<Patient>> Get() => await domainServices.PatientService.GetAllAsync();

        [HttpGet]
        [Authorize(Roles = Permissions.Patient.Get)]
        public async Task<PagedResult<Patient>> GetFilteredPagedAsync(string firstname, string lastname, string mobile, int pageIndex, int pageSize) =>
            await domainServices.PatientService.GetFilteredPagedAsync(firstname, lastname, mobile, pageIndex, pageSize);

        [HttpPost]
        [Authorize(Roles = Permissions.Patient.Post)]
        public async Task<int> Add(Patient patient) => await domainServices.PatientService.AddAsync(patient);

        [HttpPut]
        [Authorize(Roles = Permissions.Patient.Put)]
        public async Task<int> Put(Patient patient, Guid id) => await domainServices.PatientService.UpdateAsync(patient, id);

        [HttpDelete]
        [Authorize(Roles = Permissions.Patient.Delete)]
        public async Task<int> Delete(Guid id) => await domainServices.PatientService.RemoveAsync(id);
    }
}
