﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WPFProject.DB.Models
{
    public class MovieRating
    {

        [Key]
        public int Id { get; set; }
        public int RatingId { get; set; }
        public int MovieId { get; set; }

        public Rating Rating { get; set; }

        public Movie Movie { get; set; }
    }
}