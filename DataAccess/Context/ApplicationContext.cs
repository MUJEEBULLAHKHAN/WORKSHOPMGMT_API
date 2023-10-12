using DataAccess.DBEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                //"data source=localhost;Initial Catalog=WorkshopMgmt;User ID=sa; Password=saJed1004;MultipleActiveResultSets=true;TrustServerCertificate=True");
                "data source=localhost;Initial Catalog=WorkshopMgmt;User ID=sa; Password=A2zsa!@#4;MultipleActiveResultSets=true;TrustServerCertificate=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>()
    .HasOne(e => e.VehicleModel)
    .WithMany()
    .IsRequired(false)

            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Job>()
    .HasOne(e => e.Vehicle)
    .WithMany()
    .IsRequired(false)

            .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Job>()
    .HasOne(e => e.Workshop)
    .WithMany()
    .IsRequired(false)

            .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Job>()
   .HasOne(e => e.User)
   .WithMany()
   .IsRequired(false)

           .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>()
    .HasOne(e => e.Workshop)
    .WithMany()
    .IsRequired(false)

            .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ActivityLog>()
    .HasOne(e => e.Stage)
    .WithMany()
    .IsRequired(false)

            .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ActivityLog>()
   .HasOne(e => e.User)
   .WithMany()
   .IsRequired(false)

           .OnDelete(DeleteBehavior.Restrict);
        }
        public DbSet<Workshop> Workshop { get; set; }
        public DbSet<CustomerType> CustomerType { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<VehicleMake> VehicleMake { get; set; }
        public DbSet<VehicleModel> VehicleModel { get; set; }
        public DbSet<Stage> Stage { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<VehiclePics> VehiclePics { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<ActivityLog> ActivityLog { get; set; }
        public DbSet<JobStatus> JobStatus { get; set; }
        public DbSet<ErrorLog> ErrorLog { get; set; }

        public DbSet<TamamClaimDetails> TamamClaim { get; set; }
        public DbSet<TamamUserDetails> TamamUser { get; set; }
        public DbSet<TamamAddressDetails> TamamAddress { get; set; }
        public DbSet<TamamVehicleDetails> TamamVehicle { get; set; }
    }
}
