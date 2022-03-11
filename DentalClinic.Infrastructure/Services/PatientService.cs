using DentalClinic.Domain.Common;
using DentalClinic.Domain.Entities;
using DentalClinic.Domain.Repository;
using DentalClinic.Domain.Services;
using System.Net;
namespace DentalClinic.Infrastructure.Services {
    public class PatientService : IPatientService {
        public PatientService(IUnitOfWork unitOfWork) {
            UnitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Patient>> GetAllAsync() => await UnitOfWork.PatientRepository.GetAllAsync();
        private IUnitOfWork UnitOfWork { get; set; }
        public async Task<int> AddAsync(Patient patient) {
            Patient p = await UnitOfWork.PatientRepository.FindAsync(p => p.FirstName == patient.FirstName && p.Mobile == patient.Mobile && p.LastName == patient.LastName);
            if (p != null)
                return await Task.FromResult((int)HttpStatusCode.Conflict);
            await UnitOfWork.PatientRepository.AddAsync(patient);
            await UnitOfWork.CompleteAsync();
            return await Task.FromResult((int) HttpStatusCode.Created);
        }

        public async Task<PagedResult<Patient>> GetFilteredPagedAsync(string firstname, string lastname, string mobile, int pageIndex, int pageSize) =>
            await UnitOfWork.PatientRepository.GetFilteredPagedAsync(firstname, lastname, mobile, pageIndex, pageSize);

        public async Task<int> RemoveAsync(Guid Id) {
            await UnitOfWork.PatientRepository.RemoveAsync(Id);
            return await UnitOfWork.CompleteAsync();
        }

        public async Task<int> UpdateAsync(Patient patient, Guid id) {
            Patient p = await UnitOfWork.PatientRepository.FindAsync(id);
            p.FirstName = patient.FirstName;
            p.LastName = patient.LastName;
            p.Age = patient.Age;
            p.Mobile = patient.Mobile;
            p.Age = patient.Age;
            p.Gender = patient.Gender;
            return await UnitOfWork.CompleteAsync();
        }
    }
}
