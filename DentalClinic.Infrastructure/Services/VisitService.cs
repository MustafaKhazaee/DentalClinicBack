using DentalClinic.Domain.Common;
using DentalClinic.Domain.Entities;
using DentalClinic.Domain.Models;
using DentalClinic.Domain.Repository;
using DentalClinic.Domain.Services;
using System.Net;

namespace DentalClinic.Infrastructure.Services {
    public class VisitService : IVisitService {
        public VisitService(IUnitOfWork unitOfWork) {
            UnitOfWork = unitOfWork;
        }
        private IUnitOfWork UnitOfWork { get; set; }

        public async Task<int> AddAsync(VisitModel visit) {
            Visit v = new Visit {
                DoctorId = visit.DoctorId,
                PatientId = visit.PatientId,
                Operation = visit.Operation,
                PreOperationFee = visit.PreOperationFee,
                PriorityLevel = visit.PriorityLevel,
                PostOperationFee = visit.PostOperationFee,
                Room = visit.Room,
                DoneDate = visit.DoneDate,
                ScheduleDate = visit.ScheduleDate,
                Description = visit.Description,
                
            };
            await UnitOfWork.VisitRepository.AddAsync(v);
            await UnitOfWork.CompleteAsync();
            return await Task.FromResult((int)HttpStatusCode.Created);
        }
        public async Task<int> UpdateAsync(VisitModel visit, Guid id) {
            Visit v = await UnitOfWork.VisitRepository.FindAsync(id);
            v.Operation = visit.Operation;
            v.ScheduleDate = visit.ScheduleDate;
            v.DoneDate = visit.DoneDate;
            v.PriorityLevel = visit.PriorityLevel;
            v.Room = visit.Room;
            v.PreOperationFee = visit.PreOperationFee;
            v.PostOperationFee = visit.PostOperationFee;
            v.PatientId = visit.PatientId;
            v.DoctorId = visit.DoctorId;
            return await UnitOfWork.CompleteAsync();
        }
        public async Task<PagedResult<Visit>> GetFilteredPagedAsync(string patientName, string patientMobile, string doctorName, int pageIndex, int pageSize) =>
            await UnitOfWork.VisitRepository.GetFilteredPagedAsync(patientName, patientMobile, doctorName, pageIndex, pageSize);

        public async Task<PagedResult<Visit>> GetTodaysVisits() => await UnitOfWork.VisitRepository.GetTodaysVisits();
        public async Task<int> RemoveAsync(Guid Id) {
            await UnitOfWork.VisitRepository.RemoveAsync(Id);
            return await UnitOfWork.CompleteAsync();
        }

    }
}
