using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Skeleton.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Skeleton.Data
{
    // Inject the data _dataContext
    public class DataContext : IdentityDbContext<UserDTO>
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        // public DbSet<UserDTO> Users { get; set; }
        public DbSet<OrderDTO> Orders { get; set; }
        public DbSet<ProductDTO> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrderDTO>().HasData(
              new OrderDTO()
              {
                  Id = 1,
                  OrderDate = DateTime.UtcNow,
 
                  OrderReferenceNumber = "12345"
              }
            ); 
        }



        // Even though orders has a reference to OrderItem, we want to be free to 
        // execute queries against OrderItems
        // public DbSet<OrderItem> OrderItems { get; set; }
    }
}
