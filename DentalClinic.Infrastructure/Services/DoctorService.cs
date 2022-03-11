using DentalClinic.Domain.Common;
using DentalClinic.Domain.Entities;
using DentalClinic.Domain.Repository;
using DentalClinic.Domain.Services;
using System.Net;

namespace DentalClinic.Infrastructure.Services {
    public class DoctorService : IDoctorService {
        private IUnitOfWork UnitOfWork { get; set; }
        public DoctorService(IUnitOfWork unitOfWork) => UnitOfWork = unitOfWork;
        public async Task<int> AddAsync(Doctor doctor) {
            Doctor d = await UnitOfWork.DoctorRepository.FindAsync(d => d.FirstName == doctor.FirstName && d.LastName == doctor.LastName);
            if (d != null)
                return await Task.FromResult((int) HttpStatusCode.Conflict);
            await UnitOfWork.DoctorRepository.AddAsync(doctor);
            await UnitOfWork.CompleteAsync();
            return await Task.FromResult((int)HttpStatusCode.Created);
        }
        public async Task<IEnumerable<Doctor>> GetAllAsync() => await UnitOfWork.DoctorRepository.GetAllAsync();
        public async Task<Doctor> FindByUserId(Guid Id) => await UnitOfWork.DoctorRepository.FindAsync(d => d.AppUserId == Id);
        public async Task<PagedResult<Doctor>> GetFilteredPagedAsync(string firstname, string lastname, int pageIndex, int pageSize) =>
            await UnitOfWork.DoctorRepository.GetFilteredPagedAsync(firstname, lastname, pageIndex, pageSize);
        public async Task<int> RemoveAsync(Guid Id) {
            await UnitOfWork.DoctorRepository.RemoveAsync(Id);
            return await UnitOfWork.CompleteAsync();
        }
        public async Task<int> UpdateAsync(Doctor doctor, Guid id) {
            Doctor d = await UnitOfWork.DoctorRepository.FindAsync(id);
            d.FirstName = doctor.FirstName;
            d.LastName = doctor.LastName;
            d.Mobile = doctor.Mobile;
            d.Email = doctor.Email;
            d.Gender = doctor.Gender;
            d.AppUserId = doctor.AppUserId;
            d.DateOfBirth = doctor.DateOfBirth;
            d.Address = doctor.Address;
            return await UnitOfWork.CompleteAsync();
        }

    }
}
