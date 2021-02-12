using Microsoft.EntityFrameworkCore;
using WPFProject.DB.Models;

namespace WPFProject.DB.Data
{
    public class MovieCatalogContext : DbContext
    {

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Platform> Platforms { get; set; }
       // public DbSet<MovieGenre> MovieGenres { get; set; }
       // public DbSet<MovieRating> MovieRatings { get; set; }
       // public DbSet<MoviePlatform> MoviePlatforms { get; set; }
        public DbSet<Wishlist> Wishlist { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MovieCatalogDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Platform>().HasData(new Platform { Id = 1, PlatformName = "Netflix" });
            modelBuilder.Entity<Platform>().HasData(new Platform { Id = 2, PlatformName = "HBO" });
            modelBuilder.Entity<Platform>().HasData(new Platform { Id = 3, PlatformName = "Disney+" });
            modelBuilder.Entity<Platform>().HasData(new Platform { Id = 4, PlatformName = "Canal+" });
            modelBuilder.Entity<Platform>().HasData(new Platform { Id = 5, PlatformName = "CDA" });
            modelBuilder.Entity<Platform>().HasData(new Platform { Id = 6, PlatformName = "Player" });
            modelBuilder.Entity<Platform>().HasData(new Platform { Id = 7, PlatformName = "Inne" });

            modelBuilder.Entity<Rating>().HasData(new Rating { Id = 1, RatingValue = 1, RatingName = "Nieporozumienie"  });
            modelBuilder.Entity<Rating>().HasData(new Rating { Id = 2, RatingValue = 2, RatingName = "Ujdzie" });
            modelBuilder.Entity<Rating>().HasData(new Rating { Id = 3, RatingValue = 3, RatingName = "Średni" });
            modelBuilder.Entity<Rating>().HasData(new Rating { Id = 4, RatingValue = 4, RatingName = "Dobry" });
            modelBuilder.Entity<Rating>().HasData(new Rating { Id = 5, RatingValue = 5, RatingName = "Świetny" });



            modelBuilder.Entity<Genre>().HasData(new Genre { Id = 1, GenreName = "Komedia" });
            modelBuilder.Entity<Genre>().HasData(new Genre { Id = 2, GenreName = "Akcja" });
            modelBuilder.Entity<Genre>().HasData(new Genre { Id = 3, GenreName = "Science fiction" });
            modelBuilder.Entity<Genre>().HasData(new Genre { Id = 4, GenreName = "Horror" });
            modelBuilder.Entity<Genre>().HasData(new Genre { Id = 5, GenreName = "Romans" });
            modelBuilder.Entity<Genre>().HasData(new Genre { Id = 6, GenreName = "Dramat" });
            modelBuilder.Entity<Genre>().HasData(new Genre { Id = 7, GenreName = "Thriller" });
            modelBuilder.Entity<Genre>().HasData(new Genre { Id = 8, GenreName = "Kryminał" });
            modelBuilder.Entity<Genre>().HasData(new Genre { Id = 9, GenreName = "Inny" });
         
        }
    }
}

