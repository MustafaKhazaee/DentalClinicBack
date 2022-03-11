using DentalClinic.Domain.Repository;
namespace DentalClinic.Infrastructure.Repository {
    public class UnitOfWork : IUnitOfWork{
        private readonly ApplicationDbContext dbContext;
        public UnitOfWork (ApplicationDbContext context) {
            dbContext = context;
            DoctorRepository = new DoctorRepository(dbContext); 
            ExpenseRepository = new ExpenseRepository(dbContext);
            PatientRepository = new PatientRepository(dbContext);
            VisitRepository = new VisitRepository(dbContext);
            EmployeeRepository = new EmployeeRepository(dbContext);
            RoleRepository = new RoleRepository(dbContext);
            AppUserRepository = new AppUserRepository(dbContext);
            PermissionRepository = new PermissionRepository(dbContext);
            AppUserRoleRepository = new AppUserRoleRepository(dbContext);
            RolePermissionRepository = new RolePermissionRepository(dbContext);
        }
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
        public async Task<int> CompleteAsync() => await dbContext.SaveChangesAsync();
    }
}
