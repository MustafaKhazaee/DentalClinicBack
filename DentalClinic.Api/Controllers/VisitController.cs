using DentalClinic.Api.Hubs;
using DentalClinic.Domain.Common;
using DentalClinic.Domain.Entities;
using DentalClinic.Domain.Models;
using DentalClinic.Domain.Services;
using DentalClinic.Domain.Static;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace DentalClinic.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class VisitController : BaseController {
        public VisitController (IDomainServices _domainServices) : base (_domainServices) {
            
        }

        [HttpGet]
        [Authorize(Roles = Permissions.Visit.Get)]
        public async Task<PagedResult<Visit>> GetFilteredPagedAsync(string patientName, string patientMobile, string doctorName, int pageIndex, int pageSize) =>
            await domainServices.VisitService.GetFilteredPagedAsync(patientName, patientMobile, doctorName, pageIndex, pageSize);

        [HttpPost]
        [Authorize(Roles = Permissions.Visit.Post)]
        public async Task<int> Add(VisitModel visit) => await domainServices.VisitService.AddAsync(visit);

        [HttpPut]
        [Authorize(Roles = Permissions.Visit.Put)]
        public async Task<int> Put(VisitModel visit, Guid id) => await domainServices.VisitService.UpdateAsync(visit, id);

        [HttpDelete]
        [Authorize(Roles = Permissions.Visit.Delete)]
        public async Task<int> Delete(Guid id) => await domainServices.VisitService.RemoveAsync(id);
    }
}
