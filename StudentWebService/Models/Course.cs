using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardWebService.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Instructor { get; set; }

        // Represents the N:M relationship
        public ICollection<Card> Cards { get; set; }

    }
}