using Microsoft.EntityFrameworkCore;
using Project_Skeleton.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Skeleton.Data
{
    // Inject the data context
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        // Even though orders has a reference to OrderItem, we want to be free to 
        // execute queries against OrderItems
        // public DbSet<OrderItem> OrderItems { get; set; }
    }
}
