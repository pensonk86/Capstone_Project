using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Capstone_Project.Data;
using Capstone_Project.Models;

namespace Capstone_Project.Controllers
{
    public class NewGoalController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NewGoalController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NewGoal
        public async Task<IActionResult> Index()
        {
            return View(await _context.NewGoal.ToListAsync());
        }

        // GET: NewGoal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newGoal = await _context.NewGoal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (newGoal == null)
            {
                return NotFound();
            }

            return View(newGoal);
        }

        // GET: NewGoal/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NewGoal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Goal,Amount,Monthly")] NewGoal newGoal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newGoal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newGoal);
        }

        // GET: NewGoal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newGoal = await _context.NewGoal.FindAsync(id);
            if (newGoal == null)
            {
                return NotFound();
            }
            return View(newGoal);
        }

        // POST: NewGoal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Goal,Amount,Monthly")] NewGoal newGoal)
        {
            if (id != newGoal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newGoal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewGoalExists(newGoal.Id))
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
            return View(newGoal);
        }

        // GET: NewGoal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newGoal = await _context.NewGoal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (newGoal == null)
            {
                return NotFound();
            }

            return View(newGoal);
        }

        // POST: NewGoal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newGoal = await _context.NewGoal.FindAsync(id);
            _context.NewGoal.Remove(newGoal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewGoalExists(int id)
        {
            return _context.NewGoal.Any(e => e.Id == id);
        }
    }
}
