using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CardWebService.Models
{
    public class CardsContextInitializer : DropCreateDatabaseIfModelChanges<CardsContext>
    {
        // Put initial data into the database
        protected override void Seed(CardsContext context)
        {
            var Cards = new List<Card>
            {
                new Card { Name = "Bob Smith", Gpa = 3.0f },
                new Card { Name = "Sue White", Gpa = 3.2f },
                new Card { Name = "Jacky Blacky", Gpa = 2.9f },
            };

            Cards.ForEach(s => context.Cards.Add(s));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course { Title = "Intro to Programming", Instructor = "Steil",
                    Cards = new List<Card>() { Cards[0], Cards[1] } },               
                new Course { Title = "Web Development", Instructor = "McCown",
                    Cards = new List<Card>() { Cards[0] } },  
                new Course { Title = "Operating Systems", Instructor = "Baber",
                    Cards = new List<Card>() { Cards[2] } },
            };

            courses.ForEach(c => context.Courses.Add(c));
            context.SaveChanges();

        }

    }

}