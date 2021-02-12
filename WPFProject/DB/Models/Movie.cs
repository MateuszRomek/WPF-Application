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
        public Genre Genre { get; set; }
        public Platform Platform { get; set; }
        public Rating Rating{ get; set; }
        public ICollection<User> Users { get; set; }
    }
}
