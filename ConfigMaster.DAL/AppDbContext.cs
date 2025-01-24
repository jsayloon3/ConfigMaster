using Microsoft.EntityFrameworkCore;
using ConfigMaster.Common.Models;

namespace ConfigMaster.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<PathInfo> PathInfo { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    RoleId = 1,
                    RoleName = "Project",
                    RoleDescription = "Project Role"
                },
                new Role
                {
                    RoleId = 2,
                    RoleName = "Developer",
                    RoleDescription = "Developer Role"
                },
                new Role
                {
                    RoleId = 3,
                    RoleName = "QA",
                    RoleDescription = "QA Role"
                },
                new Role
                {
                    RoleId = 4,
                    RoleName = "Tech Support",
                    RoleDescription = "Tech Support Role"
                }
            );
        }
    }
}
