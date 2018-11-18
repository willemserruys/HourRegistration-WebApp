using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WebApiSample.Api._21
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=HourRegistration.db");
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }

  
}