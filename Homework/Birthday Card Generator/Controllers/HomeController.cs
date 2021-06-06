using Birthday_Card_Generator.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Birthday_Card_Generator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BirthdayCardForm()
        {
            return View(new BirthdayCardInput());
        }

        //Receive the data
        [HttpPost]
        public IActionResult BirthdayCardForm(Models.BirthdayCardInput birthdayCardInput)
        {
            if (ModelState.IsValid)
            {
                return View("BirthdayCard", birthdayCardInput);
            }
            else
            {
                return View(birthdayCardInput);
            }
            
        }
    }
}
