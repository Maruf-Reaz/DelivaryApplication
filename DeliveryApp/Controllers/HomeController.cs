using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DeliveryApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using DeliveryApp.Models.Common.Authentication;
using DeliveryApp.Data;
using DeliveryApp.Models.ViewModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        //[Authorize(Roles = "GateAdmin, HarbourAndMarine, Mechanical, Admin, TMOffice")]
        public async Task<IActionResult> Index()
        {
            var user = (await _userManager.FindByNameAsync(HttpContext.User.Identity.Name)); //same thing
            if (await _userManager.IsInRoleAsync(user, "Admin"))
            {
                ViewData["Merchants"] = await _context.Merchants.Include(m => m.ApplicationUser).Where(m => m.ApplicationUser.Status == 1).ToListAsync();
                 ViewData["DeliveryMans"] = await _context.DeliveryMans.Where(m => m.Status == 1).ToListAsync();
                ViewData["IsAdmin"] = true;


            }
            else if (await _userManager.IsInRoleAsync(user, "Merchant"))
            {
                ViewData["Tarrifs"] = await _context.Tarrifs.Include(m => m.PackageCatagory).Include(m => m.LocationFrom).Include(m => m.LocationTo).Where(m => m.Status == 1).ToListAsync();
                ViewData["IsAdmin"] = false;
            }
            return View();
        }

        public IActionResult AssignmentData(DateTime getDate, DateTime fromDate)
        {
            if (fromDate == default(DateTime))
            {
                fromDate = DateTime.Now.Date;
            }

            ViewData["Date"] = fromDate.Date;
            return View();
        }

      
        public IActionResult Privacy()
        {
            return View();
        }
      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
