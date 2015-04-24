using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StudentWebService.Models
{
    public class CardRepository
    {
        private JObject file;
        
        public CardRepository()
        {
            string readText;
            string path = @"c:\GitHub\HearthStoneAPI\AllSets.json";

            if (!File.Exists(path))
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
                IList<JToken> results = file["Basic"].Children().ToList();

                Console.Write(results);

                foreach (var card in results)
                {
                    Card cardToAdd = JsonConvert.DeserializeObject<Card>(card.ToString());
                  Cards.Add(cardToAdd);
                }

                results = file["Blackrock Mountain"].Children().ToList();

                foreach (var card in results)
                {
                    Card cardToAdd = JsonConvert.DeserializeObject<Card>(card.ToString());
                  Cards.Add(cardToAdd);
                }

                results = file["Classic"].Children().ToList();

                foreach (var card in results)
                {
                    Card cardToAdd = JsonConvert.DeserializeObject<Card>(card.ToString());
                  Cards.Add(cardToAdd);
                }

                results = file["Credits"].Children().ToList();

                foreach (var card in results)
                {
                    Card cardToAdd = JsonConvert.DeserializeObject<Card>(card.ToString());
                  Cards.Add(cardToAdd);
                }

                results = file["Curse of Naxxramas"].Children().ToList();

                foreach (var card in results)
                {
                    Card cardToAdd = JsonConvert.DeserializeObject<Card>(card.ToString());
                  Cards.Add(cardToAdd);
                }

                results = file["Debug"].Children().ToList();

                foreach (var card in results)
                {
                    Card cardToAdd = JsonConvert.DeserializeObject<Card>(card.ToString());
                  Cards.Add(cardToAdd);
                }

                results = file["Goblins vs Gnomes"].Children().ToList();

                foreach (var card in results)
                {
                    Card cardToAdd = JsonConvert.DeserializeObject<Card>(card.ToString());
                  Cards.Add(cardToAdd);
                }

                results = file["Missions"].Children().ToList();

                foreach (var card in results)
                {
                    Card cardToAdd = JsonConvert.DeserializeObject<Card>(card.ToString());
                  Cards.Add(cardToAdd);
                }

                results = file["Promotion"].Children().ToList();

                foreach (var card in results)
                {
                    Card cardToAdd = JsonConvert.DeserializeObject<Card>(card.ToString());
                  Cards.Add(cardToAdd);
                }

                results = file["Reward"].Children().ToList();

                foreach (var card in results)
                {
                    Card cardToAdd = JsonConvert.DeserializeObject<Card>(card.ToString());
                  Cards.Add(cardToAdd);
                }
            }
        }

        // List of Cards
        private List<Card> Cards = new List<Card>(new Card[]{});

        public List<Card> GetAllCards()
        {
            return Cards;
        }

        public Card GetCard(int id)
        {
            // Return back garbage Card if the ID was not found
            Card Card = Cards.FirstOrDefault(p => p.Id.Equals(id));
            //if (Card == null)
            //    return new Card { Id = -1, Name = "NULL" };

            return Card;
        }

        public bool AddCard(Card Card)
        {
            if (Card == null)
                throw new ArgumentNullException("Card");

            // Make sure Card ID is unique
            var findCard = Cards.FirstOrDefault(p => p.Id == Card.Id);
            if (findCard == null)
            {
                Cards.Add(Card);
                return true;
            }

            return false;
        }

        public bool UpdateCard(Card Card)
        {
            // See if a Card with this ID exists so he can be replaced
            int i = Cards.FindIndex(p => p.Id == Card.Id);
            if (i == -1)
                return false;

            Cards[i] = Card;
            return true;
        }

        public bool DeleteCard(int stuId)
        {
            // See if a Card with this ID exists so he can be deleted
            int i = Cards.FindIndex(p => p.Id.Equals(stuId));
            if (i == -1)
                return false;

            Cards.RemoveAt(i);
            return true;
        }
    }			

}