using BehrendTutor.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BehrendTutor.Controllers
{
    public class PersonController : Controller
    {
        private readonly BehrendTutorContext _context;

        public PersonController(BehrendTutorContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
