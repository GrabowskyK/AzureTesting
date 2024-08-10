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
           

            modelBuilder.Entity<Event>().UseTpcMappingStrategy();


            modelBuilder.Entity<Event>()
                .HasOne(e => e.Player)
                .WithMany()
                .HasForeignKey(e => e.PlayerId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Event>()
                .HasOne(e => e.Game)
                .WithMany()
                .HasForeignKey(e => e.GameId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.Team)
                .WithMany()
                .HasForeignKey(e => e.TeamId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configure relationships for Game
            modelBuilder.Entity<Game>()
                .HasOne(g => g.TeamA)
                .WithMany() // No collection in Team
                .HasForeignKey(g => g.TeamAID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.TeamB)
                .WithMany() // No collection in Team
                .HasForeignKey(g => g.TeamBID)
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
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; } 
        public DbSet<Event> GameEvents { get; set; }
        public DbSet<Goal> GameGoals { get; set; }
        public DbSet<Penalty> GamePenalties { get; set; }   

    }
}
