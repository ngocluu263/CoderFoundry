﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace SquadClock.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //Constructor
        public ApplicationUser()
        {
            this.Shifts = new HashSet<Shift>();
        }

        //Foreign Keys
        public int? CompanyId { get; set; }
        public int? DepartmentId { get; set; }
        public int? ManagerId { get; set; }
        public int? JobId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Notes { get; set; }
        public bool Active { get; set; }
        public double Timezone { get; set; }

        //NAVIGATION
        public virtual ICollection<Shift> Shifts { get; set; }

        //Methods
        public string DisplayName()
        {
            return FirstName + " " + LastName;
        }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //EF6: build these in MySQL
        public DbSet<SquadClock.Models.Company> Companies { get; set; }
        public DbSet<SquadClock.Models.Employee> Employees { get; set; }
        public DbSet<SquadClock.Models.Department> Departments { get; set; }
        public DbSet<SquadClock.Models.Manager> Managers { get; set; }
        public DbSet<SquadClock.Models.Job> Jobs { get; set; }
        public DbSet<SquadClock.Models.Setting> Settings { get; set; }
        public DbSet<SquadClock.Models.Shift> Shifts { get; set; }
    }
}