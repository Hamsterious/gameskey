using GamesKey.Data;
using GamesKey.Data.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GamesKey
{
    public class GamesKeyDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<GameGenre> GameGenres { get; set; }
        public DbSet<GameTag> GameTags { get; set; }
        public DbSet<Picture> Pictures { get; set; }

        public GamesKeyDbContext(DbContextOptions<GamesKeyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<GameGenre>().HasKey(gg => new { gg.GameId, gg.GenreId });
            builder.Entity<GameTag>().HasKey(gt => new { gt.GameId, gt.TagId });

            builder.Entity<GameGenre>()
                .HasOne(gg => gg.Game)
                .WithMany(g => g.GameGenres)
                .HasForeignKey(gg => gg.GameId);
            builder.Entity<GameGenre>()
                .HasOne(gg => gg.Genre)
                .WithMany(g => g.GameGenres)
                .HasForeignKey(gg => gg.GenreId);

            builder.Entity<GameTag>()
                .HasOne(gt => gt.Game)
                .WithMany(g => g.GameTags)
                .HasForeignKey(gt => gt.GameId);
            builder.Entity<GameTag>()
                .HasOne(gt => gt.Tag)
                .WithMany(g => g.GameTags)
                .HasForeignKey(gt => gt.TagId);

            builder.Entity<Developer>()
                .HasIndex(d => d.Name)
                .IsUnique();
            builder.Entity<Publisher>()
                .HasIndex(p => p.Name)
                .IsUnique();
            builder.Entity<Genre>()
                .HasIndex(g => g.Name)
                .IsUnique();
            builder.Entity<Tag>()
                .HasIndex(t => t.Name)
                .IsUnique();

            base.OnModelCreating(builder);
        }
    }

    public class GamesKeyDbContextFactory : IDesignTimeDbContextFactory<GamesKeyDbContext>
    {
        public GamesKeyDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<GamesKeyDbContext>();
            builder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=GamesKeyDb;Trusted_Connection=True;");
            return new GamesKeyDbContext(builder.Options);
        }
    }
}
