using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WPFProject.DB.Models
{
    public class Platform
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PlatformName { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
