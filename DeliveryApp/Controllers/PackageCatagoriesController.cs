using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DeliveryApp.Data;
using DeliveryApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace DeliveryApp.Controllers
{

    [Authorize(Roles = "Admin")]
    public class PackageCatagoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PackageCatagoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PackageCatagories
        public async Task<IActionResult> Index()
        {
            return View(await _context.PackageCatagoies.ToListAsync());
        }


        // GET: PackageCatagories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PackageCatagories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PackageCatagory packageCatagory)
        {
            packageCatagory.Status = 0;
            if (ModelState.IsValid)
            {
                _context.Add(packageCatagory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(packageCatagory);
        }

        // GET: PackageCatagories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packageCatagory = await _context.PackageCatagoies.FindAsync(id);
            if (packageCatagory == null)
            {
                return NotFound();
            }
            return View(packageCatagory);
        }

        // POST: PackageCatagories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PackageCatagory packageCatagory)
        {
            packageCatagory.Status = 0;
            if (id != packageCatagory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(packageCatagory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PackageCatagoryExists(packageCatagory.Id))
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
            return View(packageCatagory);
        }

        public async Task<IActionResult> Enable(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packageCatagory = await _context.PackageCatagoies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (packageCatagory == null)
            {
                return NotFound();
            }
            else
            {
                packageCatagory.Status = 1;
                _context.Update(packageCatagory);
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

            var packageCatagory = await _context.PackageCatagoies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (packageCatagory == null)
            {
                return NotFound();
            }
            else
            {
                packageCatagory.Status = 0;
                _context.Update(packageCatagory);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

        }


        private bool PackageCatagoryExists(int id)
        {
            return _context.PackageCatagoies.Any(e => e.Id == id);
        }
    }
}
