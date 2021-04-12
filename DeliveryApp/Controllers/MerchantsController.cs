using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeliveryApp.Data;
using DeliveryApp.Models;
using DeliveryApp.Models.Common.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace DeliveryApp.Controllers
{
    public class MerchantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;
        public MerchantsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ActiveIndex()
        {
            var applicationDbContext = _context.Merchants.Include(m => m.ApplicationUser).Where(m=> m.ApplicationUser.Status==1).OrderBy(m=> m.Name);
            return View(await applicationDbContext.ToListAsync());
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PendingIndex()
        {
            var applicationDbContext = _context.Merchants.Include(m => m.ApplicationUser).Where(m=> m.ApplicationUser.Status==0).OrderBy(m => m.Name);
            return View(await applicationDbContext.ToListAsync());
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DisabledIndex()
        {
            var applicationDbContext = _context.Merchants.Include(m => m.ApplicationUser).Where(m=> m.ApplicationUser.Status==2).OrderBy(m => m.Name);
            return View(await applicationDbContext.ToListAsync());
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Activate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merchant = await _context.Merchants.Include(m => m.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (merchant == null)
            {
                return NotFound();
            }
            else
            {
                merchant.ApplicationUser.Status = 1;
                _context.Update(merchant);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(ActiveIndex));
            }

        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Disable(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merchant = await _context.Merchants.Include(m => m.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (merchant == null)
            {
                return NotFound();
            }
            else
            {
                merchant.ApplicationUser.Status = 2;
                _context.Update(merchant);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(DisabledIndex));
            }

        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Enable(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merchant = await _context.Merchants.Include(m => m.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (merchant == null)
            {
                return NotFound();
            }
            else
            {
                merchant.ApplicationUser.Status = 1;
                _context.Update(merchant);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(ActiveIndex));
            }

        }

        
    }
}
