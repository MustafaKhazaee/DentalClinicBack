using DentalClinic.Domain.Common;
using DentalClinic.Domain.Entities;
using DentalClinic.Domain.Repository;

namespace DentalClinic.Infrastructure.Repository {
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository {
        public PatientRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) {
        }
        public async Task<PagedResult<Patient>> GetFilteredPagedAsync(string firstname, string lastname, string mobile, int pageIndex, int pageSize) =>
            await context.Patients.Where<Patient>(p => (p.FirstName.Contains(firstname) || firstname.Equals("null")) &&
                (p.LastName.Contains(lastname) || lastname.Equals("null")) && (p.Mobile.Contains(mobile) || mobile.Equals("null")))
                .GetPaged<Patient>(pageIndex, pageSize);
    }   
}
