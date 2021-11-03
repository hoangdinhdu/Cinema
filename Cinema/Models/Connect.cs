using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Cinema.Models
{
    public partial class Connect : DbContext
    {
        public Connect()
            : base("name=Connect")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.UserName)
                .IsFixedLength();

            modelBuilder.Entity<Account>()
                .Property(e => e.PassWord)
                .IsFixedLength();
        }
    }
}
