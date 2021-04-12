using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DeliveryApp.Data;
using DeliveryApp.Models;
using Microsoft.AspNetCore.Authorization;
using DeliveryApp.Models.Common.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using DeliveryApp.Models.ViewModels;

namespace DeliveryApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DeliveryMenController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public DeliveryMenController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.DeliveryMans.ToListAsync());
        }

     


        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: DeliveryMen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DeliveryMan deliveryMan)
        {
            if (ModelState.IsValid)
            {
                deliveryMan.Status = 0;
                _context.Add(deliveryMan);
                int count = await _context.SaveChangesAsync();

                deliveryMan.DeliveryManIdNo = "DM000" + deliveryMan.Id.ToString();
                _context.Update(deliveryMan);
                await _context.SaveChangesAsync();
                //if (count==1)
                //{
                //var checkDelivery = _context.Users.Where(m => m.UserName == deliveryMan.UserName).FirstOrDefaultAsync();
                //if (checkDelivery!=null)
                //{
                //    Random rnd = new Random();
                //    deliveryMan.UserName+=rnd.Next(1, 256).ToString();
                //}

                //var user = new ApplicationUser()
                //{
                //    UserName = deliveryMan.UserName,
                //    Email = deliveryMan.Email,
                //    UserTypeId = 3,
                //    PhoneNumber = deliveryMan.PhoneNumber,
                //    Status = 0
                //};
                //Create user with password
                //var result = await _userManager.CreateAsync(user,"Delivery123#");
                //deliveryMan.ApplicationUserId = user.Id;
                //deliveryMan.DeliveryManIdNo = "DM000" + deliveryMan.Id.ToString();
                //_context.Update(deliveryMan);
                //await _context.SaveChangesAsync();
                //await _userManager.AddToRoleAsync(user, "DeliveryMan");
                // }
                return RedirectToAction(nameof(Index));
            }
            return View(deliveryMan);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryMan = await _context.DeliveryMans.FindAsync(id);
            if (deliveryMan == null)
            {
                return NotFound();
            }
            return View(deliveryMan);
        }
         
        // POST: DeliveryMen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DeliveryMan deliveryMan)
        {
            if (id != deliveryMan.Id)
            {
                return NotFound();
            }
            var tempDeliveryMan = await _context.DeliveryMans.Where(m => m.Id == id).FirstOrDefaultAsync();
            tempDeliveryMan.Name = deliveryMan.Name;
            tempDeliveryMan.Email = deliveryMan.Email;
            tempDeliveryMan.NIDNumber = deliveryMan.NIDNumber;
            tempDeliveryMan.PhoneNumber = deliveryMan.PhoneNumber;
            tempDeliveryMan.Address = deliveryMan.Address;
            tempDeliveryMan.Status = 0;

            try
            {
                _context.Update(tempDeliveryMan);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryManExists(deliveryMan.Id))
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


        private bool DeliveryManExists(int id)
        {
            return _context.DeliveryMans.Any(e => e.Id == id);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Enable(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delivaryMan = await _context.DeliveryMans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (delivaryMan == null)
            {
                return NotFound();
            }
            else
            {
                delivaryMan.Status = 1;
                _context.Update(delivaryMan);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Disable(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delivaryMan = await _context.DeliveryMans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (delivaryMan == null)
            {
                return NotFound();
            }
            else
            {
                delivaryMan.Status = 0;
                _context.Update(delivaryMan);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

        }
        [HttpPost]
        public async Task<JsonResult> AddPickupDelivaryMan(int id, int delivaryManId)
        {
            var pickUpRequest = await _context.PickUpRequests.Where(m => m.Id == id).FirstOrDefaultAsync();


            if (pickUpRequest != null)
            {
                 pickUpRequest.PickUpDeliveryManId = delivaryManId;
                _context.Update(pickUpRequest);
                await _context.SaveChangesAsync();

                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
        [HttpPost]
        public async Task<JsonResult> GetDelivaryMen()
        {
            var deliveryMen = await _context.DeliveryMans.Where(m => m.Status == 1).ToListAsync();
            return Json(deliveryMen);

        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignPackages(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryMan = await _context.DeliveryMans.FindAsync(id);
            if (deliveryMan == null)
            {
                return NotFound();
            }
            AssignDMViewModel deliveryMan1 = new AssignDMViewModel();
            deliveryMan1.Id = deliveryMan.Id;
            deliveryMan1.Name = deliveryMan.Name;

            ViewData["Packages"] = new SelectList(_context.Packages.Where(m => m.Status == 4 && m.DeliveryManId==null), "Id", "TrackingNumber");
            return View(deliveryMan1);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignPackages(AssignDMViewModel deliveryMan)
        {
            foreach (var package in deliveryMan.Packages)
            {
                var tmpPackage = await _context.Packages.Where(m => m.Id == package).FirstOrDefaultAsync();
                tmpPackage.DeliveryManId = deliveryMan.Id;
                tmpPackage.AssignDate = DateTime.Now;
                tmpPackage.Status = 5;

                _context.Update(tmpPackage);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> TodaysPackages(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var delivaryMan = await _context.DeliveryMans.Where(m => m.Id == id).FirstOrDefaultAsync();
            var todaysPackages = await _context.Packages
                 .Include(p => p.PickUpRequest)
                .Include(p => p.PickUpRequest.PickUpDeliveryMan)
                .Include(p => p.PickUpRequest.Merchant)
                .Include(p => p.PickUpRequest.LocationFrom)
                .Include(p => p.LocationTo)
                .Include(p => p.DeliveryMan)
                .Include(p => p.PackageCatagory)
                .Where(m=> (m.DeliveryManId == id)&& (m.AssignDate==DateTime.Now.Date || m.Status==5)).ToListAsync();
            if (todaysPackages == null)
            {
                return NotFound();
            }
            ViewData["DM"] = delivaryMan;

            return View(todaysPackages);
        }

        [HttpPost]
        public async Task<JsonResult> AddDelivaryMan(int id, int delivaryManId)
        {
            var package = await _context.Packages.Where(m => m.Id == id).FirstOrDefaultAsync();


            if (package != null)
            {
                package.DeliveryManId = delivaryManId;
                _context.Update(package);
                await _context.SaveChangesAsync();

                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
    }
}
