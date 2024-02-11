using BehrendTutor.Data;
using Microsoft.AspNetCore.Mvc;

namespace BehrendTutor.Controllers
{
    public class PersonController : Controller
    {
        private readonly BehrendTutorContext _context;

        public PersonController(BehrendTutorContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
