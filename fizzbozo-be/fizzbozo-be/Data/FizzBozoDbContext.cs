using Microsoft.EntityFrameworkCore;
using fizzbozo_be.Entities;



namespace fizzbozo_be.Data
{
    public class FizzBozoDbContext : DbContext
    {
        public FizzBozoDbContext(DbContextOptions<FizzBozoDbContext> options) : base(options) { }

        public DbSet<Game> Games { get; set; }
        public DbSet<GameQuestion> GameQuestions {  get; set; }
        public DbSet<GameSession> Sessions { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Rule> Rules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure the array type for PostgreSQL (if using PostgreSQL)
            modelBuilder.Entity<GameSession>()
                .Property(g => g.NumbersUsed)
                .HasColumnType("integer[]");

            // Configure one-to-one relationship between GameSession and Result
            modelBuilder.Entity<GameSession>()
                .HasOne(gs => gs.Result)
                .WithOne(g => g.GameSession)
                .HasForeignKey<Result>(r => r.SessionId);
            // Configure other relationships
            modelBuilder.Entity<Game>()
                .HasMany(g => g.Rules)
                .WithOne(r => r.Game)
                .HasForeignKey(r => r.GameId);

            modelBuilder.Entity<Game>()
                .HasMany(g => g.GameSessions)
                .WithOne(gs => gs.Game)
                .HasForeignKey(gs => gs.GameId);

            modelBuilder.Entity<GameSession>()
                .HasMany(gs => gs.GameQuestions)
                .WithOne(gq => gq.GameSession)
                .HasForeignKey(gq => gq.SessionId);
        }
    }
}
