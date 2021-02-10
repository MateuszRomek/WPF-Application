using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFProjekt.DB.Models;

namespace WPFProjekt.DB.Data
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MovieCatalogDB;Trusted_Connection=True;");
        }

    }
}
