using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeliveryApp.Data;
using DeliveryApp.Models;
using Microsoft.AspNetCore.Identity;
using DeliveryApp.Models.Common.Authentication;

namespace DeliveryApp.Controllers
{
    public class PickUpRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public PickUpRequestsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: PickUpRequests
        public async Task<IActionResult> MarchantIndex()
        {
            var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            var merchant = await _context.Merchants.Where(m => m.ApplicationUserId == loggedInUser.Id).FirstOrDefaultAsync();
            var applicationDbContext = _context.PickUpRequests
                .Include(p => p.LocationFrom)
                .Include(p => p.Merchant)
                .Include(p => p.PickUpDeliveryMan).Where(m=> m.MerchantId == merchant.Id);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> AdminIndex()
        {
            var applicationDbContext = _context.PickUpRequests.Include(p => p.LocationFrom).Include(p => p.Merchant).Include(p => p.PickUpDeliveryMan).Where(m=> m.Status!=0);
            return View(await applicationDbContext.ToListAsync());
        }



    
        // GET: PickUpRequests/Create
        public IActionResult Create()
        {
            ViewData["LocationFromId"] = new SelectList(_context.Locations.Where(m=>m.Status==1), "Id", "Name");
            return View();
        }

        // POST: PickUpRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( PickUpRequest pickUpRequest)
        {
            var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            var merchant = await _context.Merchants.Where(m => m.ApplicationUserId == loggedInUser.Id).FirstOrDefaultAsync();

            pickUpRequest.Status = 0;
            pickUpRequest.MerchantId = merchant.Id;
            if (ModelState.IsValid)
            {
                _context.Add(pickUpRequest);
                await _context.SaveChangesAsync();

                pickUpRequest.RequestId = "Req000" + pickUpRequest.Id.ToString();
                _context.Update(pickUpRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(MarchantIndex));
            }
            ViewData["LocationFromId"] = new SelectList(_context.Locations, "Id", "Name", pickUpRequest.LocationFromId);
            return View(pickUpRequest);
        }

        // GET: PickUpRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pickUpRequest = await _context.PickUpRequests.FindAsync(id);
            if (pickUpRequest == null)
            {
                return NotFound();
            }
            ViewData["LocationFromId"] = new SelectList(_context.Locations, "Id", "Name", pickUpRequest.LocationFromId);
            return View(pickUpRequest);
        }

        // POST: PickUpRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PickUpRequest pickUpRequest)
        {
            if (id != pickUpRequest.Id)
            {
                return NotFound();
            }
            var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            var merchant = await _context.Merchants.Where(m => m.ApplicationUserId == loggedInUser.Id).FirstOrDefaultAsync();

            pickUpRequest.RequestId ="Req000" + id.ToString();
            pickUpRequest.Status = 0;
            pickUpRequest.MerchantId = merchant.Id;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pickUpRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PickUpRequestExists(pickUpRequest.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(MarchantIndex));
            }
            ViewData["LocationFromId"] = new SelectList(_context.Locations, "Id", "Name", pickUpRequest.LocationFromId);
            return View(pickUpRequest);
        }

        // GET: PickUpRequests/Delete/5
       

        private bool PickUpRequestExists(int id)
        {
            return _context.PickUpRequests.Any(e => e.Id == id);
        }

        public async Task<IActionResult> ForwardToAdmin(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pickUpRequest = await _context.PickUpRequests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pickUpRequest == null)
            {
                return NotFound();
            }
            else
            {
                var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
                var merchant = await _context.Merchants.Where(m => m.ApplicationUserId == loggedInUser.Id).FirstOrDefaultAsync();
                if (merchant.Id == pickUpRequest.MerchantId)
                {
                    pickUpRequest.RequestDate = DateTime.Now;
                    pickUpRequest.Status = 1;
                    _context.Update(pickUpRequest);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(MarchantIndex));

                }
                else
                {
                    return NotFound();
                }


            }

        }
        public async Task<IActionResult> ApproveByAdmin(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pickUpRequest = await _context.PickUpRequests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pickUpRequest == null)
            {
                return NotFound();
            }
            else
            {
                pickUpRequest.Status = 2;
                _context.Update(pickUpRequest);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(AdminIndex));
            }

        }
        public async Task<IActionResult> PickedUpByAdmin(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pickUpRequest = await _context.PickUpRequests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pickUpRequest == null)
            {
                return NotFound();
            }
            else
            {
                pickUpRequest.Status = 3;
                pickUpRequest.PickUpDate = DateTime.Now;
                _context.Update(pickUpRequest);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(AdminIndex));
            }

        }
        public async Task<IActionResult> DeclineByAdmin(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pickUpRequest = await _context.PickUpRequests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pickUpRequest == null)
            {
                return NotFound();
            }
            else
            {
                pickUpRequest.Status = 404;
                _context.Update(pickUpRequest);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(AdminIndex));
            }

        }



    }
}
