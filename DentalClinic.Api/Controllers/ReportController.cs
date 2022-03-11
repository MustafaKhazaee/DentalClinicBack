using DentalClinic.Domain.Services;
using DentalClinic.Domain.Static;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace DentalClinic.Api.Controllers {
    [Authorize(Roles = Permissions.Report.Get)]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : BaseController {
        public ReportController(IDomainServices _domainServices) : base(_domainServices) { }

        [HttpGet("count")]
        [AllowAnonymous]
        public async Task<Dictionary<string, int>> GetCounts() => await domainServices.ReportService.GetCountsAsync();
        [HttpGet("getVisitCountRange")]
        public async Task<List<Object>> GetVisitsCountRange([FromQuery] DateTime startDate,[FromQuery]  DateTime endDate) =>
            await domainServices.ReportService.GetVisitsCountRangeAsync(startDate, endDate);

    }
}
