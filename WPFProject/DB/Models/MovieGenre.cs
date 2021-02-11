using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WPFProject.DB.Models
{
    public class MovieGenre
    {
        [Key]
        public int Id { get; set; }
        public int GenreId { get; set; }
        public int MovieId { get; set; }

        public Genre Genre { get; set; }

        public Movie Movie { get; set; }
    }
}
