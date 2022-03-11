using DentalClinic.Domain.Common;
using DentalClinic.Domain.Entities;
using DentalClinic.Domain.Repository;
using DentalClinic.Domain.Services;
using Microsoft.AspNetCore.Http;

namespace DentalClinic.Infrastructure.Services {
    public class RoleService : IRoleService {
        private IUnitOfWork UnitOfWork { get; set; }
        public RoleService(IUnitOfWork unitOfWork) => UnitOfWork = unitOfWork;

        public async Task<PagedResult<Role>> GetFilteredPagedAsync(string rolename, int pageIndex, int pageSize) =>
            await UnitOfWork.RoleRepository.GetFilteredPagedAsync(rolename, pageIndex, pageSize);

        public async Task<int> AddAsync(string rolename, IEnumerable<string> permissions) {
            if (await UnitOfWork.RoleRepository.FindAsync(r => r.RoleName == rolename) != null) {
                return StatusCodes.Status409Conflict;
            }
            Guid roleGuid = Guid.NewGuid();
            Role newRole = new Role { Id = roleGuid, RoleName = rolename };
            List<RolePermission> rolePermissions = new List<RolePermission>();
            List<Permission> perm = new List<Permission>();
            permissions.ToList().ForEach(p => {
                Guid perGuid = Guid.NewGuid();
                perm.Add(new Permission { Id = perGuid, Code = p });
                rolePermissions.Add(new RolePermission { RoleId = roleGuid, PermissionId = perGuid });
            });
            await UnitOfWork.RoleRepository.AddAsync(newRole);
            await UnitOfWork.PermissionRepository.AddRangeAsync(perm);
            await UnitOfWork.RolePermissionRepository.AddRangeAsync(rolePermissions);
            await UnitOfWork.CompleteAsync();
            return StatusCodes.Status201Created;
        }

        public async Task<int> RemoveAsync(Guid Id) {
            await UnitOfWork.RoleRepository.RemoveAsync(Id);
            List<RolePermission> rolePermissions = (List<RolePermission>) 
                await UnitOfWork.RolePermissionRepository.FindAllAsync(rp => rp.RoleId == Id);
            foreach (var rp in rolePermissions) {
                await UnitOfWork.PermissionRepository.RemoveAsync(rp.PermissionId);
            }
            return await UnitOfWork.CompleteAsync();
        }

        public async Task<int> UpdateAsync(Guid roleId, string name, IEnumerable<string> list) {
            Role r = await UnitOfWork.RoleRepository.FindAsync(roleId);
            r.RoleName = name;
            IEnumerable<RolePermission> rolePermissions =
                await UnitOfWork.RolePermissionRepository.FindAllAsync(rp => rp.RoleId == r.Id);
            foreach (var rp in rolePermissions) {
                await UnitOfWork.PermissionRepository.RemoveAsync(rp.PermissionId);
            }
            UnitOfWork.RolePermissionRepository.RemoveRange(rolePermissions);
            List<RolePermission> newRP = new List<RolePermission>();
            List<Permission> perm = new List<Permission>();
            foreach (var p in list) {
                Guid perGuid = Guid.NewGuid();
                perm.Add(new Permission { Id = perGuid, Code = p });
                newRP.Add(new RolePermission { RoleId = r.Id, PermissionId = perGuid });
            }
            await UnitOfWork.PermissionRepository.AddRangeAsync(perm);
            await UnitOfWork.RolePermissionRepository.AddRangeAsync(newRP);
            return await UnitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<Role>> GetAllAsync() => 
            await UnitOfWork.RoleRepository.FindAllAsync(r => !r.RoleName.Equals("System Developer"));

        public async Task<Role> GetByIdAsync(Guid id) => await UnitOfWork.RoleRepository.FindAsync(r => r.Id == id);
    }
}
