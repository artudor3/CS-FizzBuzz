using FizzBuzz.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FizzBuzz.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FBPage()
        {
            FizzBuzzAtlas model = new FizzBuzzAtlas();
            model.FizzValue = 3;
            model.BuzzValue = 5;

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FBPage(FizzBuzzAtlas fizzBuzz)
        {
            List<string> fbItems = new List<string>();

            bool Fizz;
            bool Buzz;

            for (int i = 1; i <= 100; i++)
            {
                Fizz = i % fizzBuzz.FizzValue == 0;
                Buzz = i % fizzBuzz.BuzzValue == 0;

                if (Fizz && Buzz)
                {
                    fbItems.Add("FizzBuzz");
                }
                else if (Fizz)
                {
                    fbItems.Add("Fizz");
                }
                else if (Buzz)
                {
                    fbItems.Add("Buzz");
                }
                else
                {
                    fbItems.Add(i.ToString());
                }
            }

            fizzBuzz.Results = fbItems;


            return View(fizzBuzz);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}