using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BehrendTutors.Data;
using BehrendTutors.Models;

namespace BehrendTutors.Controllers
{
    public class TutorController : Controller
    {
        private readonly BehrendTutorsContext _context;

        public TutorController(BehrendTutorsContext context)
        {
            _context = context;
        }

        // GET: Tutor
        public async Task<IActionResult> Index()
        {
            var classList = new List<Class>();
            foreach (Class c in _context.Class)
            {
                classList.Add(c);
            }

            ViewData["Classes"] = classList;
            return View(await _context.TutorSession.ToListAsync());
        }

        // GET: Tutor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tutor = await _context.Tutor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tutor == null)
            {
                return NotFound();
            }

            return View(tutor);
        }

        // GET: Tutor/Create
        public IActionResult Create()
        {
            ViewBag.AllClasses = _context.Class.ToList() ?? new List<Class>();
            if (ViewBag.AllClasses == null)
            {
                ViewBag.AllClasses = new List<Class>();
            }

            return View();
        }

        // POST: Tutor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,SelectedClassIds")] Tutor tutor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tutor);
                await _context.SaveChangesAsync();

                /*If the SelectedClassIds list is not null and the list has any items then for each class in the db context,
                if the SelectedClassIds list contains the id of whatever the current class is in the loop, then add it to the TutorClass model*/
                if(tutor.SelectedClassIds != null && tutor.SelectedClassIds.Any())
                {
                    foreach(Class c in _context.Class)
                    {
                        if (tutor.SelectedClassIds.Contains(c.id))
                        {
                            tutor.TutorClasses?.Add(new TutorClass { TutorId = tutor.Id, ClassId = c.id });
                        }
                    }
                    
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction("Index", "Admins");
            }

            // If the model state is not valid, reload the available classes
            ViewBag.AllClasses = _context.Class.ToList() ?? new List<Class>(); ;
            return View(tutor);
        }

        // GET: Tutor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tutor = await _context.Tutor.FindAsync(id);
            if (tutor == null)
            {
                return NotFound();
            }

            ViewBag.AllClasses = _context.Class.ToList() ?? new List<Class>();
            if (ViewBag.AllClasses == null)
            {
                ViewBag.AllClasses = new List<Class>();
            }

            ViewBag.AllTutorClasses = _context.TutorClass.ToList() ?? new List<TutorClass>();
            if (ViewBag.AllClasses == null)
            {
                ViewBag.AllClasses = new List<Class>();
            }


            return View(tutor);
        }

        // POST: Tutor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,SelectedClassIds")] Tutor tutor)
        {
            if (id != tutor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tutor);

                    if (tutor.SelectedClassIds != null && tutor.SelectedClassIds.Any())
                    {
                        foreach (Class c in _context.Class)
                        {
                            if (tutor.SelectedClassIds.Contains(c.id))
                            {
                                tutor.TutorClasses?.Add(new TutorClass { TutorId = tutor.Id, ClassId = c.id });
                            }
                        }

                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TutorExists(tutor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Admins");
            }
            return View(tutor);
        }

        // GET: Tutor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tutor = await _context.Tutor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tutor == null)
            {
                return NotFound();
            }

            return View(tutor);
        }

        // POST: Tutor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tutor = await _context.Tutor.FindAsync(id);
            if (tutor != null)
            {
                _context.Tutor.Remove(tutor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Admins");
        }

        private bool TutorExists(int id)
        {
            return _context.Tutor.Any(e => e.Id == id);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteClass(int id, int classId)
        {
            foreach(TutorClass tc in _context.TutorClass)
            {
                if(tc.TutorId == id && tc.ClassId == classId)
                {
                    _context.TutorClass.Remove(tc);
                }
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Admins");
        }


    }
}
