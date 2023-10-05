using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NBA_Tracker.Models;

namespace NBA_Tracker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //will have to put getters and setters in here (reference veggitales) 
        public DbSet<Game> Games { get; set; }
        public DbSet<GamePlayerStats> GamePlayerStats { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }

        /*
         * Was getting a cascading delete error because of the foreign keys in my Game model, there were two referencing the same table. 
         * Because we can have a team in more than one game it sets up my database in a way that if you were to delete an entry by it's HomeTeamId it 
         * would delete all with that Id which is something that we don't want.
         * 
         * Below is how I'm preventing my database from being effected by cascading deletes 
         * 
         * tried to familiarize myself with this issue here https://learn.microsoft.com/en-us/ef/core/saving/cascade-delete
         * 
         */
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //disabling cascade delete for HomeTeamId 
            modelBuilder.Entity<Game>()
                .HasOne(g => g.HomeTeam)
                .WithMany()
                .HasForeignKey(g => g.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict); //here is were we are disabling cascading deteles 

            modelBuilder.Entity<Game>()
                .HasOne(g => g.AwayTeam)
                .WithMany()
                .HasForeignKey(g => g.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict); //disabling cascade delete

        }
       
    }
}