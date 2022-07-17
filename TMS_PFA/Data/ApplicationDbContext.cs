using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TMS_PFA.Models;
using TMS_PFA.ViewModels;

namespace TMS_PFA.Data
{
    public class ApplicationDbContext : IdentityDbContext<Account>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "Manager", NormalizedName = "MANAGER" },
                new IdentityRole { Name = "Driver", NormalizedName = "DRIVER" },
                new IdentityRole { Name = "Client", NormalizedName = "CLIENT" });

        }
    


        public DbSet<Client> Clients { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<DeliveryForm> DeliveryForms { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        //public DbSet<Employee> Employees { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }


    }
}
