using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Models;
using Microsoft.AspNetCore.Http;

namespace HelloWorld.Controllers
{
    public class HomeController : Controller
    {
        //Setting a cookie
        public IActionResult SetCookie()
        {
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(1)
            };

            //Add this cookie to the response to send it to the browser
            Response.Cookies.Append("MyCookie", "myUserName", cookieOptions);
            return View();
        }

        //Getting / reading a cookie
        public IActionResult GetCookie()
        {
            var cookieValue = Request.Cookies["MyCookie"];

            // This needs to be an object otherwise it will treat it as a viewName
            return View((object)cookieValue);
        }

        //Add IncrementCount for Session
        public PartialViewResult IncrementCount()
        {
            return PartialView();
        }
        
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RsvpForm()
        {
            return View(new GuestResponse());
        }
        
        [HttpPost]
        public IActionResult RsvpForm(Models.GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                return View("Thanks", guestResponse);
            }
            else
            {
                return View(guestResponse);
            }
            
        }

        //Got from Sabet - how does this work??
        public PartialViewResult DisplayLoginName()
        {
            return PartialView();
        }

        [HttpGet]
        //Guessing for step 4 of the exercise
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            HttpContext.Session.SetString("UserName", loginModel.UserName);
            return RedirectToAction("Index");
        }

        public IActionResult Logoff()
        {
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Index");
        }

        

        //Product action - Razor Collections exercises
        public IActionResult Product()
        {
            //var myProduct = new Product
            //{
            //    ProductId = 1,
            //    Name = "Kayak",
            //    Description = "A boat for one person",
            //    Category = "water-sports",
            //    Price = 200m,
            //};

            return View(productRepository.Products.First());
        }

        //Products action - Collection
        [ResponseCache(Duration = 15, Location = ResponseCacheLocation.Any)]
        public IActionResult Products()
        {
            //var products = new Product[]
            //{
            //    new Product{ ProductId = 1, Name = "First One", Price = 1.11m, ProductCount = 0},
            //    new Product{ ProductId = 2, Name="Second One", Price = 2.22m, ProductCount = 1},
            //    new Product{ ProductId = 3, Name="Third One", Price = 3.33m, ProductCount = 10},
            //    new Product{ ProductId = 4, Name="Fourth One", Price = 4.44m, ProductCount = 50},
            //};

            //Set a breakpoint here to demo HTML caching
            return View(productRepository.Products);
        }




        //Dependency injection
        private IProductRepository productRepository;

        public HomeController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }


    }
}
