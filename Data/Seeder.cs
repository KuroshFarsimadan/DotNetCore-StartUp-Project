using Microsoft.EntityFrameworkCore;
using Project_Skeleton.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project_Skeleton.Data
{
    public class Seeder
    {
        public static async Task UsersSeeder(DataContext context)
        {
            if (await context.Users.AnyAsync()) return;

            var users = await System.IO.File.ReadAllTextAsync("Data/JSON/User.json");
            var usersSerialized = JsonSerializer.Deserialize<List<User>>(users);
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
