using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectDbFirst.Contexts;
using ProjectDbFirst.Models;

namespace ProjectDbFirst.Controllers
{
    public class EmpsController : Controller
    {
        private readonly EMPLOYEESContext _context;

        public EmpsController(EMPLOYEESContext context)
        {
            _context = context;
        }

        // GET: Emps
        public async Task<IActionResult> Index()
        {
            var eMPLOYEESContext = _context.Emps.Include(e => e.Cty).Include(e => e.D);
            return View(await eMPLOYEESContext.ToListAsync());
        }

        // GET: Emps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emp = await _context.Emps
                .Include(e => e.Cty)
                .Include(e => e.D)
                .FirstOrDefaultAsync(m => m.EmpId == id);
            if (emp == null)
            {
                return NotFound();
            }

            return View(emp);
        }

        // GET: Emps/Create
        public IActionResult Create()
        {
            ViewData["CtyId"] = new SelectList(_context.Cities, "CityId", "CityName");
            ViewData["DId"] = new SelectList(_context.Depts, "DeptId", "DeptName");
            return View();
        }

        // POST: Emps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpId,EmpFname,EmpLname,EmpSalary,EmpHdate,DId,CtyId")] Emp emp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CtyId"] = new SelectList(_context.Cities, "CityId", "CityName", emp.CtyId);
            ViewData["DId"] = new SelectList(_context.Depts, "DeptId", "DeptName", emp.DId);
            return View(emp);
        }

        // GET: Emps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emp = await _context.Emps.FindAsync(id);
            if (emp == null)
            {
                return NotFound();
            }
            ViewData["CtyId"] = new SelectList(_context.Cities, "CityId", "CityName", emp.CtyId);
            ViewData["DId"] = new SelectList(_context.Depts, "DeptId", "DeptName", emp.DId);
            return View(emp);
        }

        // POST: Emps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpId,EmpFname,EmpLname,EmpSalary,EmpHdate,DId,CtyId")] Emp emp)
        {
            if (id != emp.EmpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpExists(emp.EmpId))
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
            ViewData["CtyId"] = new SelectList(_context.Cities, "CityId", "CityName", emp.CtyId);
            ViewData["DId"] = new SelectList(_context.Depts, "DeptId", "DeptName", emp.DId);
            return View(emp);
        }

        // GET: Emps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emp = await _context.Emps
                .Include(e => e.Cty)
                .Include(e => e.D)
                .FirstOrDefaultAsync(m => m.EmpId == id);
            if (emp == null)
            {
                return NotFound();
            }

            return View(emp);
        }

        // POST: Emps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emp = await _context.Emps.FindAsync(id);
            _context.Emps.Remove(emp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpExists(int id)
        {
            return _context.Emps.Any(e => e.EmpId == id);
        }
    }
}
