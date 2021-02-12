using System;
using System.Collections.Generic;
using System.Text;

namespace WPFProject.DB.Models
{
    public class Movie
    {

        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Platform> Platforms { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}
