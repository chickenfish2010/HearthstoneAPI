using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentWebService.Models
{
    public class CardsContextInitializer : DropCreateDatabaseAlways<CardsContext>
    {
        // Put initial data into the database
        protected override void Seed(CardsContext context)
        {

            //string readText;
            //string path = @"c:\GitHub\HearthStoneAPI\AllSets.json";

            //if (File.Exists(path))
            //{
            //    readText = File.ReadAllText(path);
            //    file = JObject.Parse(readText);
            //    Console.WriteLine("Parsed File");
            //}

            //Console.WriteLine(file.ToString());

            //// the contents of this if statement were borrowed heavily from:
            ////http://www.newtonsoft.com/json/help/html/SerializingJSONFragments.htm
            //if (file != null)
            //{
            //    IList<JToken> results = file["Basic"].Children().ToList();

            //    Console.Write(results);

            //    foreach (var card in results)
            //    {
            //        Card cardToAdd = JsonConvert.DeserializeObject<Card>(card.ToString());
            //        Cards.Add(cardToAdd);
            //    }
            //}
            var Cards = new List<Card>
            {
                new Card { Id = "GAME_004",Name ="AFK",Type ="Enchantment",Text ="Your turns are shorter."},
                new Card {Id ="EX1_066",Name ="Acidic Swamp Ooze",Type ="Minion",Faction ="Alliance",Rarity ="Common",Cost =2,Attack = 3,Health = 2,Text ="<b>Battlecry:</b> Destroy your opponent's weapon.",Flavor = "Oozes love Flamenco.  Don't ask.",Artist = "Chris Rahn",Collectible = true,HowToGetGold = "Unlocked at Rogue Level 57.",Mechanics = "Battlecry"},
                new Card {Id ="CS2_041",Name ="Ancestral Healing",Type ="Spell",Faction ="Neutral",Rarity ="Free",Cost =0,Text ="Restore a minion to full Health and give it <b>Taunt</b>.",Flavor = "I personally prefer some non-ancestral right-the-heck-now healing, but maybe that is just me.",Artist = "Dan Scott",Collectible = true,PlayerClass = "Shaman",HowToGet = "Unlocked at Level 1.",HowToGetGold = "Unlocked at Level 15."}
        
            };

            Cards.ForEach(s => context.Cards.Add(s));
            context.SaveChanges();


        }

    }

}