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
    public class MonthlyFinanceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MonthlyFinanceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MonthlyFinance
        public async Task<IActionResult> Index()
        {
            return View(await _context.Finance.ToListAsync());
        }

        // GET: MonthlyFinance/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monthlyFinance = await _context.Finance
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monthlyFinance == null)
            {
                return NotFound();
            }

            return View(monthlyFinance);
        }

        // GET: MonthlyFinance/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MonthlyFinance/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Item,Date,Amount")] MonthlyFinance monthlyFinance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monthlyFinance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(monthlyFinance);
        }

        // GET: MonthlyFinance/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monthlyFinance = await _context.Finance.FindAsync(id);
            if (monthlyFinance == null)
            {
                return NotFound();
            }
            return View(monthlyFinance);
        }

        // POST: MonthlyFinance/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Item,Date,Amount,Type")] MonthlyFinance monthlyFinance)
        {
            if (id != monthlyFinance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monthlyFinance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonthlyFinanceExists(monthlyFinance.Id))
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
            return View(monthlyFinance);
        }

        // GET: MonthlyFinance/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monthlyFinance = await _context.Finance
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monthlyFinance == null)
            {
                return NotFound();
            }

            return View(monthlyFinance);
        }

        // POST: MonthlyFinance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monthlyFinance = await _context.Finance.FindAsync(id);
            _context.Finance.Remove(monthlyFinance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonthlyFinanceExists(int id)
        {
            return _context.Finance.Any(e => e.Id == id);
        }
    }
}
