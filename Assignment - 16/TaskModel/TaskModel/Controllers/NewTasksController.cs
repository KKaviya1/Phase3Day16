using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskModel.Data;
using TaskModel.Models;

namespace TaskModel.Controllers
{
    public class NewTasksController : Controller
    {
        private readonly NewTaskDbContext _context;

        public NewTasksController(NewTaskDbContext context)
        {
            _context = context;
        }

        // GET: NewTasks
        public async Task<IActionResult> Index()
        {
              return _context.NewTask != null ? 
                          View(await _context.NewTask.ToListAsync()) :
                          Problem("Entity set 'NewTaskDbContext.NewTask'  is null.");
        }

        // GET: NewTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NewTask == null)
            {
                return NotFound();
            }

            var newTask = await _context.NewTask
                .FirstOrDefaultAsync(m => m.Id == id);
            if (newTask == null)
            {
                return NotFound();
            }

            return View(newTask);
        }

        // GET: NewTasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NewTasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,DueDate")] NewTask newTask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newTask);
        }

        // GET: NewTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NewTask == null)
            {
                return NotFound();
            }

            var newTask = await _context.NewTask.FindAsync(id);
            if (newTask == null)
            {
                return NotFound();
            }
            return View(newTask);
        }

        // POST: NewTasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,DueDate")] NewTask newTask)
        {
            if (id != newTask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewTaskExists(newTask.Id))
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
            return View(newTask);
        }

        // GET: NewTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NewTask == null)
            {
                return NotFound();
            }

            var newTask = await _context.NewTask
                .FirstOrDefaultAsync(m => m.Id == id);
            if (newTask == null)
            {
                return NotFound();
            }

            return View(newTask);
        }

        // POST: NewTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NewTask == null)
            {
                return Problem("Entity set 'NewTaskDbContext.NewTask'  is null.");
            }
            var newTask = await _context.NewTask.FindAsync(id);
            if (newTask != null)
            {
                _context.NewTask.Remove(newTask);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewTaskExists(int id)
        {
          return (_context.NewTask?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
