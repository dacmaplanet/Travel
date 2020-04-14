using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Travel.common.Enums;
using Travel.Web.Data;
using Travel.Web.Data.Entities;

namespace Travel.Web.Controllers
{
    public class TravelsController : Controller
    {
        private readonly DataContext _context;



        public TravelsController(DataContext context)
        {
            _context = context;
        }

        


        public async Task<IActionResult> Index()
        {
            return View(await _context.Users
                .Where(u => u.UserType == UserType.Employee)
                .Include(u => u.Travels)
                .OrderBy(u => u.FirstName).ThenBy(u => u.LastName)
                .ToListAsync());
        }







        // GET: Travels/Details/5
        public async Task<IActionResult> DetailUserTravels(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserEntity userEntity = await _context.Users
                .Include(u => u.Travels)
                .FirstOrDefaultAsync(u => u.Id == id);


            if (userEntity == null)
            {
                return null;
            }

            return View(userEntity);
        }

        /*
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Reservation")] TravelEntity travelEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(travelEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(travelEntity);
        }

        // GET: Travels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelEntity = await _context.Travels.FindAsync(id);
            if (travelEntity == null)
            {
                return NotFound();
            }
            return View(travelEntity);
        }

        // POST: Travels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Reservation")] TravelEntity travelEntity)
        {
            if (id != travelEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(travelEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TravelEntityExists(travelEntity.Id))
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
            return View(travelEntity);
        }

        // GET: Travels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelEntity = await _context.Travels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (travelEntity == null)
            {
                return NotFound();
            }

            return View(travelEntity);
        }

        // POST: Travels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var travelEntity = await _context.Travels.FindAsync(id);
            _context.Travels.Remove(travelEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TravelEntityExists(int id)
        {
            return _context.Travels.Any(e => e.Id == id);
        }
        */
    }
}
