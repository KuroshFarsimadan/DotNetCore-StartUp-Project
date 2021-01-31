using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Project_Skeleton.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project_Skeleton.Data
{
    public class Seeder
    {
        /*
        public static async Task SeederOther(DataContext context, IWebHostEnvironment hosting, 
            UserManager<UserDTO> userManager)
        {
            context.Database.EnsureCreated();
        } */

        public static async Task ProductsOrdersSeeder(DataContext context, IWebHostEnvironment hosting)
        {
            context.Database.EnsureCreated();
            if(!context.Products.Any())
            {
                var fileNamePath = Path.Combine(hosting.ContentRootPath, "SeedData/Product.json");
                var json = File.ReadAllText(fileNamePath);
                var products = JsonConvert.DeserializeObject<IEnumerable<ProductDTO>>(json);
                context.Products.AddRange(products);
                var order = context.Orders.Where(o => o.Id == 1).FirstOrDefault();
                if(order != null )
                {
                    order.OrderItems = new List<OrderItemDTO>()
                    {
                        new OrderItemDTO()
                        {
                            Product = products.First(),
                            Quantity = 10,
                            ProductBatchPrice = products.First().Price
                        }
                    };
                }
                await context.SaveChangesAsync();
            }
        }

        public static async Task UsersSeeder(DataContext context)
        {
            if (await context.Users.AnyAsync()) return;

            var users = await System.IO.File.ReadAllTextAsync("Data/SeedData/User.json");
            var usersSerialized = System.Text.Json.JsonSerializer.Deserialize<List<UserDTO>>(users);
            foreach (var user in usersSerialized)
            {
                var hmacsha = new HMACSHA512();
                user.PasswordHash = hmacsha.ComputeHash(Encoding.UTF8.GetBytes("secret"));
                user.PasswordSalt = hmacsha.Key;
                context.Users.Add(user);
            }

            await context.SaveChangesAsync();
        }
    }
}
