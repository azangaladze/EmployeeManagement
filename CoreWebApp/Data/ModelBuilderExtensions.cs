using CoreWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CoreWebApp.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee()
                {
                    Id = 1,
                    Name = "Mary",
                    Department = Department.HR,
                    Email = "mary@test.com",
                    PhotoPath = "mary.jpg"
                },
                new Employee()
                {
                    Id = 2,
                    Name = "John",
                    Department = Department.IT,
                    Email = "john@test.com",
                    PhotoPath = "john.jpg"
                },
                new Employee()
                {
                    Id = 3,
                    Name = "Sam",
                    Department = Department.IT,
                    Email = "sam@test.com"
                },
                new Employee()
                {
                    Id = 4,
                    Name = "David",
                    Department = Department.IT,
                    Email = "david@test.com",
                    PhotoPath = "david.png"
                },
                new Employee()
                {
                    Id = 5,
                    Name = "Jane",
                    Department = Department.Payroll,
                    Email = "jane@test.com"
                });

            List<IdentityRole> roles = new()
            {
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "User", NormalizedName = "USER" }
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);

            // Seed Users

            var passwordHasher = new PasswordHasher<ApplicationUser>();

            List<ApplicationUser> users = new()
            {
                new ApplicationUser
                {
                    UserName = "admin@test.com",
                    NormalizedUserName = "ADMIN@TEST.COM",
                    Email = "admin@test.com",
                    NormalizedEmail = "ADMIN@TEST.COM",
                    City = "Tbilisi"
                },

                new ApplicationUser
                {
                    UserName = "user@test.com",
                    NormalizedUserName = "USER@TEST.COM",
                    Email = "user@test.com",
                    NormalizedEmail = "USER@TEST.COM",
                },
            };


            modelBuilder.Entity<ApplicationUser>().HasData(users);

            // Seed UserRoles

            List<IdentityUserRole<string>> userRoles = new();

            // Add Password For All Users

            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "ASDasd123");
            users[1].PasswordHash = passwordHasher.HashPassword(users[1], "ASDasd123");

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[0].Id,
                RoleId = roles.First(q => q.Name == "Admin").Id
            });

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[1].Id,
                RoleId = roles.First(q => q.Name == "User").Id
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);

        }
    }
}
