using System.Collections.Generic;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        // GET: /<controller>/
        // /Cheese/Index -- Get request
        public IActionResult Index()
        {
            List<Cheese> cheeses = CheeseData.GetAll();

            return View(cheeses);
        }

        [Route("/Cheese")]
        [Route("/Cheese/Index")]
        [HttpPost]
        public IActionResult RemoveCheese(int[] cheeseIds)
        {
            foreach (int cheeseId in cheeseIds)
            {
                CheeseData.Remove(cheeseId);
            }

            return Redirect("/Cheese/Index");
        }

        public IActionResult Add()
        {
            AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel();

            return View(addCheeseViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        {
            if (ModelState.IsValid)
            {
                Cheese newCheese = addCheeseViewModel.CreateCheese();

                CheeseData.Add(newCheese);

                return Redirect("/Cheese");
            }

            return View(addCheeseViewModel);
        }

        // GET /Cheese/Edit?cheeseId=#
        public IActionResult Edit(int cheeseId)
        {
            Cheese ch = CheeseData.GetById(cheeseId);

            AddEditCheeseViewModel vm = new AddEditCheeseViewModel(ch);

            return View(vm);
        }

        // POST /Cheese/Edit
        [HttpPost]
        public IActionResult Edit(AddEditCheeseViewModel vm)
        {
            // Validate the form data
            if (ModelState.IsValid)
            {
                Cheese ch = CheeseData.GetById(vm.CheeseId);
                ch.Name = vm.Name;
                ch.Description = vm.Description;
                ch.Type = vm.Type;
                ch.Rating = vm.Rating;

                return Redirect("/Cheese");
            }

            return View(vm);
        }


    }
}
