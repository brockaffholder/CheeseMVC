using System;
using System.Collections.Generic;
using CheeseMVC.Models;

namespace CheeseMVC.ViewModels
{
    public class AddEditCheeseViewModel : AddCheeseViewModel
    {
        public int CheeseId { get; set; }

        public AddEditCheeseViewModel()
        {
        }

        public AddEditCheeseViewModel(Cheese ch, IEnumerable<CheeseCategory> categories) : base(categories)
        {
            //IEnumerable<CheeseCategory> categories):base(categories) - use above for final edit update
            // Use Cheese object to initialize the ViewModel properties
            CheeseId = ch.ID;
            Name = ch.Name;
            Description = ch.Description;
            Rating = ch.Rating;
            CategoryID = ch.CategoryID;
        }
    }
}
