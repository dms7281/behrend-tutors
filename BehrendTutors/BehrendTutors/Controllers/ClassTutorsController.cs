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
    public class ClassTutorsController : Controller
    {
        private readonly BehrendTutorsContext _context;

        public ClassTutorsController(BehrendTutorsContext context)
        {
            _context = context;
        }

        // GET: ClassTutors
        public async Task<IActionResult> Index()
        {
            var behrendTutorsContext = _context.ClassTutor.Include(c => c.Class).Include(c => c.Tutor);
            return View(await behrendTutorsContext.ToListAsync());
        }

        // GET: ClassTutors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classTutor = await _context.ClassTutor
                .Include(c => c.Class)
                .Include(c => c.Tutor)
                .FirstOrDefaultAsync(m => m.TutorId == id);
            if (classTutor == null)
            {
                return NotFound();
            }

            return View(classTutor);
        }

        // GET: ClassTutors/Create
        public IActionResult Create()
        {
            ViewData["ClassId"] = new SelectList(_context.Class, "id", "id");
            ViewData["TutorId"] = new SelectList(_context.Tutor, "Id", "Id");
            return View();
        }

        // POST: ClassTutors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClassId,TutorId")] ClassTutor classTutor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classTutor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassId"] = new SelectList(_context.Class, "id", "id", classTutor.ClassId);
            ViewData["TutorId"] = new SelectList(_context.Tutor, "Id", "Id", classTutor.TutorId);
            return View(classTutor);
        }

        // GET: ClassTutors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classTutor = await _context.ClassTutor.FindAsync(id);
            if (classTutor == null)
            {
                return NotFound();
            }
            ViewData["ClassId"] = new SelectList(_context.Class, "id", "id", classTutor.ClassId);
            ViewData["TutorId"] = new SelectList(_context.Tutor, "Id", "Id", classTutor.TutorId);
            return View(classTutor);
        }

        // POST: ClassTutors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClassId,TutorId")] ClassTutor classTutor)
        {
            if (id != classTutor.TutorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classTutor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassTutorExists(classTutor.TutorId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassId"] = new SelectList(_context.Class, "id", "id", classTutor.ClassId);
            ViewData["TutorId"] = new SelectList(_context.Tutor, "Id", "Id", classTutor.TutorId);
            return View(classTutor);
        }

        // GET: ClassTutors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classTutor = await _context.ClassTutor
                .Include(c => c.Class)
                .Include(c => c.Tutor)
                .FirstOrDefaultAsync(m => m.TutorId == id);
            if (classTutor == null)
            {
                return NotFound();
            }

            return View(classTutor);
        }

        // POST: ClassTutors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classTutor = await _context.ClassTutor.FindAsync(id);
            if (classTutor != null)
            {
                _context.ClassTutor.Remove(classTutor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassTutorExists(int id)
        {
            return _context.ClassTutor.Any(e => e.TutorId == id);
        }
    }
}
