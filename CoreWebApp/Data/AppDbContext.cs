using CoreWebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CoreWebApp.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();

            foreach (var foreignkey in modelBuilder.Model.GetEntityTypes()
                .SelectMany(x => x.GetForeignKeys()))
            {
                foreignkey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
