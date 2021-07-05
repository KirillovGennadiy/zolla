using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Test.Models;

namespace Test.DataAccess
{
    public class TestDbContext : DbContext
    {
        // Dbcontext
        public TestDbContext()
            : base("TestDbContext") // use TestDbContext connection strng from Web.config
        {
        }

        // Add clients table into context
        public DbSet<Client> Clients { get; set; }

        // Add orders table into context
        public DbSet<Order> Orders { get; set; }

        // in this method we can define a models relationship
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}