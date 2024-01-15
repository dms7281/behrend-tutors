using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BehrendTutors.Data;
using BehrendTutors.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
//using BehrendTutors.Migrations;

namespace BehrendTutors.Controllers
{
    public class TutorSessionsController : Controller
    {
        private readonly BehrendTutorsContext _context;

        public TutorSessionsController(BehrendTutorsContext context)
        {
            _context = context;
        }

        // GET: TutorSessions
        public async Task<IActionResult> Index()
        {
            return View(await _context.TutorSession.ToListAsync());
        }

        // GET: TutorSessions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tutorSession = await _context.TutorSession
                .FirstOrDefaultAsync(m => m.id == id);
            if (tutorSession == null)
            {
                return NotFound();
            }

            return View(tutorSession);
        }

        // GET: TutorSessions/Create
        public IActionResult Create()
        {
            

            return View();
        }

        // POST: TutorSessions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SessionDateTime,SelectedClassId,TutorIdSession")] TutorSession tutorSession)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tutorSession);
                await _context.SaveChangesAsync();
                foreach (Tutor t in _context.Tutor)
                {
                    if(tutorSession.TutorIdSession == t.Id)
                    {
                        tutorSession.Tutor = t;
                    }
                }
                await _context.SaveChangesAsync();
                
                foreach (Class c in _context.Class)
                {
                    if (tutorSession.SelectedClassId == c.id)
                    {
                        tutorSession.Class = c;
                    }
                }

                await _context.SaveChangesAsync();



                return RedirectToAction("Index", "Tutor", new { Id = tutorSession.TutorIdSession });
            }
            return View(tutorSession);
        }

        // GET: TutorSessions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tutorSession = await _context.TutorSession.FindAsync(id);
            if (tutorSession == null)
            {
                return NotFound();
            }
            return View(tutorSession);
        }

        // POST: TutorSessions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,SessionDateTime,StudentEmail")] Models.TutorSession tutorSession)
        {
            if (id != tutorSession.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tutorSession);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TutorSessionExists(tutorSession.id))
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
            return View(tutorSession);
        }

        // GET: TutorSessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tutorSession = await _context.TutorSession
                .FirstOrDefaultAsync(m => m.id == id);
            if (tutorSession == null)
            {
                return NotFound();
            }

            return View(tutorSession);
        }

        // POST: TutorSessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tutorSession = await _context.TutorSession.FindAsync(id);
            if (tutorSession != null)
            {
                _context.TutorSession.Remove(tutorSession);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TutorSessionExists(int id)
        {
            return _context.TutorSession.Any(e => e.id == id);
        }

        
    }
}
