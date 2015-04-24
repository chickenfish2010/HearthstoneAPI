using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StudentWebService.Models
{
    public class Card
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }
        public string Faction { get; set; }
        public string Rarity { get; set; }
        public int Cost { get; set; }
        public int Attack { get; set; }
        public string Flavor { get; set; }
        public string Artist { get; set; }
        public bool Collectible { get; set; }
        public string HowToGetGold { get; set; }
        public string Mechanics { get; set; }
        public string PlayerClass { get; set; }
        public string HowToGet { get; set; }
        public int Health { get; set; }



        // Represents the N:M relationship
        //public ICollection<Course> Courses { get; set; }
    }
}