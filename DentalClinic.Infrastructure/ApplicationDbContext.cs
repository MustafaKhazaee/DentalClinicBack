using DentalClinic.Domain.Enums;
using DentalClinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using DentalClinic.Application.Extensions;
namespace DentalClinic.Infrastructure {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions options) : base(options) { 
            
        }
        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Visit> Visits { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<AppUserRole> AppUserRoles { get; set; }
        public virtual DbSet<RolePermission> RolePermissions { get; set; }
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            Guid roleGuid = Guid.NewGuid(), appUserGuid = Guid.NewGuid(), permissionGuid = Guid.NewGuid();
            string salt = "".GetSalt();
            List<Permission> permissions = new List<Permission> {
                new Permission { Id = permissionGuid, Code = "r" },
            };
            List<Role> roles = new List<Role> {
                new Role { Id = roleGuid, RoleName = "System Developer", }
            };
            List<AppUser> appUsers = new List<AppUser> {
                new AppUser { Id = appUserGuid, UserName = "mustafa", Salt = salt, CreatedDate = DateTime.Now, CreatedBy = "System",
                    UserType = UserType.Employee, Password = $"Root_Mustafa@123{salt}".GetHash()
                }
            };
            List<AppUserRole> appUserRoles = new List<AppUserRole> {
                new AppUserRole { AppUserId = appUserGuid, RoleId = roleGuid }
            };
            List<RolePermission> rolePermissions = new List<RolePermission> {
                new RolePermission { RoleId = roleGuid, PermissionId = permissionGuid }
            };
            List<Employee> employees = new List<Employee> {
                new Employee { Id = Guid.NewGuid(), FirstName = "Mustafa", LastName = "Khazaee", AppUserId = appUserGuid, Mobile = "+93747286603", Email = "mustafakhazaee@gmail.com" }
            };
            modelBuilder.Entity<Role>().HasData(roles);
            modelBuilder.Entity<AppUser>().HasData(appUsers);
            modelBuilder.Entity<Employee>().HasData(employees);
            modelBuilder.Entity<Permission>().HasData(permissions);
            modelBuilder.Entity<AppUserRole>().HasData(appUserRoles);
            modelBuilder.Entity<RolePermission>().HasData(rolePermissions);
            modelBuilder.Entity<AppUser>().HasIndex(u => u.UserName).IsUnique();
            modelBuilder.Entity<AppUserRole>().HasKey(au => new { au.RoleId, au.AppUserId });
            modelBuilder.Entity<AppUserRole>().HasOne(aur => aur.AppUser)
                                              .WithMany(au => au.AppUserRoles).OnDelete(DeleteBehavior.Cascade)
                                              .HasForeignKey(aur => aur.AppUserId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<AppUserRole>().HasOne(aur => aur.Role)
                                              .WithMany(r => r.AppUserRoles).OnDelete(DeleteBehavior.Cascade)
                                              .HasForeignKey(aur => aur.RoleId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RolePermission>().HasKey(rp => new { rp.RoleId, rp.PermissionId });
            modelBuilder.Entity<RolePermission>().HasOne(rp => rp.Role)
                                                 .WithMany(r => r.RolePermissions).OnDelete(DeleteBehavior.Cascade)
                                                 .HasForeignKey(rp => rp.RoleId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RolePermission>().HasOne(rp => rp.Permission)
                                                 .WithMany(p => p.RolePermissions).OnDelete(DeleteBehavior.Cascade)
                                                 .HasForeignKey(rp => rp.PermissionId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
