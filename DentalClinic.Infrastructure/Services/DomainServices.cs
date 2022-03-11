using DentalClinic.Domain.Repository;
using DentalClinic.Domain.Services;
namespace DentalClinic.Infrastructure.Services {
    public class DomainServices : IDomainServices {
        public DomainServices(IUnitOfWork _unitOfWork) {
            DoctorService = new DoctorService(_unitOfWork);
            ExpenseService = new ExpenseService(_unitOfWork);
            PatientService = new PatientService(_unitOfWork);
            VisitService = new VisitService(_unitOfWork);
            EmployeeService = new EmployeeService(_unitOfWork);
            RoleService = new RoleService(_unitOfWork);
            AppUserService = new AppUserService(_unitOfWork);
            PermissionService = new PermissionService(_unitOfWork);
            ReportService = new ReportService(_unitOfWork);
        }
        public IDoctorService DoctorService { get; set; }
        public IExpenseService ExpenseService { get; set; }
        public IPatientService PatientService { get; set; }
        public IVisitService VisitService { get; set; }
        public IEmployeeService EmployeeService { get; set; }
        public IRoleService RoleService { get; set; }
        public IAppUserService AppUserService { get; set; }
        public IPermissionService PermissionService { get; set; }
        public IReportService ReportService { get; set; }
    }
}
