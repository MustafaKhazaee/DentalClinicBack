namespace DentalClinic.Domain.Repository {
    public interface IUnitOfWork {
        public IDoctorRepository? DoctorRepository { get; set; }
        public IExpenseRepository? ExpenseRepository { get; set; }
        public IPatientRepository? PatientRepository { get; set; }
        public IVisitRepository? VisitRepository { get; set; }
        public IEmployeeRepository? EmployeeRepository { get; set; }
        public IRoleRepository? RoleRepository { get; set; }
        public IAppUserRepository? AppUserRepository { get; set; }
        public IPermissionRepository? PermissionRepository { get; set; }
        public IAppUserRoleRepository? AppUserRoleRepository { get; set; }
        public IRolePermissionRepository? RolePermissionRepository { get; set; }
        public Task<int> CompleteAsync();
    }
}
