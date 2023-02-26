using EFCoreApp.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreApp.DAL.Data
{
    public class GermaineStoresContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }

        public GermaineStoresContext(DbContextOptions<GermaineStoresContext> options)
           : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(p=>
            {
                p.Property(p => p.OrderPlaced)
                    .HasDefaultValueSql("getdate()");
            });

            modelBuilder.Entity<Customer>(e =>
            {
                e.Property(p => p.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);
                e.Property(p => p.LastName)
                   .IsRequired(false)
                   .HasMaxLength(20);
                 e.HasIndex(p => new { p.Email,p.Phone }, $"IX_Unique_{nameof(Customer.Email)}{nameof(Customer.Phone)}")
                    .IsUnique();

            });

            /*modelBuilder.Entity<Customer>()
               .HasOne(a => a.Orders)
               .WithMany(b => b.Customer)
               .HasForeignKey(a => a.OrderId);*/

            base.OnModelCreating(modelBuilder);

        }
    }

}
