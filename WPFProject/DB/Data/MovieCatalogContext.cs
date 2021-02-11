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
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<MovieRating> MovieRatings { get; set; }
        public DbSet<MoviePlatform> MoviePlatforms { get; set; }
        public DbSet<Wishlist> Wishlist { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MovieCatalogDB;Trusted_Connection=True;");
        }

    }
}
