using System.Collections.Generic;
using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        private static List<Cheese> Cheeses = new List<Cheese>();

        // GET: /<controller>/
        // /Cheese/Index -- Get request
        public IActionResult Index()
        {
            ViewBag.cheeses = Cheeses;

            return View();
        }

        [Route("/Cheese")]
        [Route("/Cheese/Index")]
        [HttpPost]
        public IActionResult RemoveCheese(string[] cheese_remove)
        {
            // Loop through the cheeses to remove from the HTML Form
            foreach(string ch in cheese_remove)
            {
                // Loop through the Cheeses list to find the object
                // corresponding to the cheese to remove
                foreach(Cheese cheeseObject in Cheeses)
                {
                    if (ch.Equals(cheeseObject.Name))
                    {
                        Cheeses.Remove(cheeseObject);
                        break;
                    }
                }
            }

            return Redirect("/Cheese/Index");
        }

        public IActionResult Add()
        {
            return View();
        }

        [Route("/Cheese/Add")]
        [HttpPost]
        public IActionResult NewCheese(string name, string description)
        {
            Cheese ch = new Cheese(name, description);
            Cheeses.Add(ch);

            return Redirect("/Cheese");
        }
    }
}
