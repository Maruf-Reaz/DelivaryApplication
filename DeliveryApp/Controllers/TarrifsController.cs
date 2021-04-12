using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeliveryApp.Data;
using DeliveryApp.Models;

namespace DeliveryApp.Controllers
{
    public class TarrifsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TarrifsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tarrifs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Tarrifs.Include(t => t.LocationFrom).Include(t => t.LocationTo).Include(t => t.PackageCatagory);
            return View(await applicationDbContext.ToListAsync());
        }

         public async Task<IActionResult> MarchentTarrifIndex()
        {
            var applicationDbContext = _context.Tarrifs.Include(t => t.LocationFrom).Include(t => t.LocationTo).Include(t => t.PackageCatagory).Where(m=> m.Status==1);
            return View(await applicationDbContext.ToListAsync());
        }

       

        // GET: Tarrifs/Create
        public IActionResult Create()
        {
            ViewData["LocationFromId"] = new SelectList(_context.Locations.Where(m=> m.Status==1), "Id", "Name");
            ViewData["LocationToId"] = new SelectList(_context.Locations.Where(m => m.Status == 1), "Id", "Name");
            ViewData["PackageCatagoryId"] = new SelectList(_context.PackageCatagoies.Where(m => m.Status == 1), "Id", "Name");
            return View();
        }

        // POST: Tarrifs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tarrif tarrif)
        {
            tarrif.Status = 0;
            if (ModelState.IsValid)
            {
                _context.Add(tarrif);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationFromId"] = new SelectList(_context.Locations.Where(m => m.Status == 1), "Id", "Name", tarrif.LocationFromId);
            ViewData["LocationToId"] = new SelectList(_context.Locations.Where(m => m.Status == 1), "Id", "Name", tarrif.LocationToId);
            ViewData["PackageCatagoryId"] = new SelectList(_context.PackageCatagoies.Where(m => m.Status == 1), "Id", "Name", tarrif.PackageCatagoryId);
            return View(tarrif);
        }

        // GET: Tarrifs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarrif = await _context.Tarrifs.FindAsync(id);
            if (tarrif == null)
            {
                return NotFound();
            }
            ViewData["LocationFromId"] = new SelectList(_context.Locations.Where(m => m.Status == 1), "Id", "Name", tarrif.LocationFromId);
            ViewData["LocationToId"] = new SelectList(_context.Locations.Where(m => m.Status == 1), "Id", "Name", tarrif.LocationToId);
            ViewData["PackageCatagoryId"] = new SelectList(_context.PackageCatagoies.Where(m => m.Status == 1), "Id", "Name", tarrif.PackageCatagoryId);
            return View(tarrif);
        }

        // POST: Tarrifs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Tarrif tarrif)
        {
            if (id != tarrif.Id)
            {
                return NotFound();
            }
            tarrif.Status = 0;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarrif);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TarrifExists(tarrif.Id))
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
            ViewData["LocationFromId"] = new SelectList(_context.Locations.Where(m => m.Status == 1), "Id", "Name", tarrif.LocationFromId);
            ViewData["LocationToId"] = new SelectList(_context.Locations.Where(m => m.Status == 1), "Id", "Name", tarrif.LocationToId);
            ViewData["PackageCatagoryId"] = new SelectList(_context.PackageCatagoies.Where(m => m.Status == 1), "Id", "Name", tarrif.PackageCatagoryId);
            return View(tarrif);
        }

        public async Task<IActionResult> Enable(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarrif = await _context.Tarrifs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tarrif == null)
            {
                return NotFound();
            }
            else
            {
                tarrif.Status = 1;
                _context.Update(tarrif);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

        }
        public async Task<IActionResult> Disable(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarrif = await _context.Tarrifs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tarrif == null)
            {
                return NotFound();
            }
            else
            {
                tarrif.Status = 0;
                _context.Update(tarrif);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

        }

        private bool TarrifExists(int id)
        {
            return _context.Tarrifs.Any(e => e.Id == id);
        }
        
             [HttpPost]
        public async Task<JsonResult> GetPrice(int locationFrom, int locationTo, double weightInput, int catagoryId)
        {
            var tarrif = await _context.Tarrifs.Where(m => m.LocationFromId == locationFrom && m.LocationToId == locationTo ).FirstOrDefaultAsync();


            if (tarrif!= null)
            {
                double price = 0;
                price = tarrif.Amount;

                if (weightInput>1)
                {
                    int extraWeight = (int)weightInput - 1;

                    price += (extraWeight * 10);
                }
              
                return Json(price);
            }
            else
            {
                return Json(false);
            }
        }


    }
}
