using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFProjekt.DB.Models
{
    public class Movie
    {

        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        public ICollection<MovieGenre> MovieGenres { get; set; }
        public ICollection<MoviePlatform> MoviePlatforms { get; set; }
        public ICollection<MovieRating> MvieRatings { get; set; }
    }
}
