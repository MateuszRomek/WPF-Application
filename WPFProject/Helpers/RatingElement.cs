using System;
using System.Collections.Generic;
using System.Text;

namespace WPFProject
{
    public class RatingElement
    {
        public int Id { get; set; }
        public string RatingName { get; set; }
        public RatingElement(string name, int id)
        {
            RatingName = name;
            Id = id;
        }
    }
}
