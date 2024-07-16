using AzureTesting.Model;
using Microsoft.EntityFrameworkCore;

namespace AzureTesting.Database
{
    public class DatabaseContext : DbContext

    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
       // public DbSet<Test> tests { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<League> Leagues { get; set; }

    }
}
