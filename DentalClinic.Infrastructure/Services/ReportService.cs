using DentalClinic.Domain.Repository;
using DentalClinic.Domain.Services;

namespace DentalClinic.Infrastructure.Services {
    public class ReportService : IReportService {
        private IUnitOfWork UnitOfWork { get; set; }
        public ReportService(IUnitOfWork unitOfWork) => UnitOfWork = unitOfWork;

        public async Task<Dictionary<string, int>> GetCountsAsync() {
            Dictionary<string, int> counts = new Dictionary<string, int>();
            int users = await UnitOfWork.AppUserRepository.CountAsync();
            int roles = await UnitOfWork.RoleRepository.CountAsync();
            int doctors = await UnitOfWork.DoctorRepository.CountAsync();
            int patients = await UnitOfWork.PatientRepository.CountAsync();
            int visits = await UnitOfWork.VisitRepository.CountAsync();
            int employees = await UnitOfWork.EmployeeRepository.CountAsync();
            int expense = await UnitOfWork.ExpenseRepository.CountAsync();
            counts.Add("users", users);
            counts.Add("roles", roles);
            counts.Add("doctors", doctors);
            counts.Add("patients", patients);
            counts.Add("visits", visits);
            counts.Add("employees", employees);
            counts.Add("expenses", expense);
            return counts;
        }

        public async Task<List<Object>> GetVisitsCountRangeAsync(DateTime startDate, DateTime endDate) =>
            await UnitOfWork.VisitRepository.GetVisitsCountRangeAsync(startDate, endDate);
    }
}
