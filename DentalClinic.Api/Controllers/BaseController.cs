using Microsoft.AspNetCore.Mvc;
using DentalClinic.Domain.Services;
using DentalClinic.Application.Services;
using Microsoft.AspNetCore.Authorization;
namespace DentalClinic.Api.Controllers {
    [Authorize]
    public class BaseController : ControllerBase {
        internal readonly IDomainServices domainServices;
        internal readonly IApplicationServices? applicationServices;
        public BaseController (IDomainServices _domainServices, IApplicationServices _applicationServices) {
            domainServices = _domainServices;
            applicationServices = _applicationServices;
        }
        public BaseController(IDomainServices _domainServices) => domainServices = _domainServices;
    }
}
