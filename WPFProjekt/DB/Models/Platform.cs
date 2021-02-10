using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFProjekt.DB.Models
{
    public class Platform
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PlatformName { get; set; }
    }
}
