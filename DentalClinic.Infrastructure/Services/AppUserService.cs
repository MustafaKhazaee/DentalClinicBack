using DentalClinic.Application.Extensions;
using DentalClinic.Domain.Common;
using DentalClinic.Domain.Entities;
using DentalClinic.Domain.Enums;
using DentalClinic.Domain.Repository;
using DentalClinic.Domain.Services;
using Microsoft.AspNetCore.Http;
namespace DentalClinic.Infrastructure.Services {
    public class AppUserService : IAppUserService {
        private IUnitOfWork UnitOfWork { get; set; }
        public AppUserService(IUnitOfWork unitOfWork) => UnitOfWork = unitOfWork;
        public async Task<IEnumerable<AppUserRole>> GetRolesAndPermissionsByUserId(Guid Id) {
            return await UnitOfWork.AppUserRoleRepository.GetRolesAndPermissionsByUserId(Id);
        }
        public async Task<int> AddAsync(AppUser appUser, IEnumerable<Guid> roles) {
            if (await UnitOfWork.AppUserRepository.FindAsync(u => u.UserName == appUser.UserName) != null) {
                return StatusCodes.Status409Conflict;
            }
            appUser.Salt = "".GetSalt();
            appUser.Password = $"{appUser.Password}{appUser.Salt}".GetHash();
            appUser.Id = Guid.NewGuid();
            await UnitOfWork.AppUserRepository.AddAsync(appUser);
            roles.ToList().ForEach(r => UnitOfWork.AppUserRoleRepository.AddAsync(new AppUserRole { AppUserId = appUser.Id, RoleId = r }));
            await UnitOfWork.CompleteAsync();
            return StatusCodes.Status201Created;
        }
        public async Task<AppUser> FindByUsernameAsync(string username) {
            AppUser appUser = await UnitOfWork.AppUserRepository.FindAsync(u => u.UserName == username);
            if (appUser != null)
                UnitOfWork.AppUserRepository.MarkAsDetached(appUser);
            return appUser;
        }
        public async Task<PagedResult<AppUser>> GetFilteredPagedAsync(string username,  int pageIndex, int pageSize) =>
            await UnitOfWork.AppUserRepository.GetFilteredPagedAsync(username, pageIndex, pageSize);
        public async Task<int> RemoveAsync(Guid Id) {
            await UnitOfWork.AppUserRepository.RemoveAsync(Id);
            return await UnitOfWork.CompleteAsync();
        }
        public async Task<int> UpdateAsync(AppUser appUser, IEnumerable<Guid> roles) {
            AppUser appUserDatabase = await UnitOfWork.AppUserRepository.FindAsync(appUser.Id);
            appUserDatabase.UserName = appUser.UserName;
            appUserDatabase.UserType = appUser.UserType;
            appUserDatabase.isLocked = appUser.isLocked;
            if (!appUserDatabase.Password.Equals(appUser.Password))
                appUserDatabase.Password = $"{appUser.Password}{appUserDatabase.Salt}".GetHash();
            IEnumerable<AppUserRole> appUserRoles =
                await UnitOfWork.AppUserRoleRepository.FindAllAsync(aur => aur.AppUserId == appUser.Id);
            UnitOfWork.AppUserRoleRepository.RemoveRange(appUserRoles);
            roles.ToList().ForEach(r => UnitOfWork.AppUserRoleRepository.AddAsync(
                new AppUserRole { AppUserId = appUser.Id, RoleId = r})
            );
            return await UnitOfWork.CompleteAsync();
        }
        public async Task<IEnumerable<AppUser>> GetAllDoctors() {
            List<Guid?> reserved = new List<Guid?>();
            reserved.AddRange(await UnitOfWork.DoctorRepository.Guids());
            reserved.AddRange(await UnitOfWork.EmployeeRepository.Guids());
            return await UnitOfWork.AppUserRepository.FindAllAsync(u => !reserved.Contains(u.Id) && 
            u.UserType == UserType.Doctor);
        }
        public async Task<IEnumerable<AppUser>> GetAllEmployees() {
            List<Guid?> reserved = new List<Guid?>();
            reserved.AddRange(await UnitOfWork.DoctorRepository.Guids());
            reserved.AddRange(await UnitOfWork.EmployeeRepository.Guids());
            return await UnitOfWork.AppUserRepository.FindAllAsync(u => !reserved.Contains(u.Id) &&
            u.UserType == UserType.Employee);
        }

        public async Task<IEnumerable<Guid>> GetGuidsByRoleName(string rolename) =>
            await UnitOfWork.AppUserRepository.GetGuidsByRoleName(rolename);
    }
}
