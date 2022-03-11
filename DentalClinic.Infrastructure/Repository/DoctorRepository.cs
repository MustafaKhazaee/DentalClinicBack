using DentalClinic.Domain.Common;
using DentalClinic.Domain.Entities;
using DentalClinic.Domain.Repository;

namespace DentalClinic.Infrastructure.Repository {
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository {
        public DoctorRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) {
            
        }
        public async Task<PagedResult<Doctor>> GetFilteredPagedAsync(string firstname, string lastname, int pageIndex, int pageSize) =>
            await context.Doctors.Where<Doctor>(d => (d.FirstName.Contains(firstname) || firstname.Equals("null")) &&
                (d.LastName.Contains(lastname) || lastname.Equals("null"))).GetPaged<Doctor>(pageIndex, pageSize);
        public async Task<List<Guid?>> Guids() =>
            await Task.FromResult(context.Doctors.Select(d => d.AppUserId).ToList());
    }
}
