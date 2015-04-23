using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardWebService.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Gpa { get; set; }

        // Represents the N:M relationship
        public ICollection<Course> Courses { get; set; }
    }
}