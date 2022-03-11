namespace DentalClinic.Domain.Services {
    public interface IDomainServices {
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
