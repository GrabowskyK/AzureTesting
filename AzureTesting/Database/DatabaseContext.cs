using AzureTesting.Model;
using Microsoft.EntityFrameworkCore;

namespace AzureTesting.Database
{
    public class DatabaseContext : DbContext

    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>()
                .HasOne(t => t.League)
                .WithMany()
                .HasForeignKey(t => t.LeagueId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.Image)
                .WithMany()
                .HasForeignKey(t => t.ImageId)
                .OnDelete(DeleteBehavior.Restrict);
        }
        // public DbSet<Test> tests { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
