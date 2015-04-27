using System;
using System.IO;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace StudentWebService.Models
{
    public class CardsContextInitializer : DropCreateDatabaseAlways<CardsContext>
    {
        private JObject file;
        // Put initial data into the database
        protected override void Seed(CardsContext context)
        {
            
            var Cards = new List<Card>
            {
                //new Card { Id = "GAME_004",Name ="AFK",Type ="Enchantment",Text ="Your turns are shorter."},
                //new Card {Id ="EX1_066",Name ="Acidic Swamp Ooze",Type ="Minion",Faction ="Alliance",Rarity ="Common",Cost =2,Attack = 3,Health = 2,Text ="<b>Battlecry:</b> Destroy your opponent's weapon.",Flavor = "Oozes love Flamenco.  Don't ask.",Artist = "Chris Rahn",Collectible = true,HowToGetGold = "Unlocked at Rogue Level 57.",Mechanics = ["Battlecry"]},
                //new Card {Id ="CS2_041",Name ="Ancestral Healing",Type ="Spell",Faction ="Neutral",Rarity ="Free",Cost =0,Text ="Restore a minion to full Health and give it <b>Taunt</b>.",Flavor = "I personally prefer some non-ancestral right-the-heck-now healing, but maybe that is just me.",Artist = "Dan Scott",Collectible = true,PlayerClass = "Shaman",HowToGet = "Unlocked at Level 1.",HowToGetGold = "Unlocked at Level 15."}
        
            };

            Console.WriteLine(Cards.ToString());

            string readText;
            string path = @"c:\Users\acancie1\Documents\HearthStoneAPI\AllSets.json";

            if (File.Exists(path))
            {
                readText = File.ReadAllText(path);
                file = JObject.Parse(readText);
                Console.WriteLine("Parsed File");
            }

            Console.WriteLine(file.ToString());

            // the contents of this if statement were borrowed heavily from:
            //http://www.newtonsoft.com/json/help/html/SerializingJSONFragments.htm
            if (file != null)
            {
                IList<JToken> results = file["Card"].Children().ToList();

                foreach (var card in results)
                {
                    //Card cardToAdd = JsonConvert.DeserializeObject<Card>(card.ToString());
                    Card cardToAdd = new Card();
                    cardToAdd.Id = (string)card["id"];
                    cardToAdd.Name = (string)card["name"];
                    cardToAdd.Type = (string)card["type"];
                    cardToAdd.Text = (string)card["text"];
                    cardToAdd.Faction = (string)card["faction"];
                    cardToAdd.Rarity = (string)card["rarity"];
                    
                    if (card["cost"] != null)
                    {
                        cardToAdd.Cost = (int)card["cost"];
                    }
                    else
                    {
                        cardToAdd.Cost = 0;
                    }

                    if (card["attack"] != null)
                    {
                        cardToAdd.Cost = (int)card["attack"];
                    }
                    else
                    {
                        cardToAdd.Attack = 0;
                    }
                    cardToAdd.Flavor = (string)card["flavor"];
                    //cardToAdd.Artist = (string)card["attack"];

                    if (card["collectible"] != null)
                    {
                        cardToAdd.Collectible = (bool)card["collectible"];
                    }
                    else
                    {
                        cardToAdd.Collectible = false;
                    }

                    cardToAdd.HowToGetGold = (string)card["howToGetGold"];

                    if (card["mechanics"] != null)
                    {
                        foreach (var mechanic in card["mechanics"])
                        {
                            try
                            {
                                cardToAdd.Mechanics.Add((string)mechanic);
                            }
                            catch
                            {
                                cardToAdd.Mechanics = null;
                            }
                        }
                    }
                    else
                    {
                        cardToAdd.Mechanics = null;
                    }

                    cardToAdd.PlayerClass = (string)card["playerClass"];
                    cardToAdd.HowToGet = (string)card["howToGet"];

                    if (card["health"] != null)
                    {
                        cardToAdd.Health = (int)card["health"];
                    }
                    else
                    {
                        cardToAdd.Health = 0;
                    }
                    //cardToAdd.Health = (int)card["health"];
                    //cardToAdd.Mechanics = (string[])card["mechanics"];

                    Cards.Add(cardToAdd);
                }
            }

            

            Cards.ForEach(s => context.Cards.Add(s));
            context.SaveChanges();


        }

    } 

}