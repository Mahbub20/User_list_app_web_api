using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserApp.Infrastructure.Entities;

namespace UserApp.Infrastructure.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            await context.Database.MigrateAsync();

            if (await context.Users.AnyAsync())
                return;

            var users = new List<User>
            {
                new User { Name = "John Doe", Email = "john@example.com", IsActive = true },
                new User { Name = "Alice Smith", Email = "alice@example.com", IsActive = true },
                new User { Name = "Bob Brown", Email = "bob@example.com", IsActive = false },
                new User { Name = "Charlie White", Email = "charlie@example.com", IsActive = true },
                new User { Name = "David Black", Email = "david@example.com", IsActive = false },
                new User { Name = "John Wick", Email = "john_wick@example.com", IsActive = true },
                new User { Name = "James Brown", Email = "james@example.com", IsActive = false },
                new User { Name = "Henry Cavil", Email = "henry@example.com", IsActive = false },
                new User { Name = "Christian Bale", Email = "christian@example.com", IsActive = true },
                new User { Name = "Will Smith", Email = "will@example.com", IsActive = true },
                new User { Name = "Daniel Craige", Email = "daniel@example.com", IsActive = false },
                new User { Name = "Tom Holland", Email = "tom@example.com", IsActive = true },
            };

            await context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync();
        }
    }
}