using Microsoft.EntityFrameworkCore;
using WebApi_Local.Models;


namespace WebApi_Local.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Sign_Users> Sign_Users { get; set; }

    }

}

