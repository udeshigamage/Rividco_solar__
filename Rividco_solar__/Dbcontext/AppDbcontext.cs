using Microsoft.EntityFrameworkCore;
using Rividco_solar__.Models;
using System;

namespace Rividco_solar__.Dbcontext
{
    public class AppDbcontext : DbContext 
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options)
           : base(options)
        {
        }

        public DbSet<Vendor> Vendor { get; set; }

        public DbSet<Vendoritem> Vendoritem { get; set; }

        public DbSet<Systemuser> Systemusers { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Company> Company { get; set; }

        public DbSet<Projectitem> Projectitem { get; set; }

        public DbSet<Projecttest> Projecttest { get; set; }

        public DbSet<Projectservices> Projectservices { get; set; }

        public DbSet<Taskstatus> Taskstatus { get; set; }

        public DbSet<TaskCIA> TaskCIA { get; set; }

        public DbSet<Taskresources> Taskresources { get; set; }

        public DbSet<ProjectResources> Projectresources { get; set; }

        public DbSet<ProjectCommissionreport> Projectcommissionreport { get; set; }

        public DbSet<Customer> customers { get; set; }

        public DbSet<Participant> Participant { get; set; }

        


       
    }
}
