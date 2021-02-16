using System;
using System.Collections.Generic;
using System.Text;

namespace WPFProject
{
    public class RatingElement
    {
        /// <summary>
        /// Rating Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Rating Name
        /// </summary>
        public string RatingName { get; set; }
        public RatingElement(string name, int id)
        {
            RatingName = name;
            Id = id;
        }
    }
}
