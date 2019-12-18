using System;
using System.Collections.Generic;
namespace CheeseMVC.Models
{
    public class Cheese
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Wines { get; set; }

        public Cheese(string name, string description, List<string> wines)
        {
            Name = name;
            Description = description;
            Wines = wines;
        }

        public Cheese(string name, string description) : this(name, description, null) { }

        public void AddToWinelist(string wine)
        {
            Wines.Add(wine);
        }
    }
}
