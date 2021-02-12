﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WPFProject.DB.Models
{
    public class MoviePlatform
    {
        [Key]
        public int Id { get; set; }
        public int PlatformId { get; set; }
        public int MovieId { get; set; }

        public Platform Platform { get; set; }

        public Movie Movie { get; set; }
    }
}