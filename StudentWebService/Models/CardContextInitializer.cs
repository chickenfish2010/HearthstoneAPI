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
                
            };

            Cards.ForEach(s => context.Cards.Add(s));
            context.SaveChanges();


        }

    }

}