using BehrendTutors.Models;
using Microsoft.AspNetCore.Mvc;

namespace BehrendTutors.Controllers
{
    public class TutorSessionClassController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /*public IActionResult Composite()
        {
            var TutorSessionClass = new TutorSessionClass()
            {
                TutorSessionData
            };
        }*/

        public async Task<IActionResult> TutorCreate(TutorSession ts)
        {
            DateTime SessionDateTime = ts.SessionDateTime;
            Class? Class = ts.Class;

            return View();
        }
    }
}
