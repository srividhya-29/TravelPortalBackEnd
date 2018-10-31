using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class KDTravelPortalDbContext:DbContext
    {
        public KDTravelPortalDbContext():base("travelconnString")
        {

        }

        //public static KDTravelPortalDbContext Create()
        //{
        //    return new KDTravelPortalDbContext();
        //}


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<FinanceDetail> FinanceDetails { get; set; }
        public DbSet<InvitationLetterFormat> InvitationLetterFormats { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<TravelRequest> TravelRequests { get; set; }
        public DbSet<TravelType> TravelTypes { get; set; }
        public DbSet<VFSPortalEntry> VFSPortalEntries { get; set; }
        public DbSet<WorkFlow> WorkFlows { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee_Project> EmployeesProjects { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //builder is the service that helps you with all the deletion and updation
        //    //this is called cascade delete and it isnt present by default and it is a one time activity

        //    modelBuilder.Entity<Project>()
        //      .HasRequired(p => p.Employee)
        //      .WithMany()
        //       .WillCascadeOnDelete(true);



        //    base.OnModelCreating(modelBuilder);
        //}
    }


}
