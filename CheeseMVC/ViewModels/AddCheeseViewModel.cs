﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CheeseMVC.ViewModels
{
    public class AddCheeseViewModel
    {
        [Required]
        [Display(Name = "Cheese Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must provide a description")]
        public string Description { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        //public CheeseType Type { get; set; }

        public List<SelectListItem> CheeseTypes { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public AddCheeseViewModel(IEnumerable<CheeseCategory> categories)
        {
                
            Categories = new List<SelectListItem>();

            foreach (CheeseCategory cat in categories)
            {
                Categories.Add(new SelectListItem()
                {
                    Value = cat.ID.ToString(),
                    Text = cat.Name
                });   
            }

        }
        public AddCheeseViewModel()
        {

        }

        public Cheese CreateCheese()
        {
            return new Cheese
            {
                Name = this.Name,
                Description = this.Description,
                Rating = this.Rating,
                CategoryID = this.CategoryID
            };
        }

    }
}
