using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Travel.Web.Data;
using Travel.Web.Data.Entities;

namespace Travel.Web.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly DataContext _context;



        public ExpensesController(DataContext context)
        {
            _context = context;
        }



        // GET: Expenses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Expenses.ToListAsync());
        }




        // GET: Expenses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseEntity = await _context.Expenses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expenseEntity == null)
            {
                return NotFound();
            }

            return View(expenseEntity);
        }


        /*

        // GET: Expenses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Expenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Value")] ExpenseEntity expenseEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expenseEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expenseEntity);
        }

        // GET: Expenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseEntity = await _context.ExpenseEntity.FindAsync(id);
            if (expenseEntity == null)
            {
                return NotFound();
            }
            return View(expenseEntity);
        }

        // POST: Expenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Value")] ExpenseEntity expenseEntity)
        {
            if (id != expenseEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expenseEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseEntityExists(expenseEntity.Id))
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
            return View(expenseEntity);
        }

        // GET: Expenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseEntity = await _context.ExpenseEntity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expenseEntity == null)
            {
                return NotFound();
            }

            return View(expenseEntity);
        }

        // POST: Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expenseEntity = await _context.ExpenseEntity.FindAsync(id);
            _context.ExpenseEntity.Remove(expenseEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseEntityExists(int id)
        {
            return _context.ExpenseEntity.Any(e => e.Id == id);
        }

    */



    }
}
