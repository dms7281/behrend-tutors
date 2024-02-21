using BehrendTutor.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BehrendTutor.Controllers
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
            int id = 1;

            switch (id)
            {
                case 1:
                    return View("Views/Student/Index.cshtml");
                case 2:
                    return View("Index", "Tutor");
                default:
                    return View("Views/Student/Index.cshtml");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
