using Microsoft.EntityFrameworkCore;
using User.Data.DBModel;

namespace User.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserInformations> UserInformations { get; set; }

    }
}