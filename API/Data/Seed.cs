using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedUsers(DataContext context)
        {
            // AnyAsync - Asynchronously determines whether a sequence contains any elements
            if(await context.Users.AnyAsync()) return;

            // Asynchronously reads data from json
            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            // deserializes data from json
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);

            foreach(var user in users)
            {
                using var hmac = new HMACSHA512();

                user.UserName = user.UserName.ToLower(); 
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd"));
                user.PasswordSalt = hmac.Key;

                // adds desserialized user with hashed password to list
                context.Users.Add(user);
            }

            await context.SaveChangesAsync();
        }
    }
}