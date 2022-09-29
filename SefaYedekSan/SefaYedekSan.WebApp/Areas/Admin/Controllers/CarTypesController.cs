using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SefaYedekSan.WebApp.Data;
using SefaYedekSan.WebApp.Models;

namespace SefaYedekSan.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/CarTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CarTypes.ToListAsync());
        }

        // GET: Admin/CarTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carType = await _context.CarTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carType == null)
            {
                return NotFound();
            }

            return View(carType);
        }

        // GET: Admin/CarTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/CarTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id")] CarType carType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carType);
        }

        // GET: Admin/CarTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carType = await _context.CarTypes.FindAsync(id);
            if (carType == null)
            {
                return NotFound();
            }
            return View(carType);
        }

        // POST: Admin/CarTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id")] CarType carType)
        {
            if (id != carType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarTypeExists(carType.Id))
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
            return View(carType);
        }

        // GET: Admin/CarTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carType = await _context.CarTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carType == null)
            {
                return NotFound();
            }

            return View(carType);
        }

        // POST: Admin/CarTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carType = await _context.CarTypes.FindAsync(id);
            _context.CarTypes.Remove(carType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarTypeExists(int id)
        {
            return _context.CarTypes.Any(e => e.Id == id);
        }
    }
}
