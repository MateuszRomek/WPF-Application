using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WPFProject.DB.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int RatingValue { get; set; }
    }
}
