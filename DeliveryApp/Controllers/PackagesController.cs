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
using DeliveryApp.Models.ViewModels;

namespace DeliveryApp.Controllers
{
    public class PackagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;
        public PackagesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Packages
        public async Task<IActionResult> MerchantActivePackageIndex()
        {

            var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            var merchant = await _context.Merchants.Where(m => m.ApplicationUserId == loggedInUser.Id).FirstOrDefaultAsync();

            var applicationDbContext = _context.Packages.Include(p => p.DeliveryMan)
                .Include(p => p.PickUpRequest)
                .Include(p => p.PickUpRequest.PickUpDeliveryMan)
                .Include(p => p.PickUpRequest.Merchant)
                .Include(p => p.PickUpRequest.LocationFrom)
                .Include(p => p.LocationTo)
                .Include(p => p.DeliveryMan)
                .Include(p => p.PackageCatagory)
                .Where(m => m.PickUpRequest.MerchantId == merchant.Id && m.Status < 6 && m.Status > 3).OrderBy(m => m.PickUpRequest.RequestDate);
            return View(await applicationDbContext.ToListAsync());
        }


        public async Task<IActionResult> MerchantAllPackageIndex(DateTime fromDate, DateTime toDate)
        {
            if (fromDate == default(DateTime))
            {
                fromDate = DateTime.Now.AddDays(-30);
            }
            if (toDate == default(DateTime))
            {
                toDate = DateTime.Now.Date;
            }
            var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            var merchant = await _context.Merchants.Where(m => m.ApplicationUserId == loggedInUser.Id).FirstOrDefaultAsync();
            var packages = await _context.Packages
                .Include(p => p.PickUpRequest)
                .Include(p => p.PickUpRequest.PickUpDeliveryMan)
                .Include(p => p.PickUpRequest.Merchant)
                .Include(p => p.PickUpRequest.LocationFrom)
                .Include(p => p.LocationTo)
                .Include(p => p.DeliveryMan)
                .Include(p => p.PackageCatagory)
                .Where(m => m.PickUpRequest.MerchantId == merchant.Id && m.PickUpRequest.RequestDate >= fromDate && m.PickUpRequest.RequestDate <= toDate && m.Status > 3).OrderBy(m => m.PickUpRequest.RequestDate).ToListAsync();


            ViewData["Packages"] = packages;
            ViewData["FromDate"] = fromDate.Date;
            ViewData["ToDate"] = toDate.Date;
            return View();
        }
        [HttpPost]
        public IActionResult MerchantAllPackageIndex(FromDateToDateViewModel datesVM)
        {

            return RedirectToAction("MerchantAllPackageIndex", new { id = datesVM.Id, fromDate = datesVM.FromDate, toDate = datesVM.ToDate });

        }



        public async Task<IActionResult> AdminAllPackageIndex(DateTime fromDate, DateTime toDate)
        {
            if (fromDate == default(DateTime))
            {
                fromDate = DateTime.Now.AddDays(-30);
            }
            if (toDate == default(DateTime))
            {
                toDate = DateTime.Now.Date;
            }

            var packages = await _context.Packages
                 .Include(p => p.PickUpRequest)
                .Include(p => p.PickUpRequest.PickUpDeliveryMan)
                .Include(p => p.PickUpRequest.Merchant)
                .Include(p => p.PickUpRequest.LocationFrom)
                .Include(p => p.LocationTo)
                .Include(p => p.DeliveryMan)
                .Include(p => p.PackageCatagory)
                .Where(m => m.Status != 0 && m.PickUpRequest.RequestDate >= fromDate && m.PickUpRequest.RequestDate <= toDate && m.Status > 3).OrderBy(m => m.PickUpRequest.RequestDate).ToListAsync();
            ViewData["Packages"] = packages;
            ViewData["FromDate"] = fromDate.Date;
            ViewData["ToDate"] = toDate.Date;
            return View();
        }
        [HttpPost]
        public IActionResult AdminAllPackageIndex(FromDateToDateViewModel datesVM)
        {

            return RedirectToAction("AdminAllPackageIndex", new { id = datesVM.Id, fromDate = datesVM.FromDate, toDate = datesVM.ToDate });

        }



        public async Task<IActionResult> AdminActivePackageIndex()
        {
            var applicationDbContext = _context.Packages
                .Include(p => p.PickUpRequest)
                .Include(p => p.PickUpRequest.PickUpDeliveryMan)
                .Include(p => p.PickUpRequest.Merchant)
                .Include(p => p.PickUpRequest.LocationFrom)
                .Include(p => p.LocationTo)
                .Include(p => p.DeliveryMan)
                .Include(p => p.PackageCatagory)
                .Where(m => m.Status != 0 && m.Status < 6 && m.Status > 3).OrderBy(m => m.PickUpRequest.RequestDate);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> GeneratedBill(int id)
        {
            var package = await _context.Packages
                .Include(p => p.DeliveryMan)
                .Include(p => p.PickUpRequest)
                .Include(p => p.PickUpRequest.LocationFrom).Include(p => p.LocationTo).Include(p => p.PickUpRequest.Merchant).Include(p => p.PackageCatagory).Where(m => m.Id == id).FirstOrDefaultAsync();

            if (package.Status < 4)
            {
                return NotFound();
            }
            else
            {
                string inWords = package.NumberToWords((double)package.Price + (double)package.ProductPrice);
                ViewData["InWords"] = inWords;
                return View(package);
            }

        }
        public async Task<IActionResult> CreatePackages(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packageReq = await _context.PickUpRequests
                .Include(m => m.LocationFrom)
                .Include(m => m.Merchant)
                .Include(m => m.Packages)
                .ThenInclude(m => m.LocationTo)
                 .Include(m => m.Packages)
                .ThenInclude(m => m.PackageCatagory)
                .Where(m => m.Id == id).FirstOrDefaultAsync();
            if (packageReq == null)
            {
                return NotFound();
            }
            ViewData["Catagories"] =await _context.PackageCatagoies.Where(m => m.Status == 1).ToListAsync();
            ViewData["Locations"] = await _context.Locations.Where(m => m.Status == 1).ToListAsync();
            return View(packageReq);
        }



        [HttpPost]
        public async Task<JsonResult> AddPackage(int catagoryId, int locationToId, string address, string phoneNo, string details, string dimension, double weight, double productPrice, double delivaryPrice, string remarks, int packageId, int pickUpRequestId)

        {
            if (packageId == 0)
            {
                Package package = new Package();
                package.PackageCatagoryId = catagoryId;
                package.LocationToId = locationToId;
                package.Address = address;
                package.PhoneNumber = phoneNo;
                package.Details = details;
                package.Dimension = dimension;
                package.Weight = weight;
                package.ProductPrice = productPrice;
                package.Price = delivaryPrice;
                package.Remarks = remarks;
                package.Status = 3;
                package.PickUpRequestId = pickUpRequestId;
                _context.Add(package);
                await _context.SaveChangesAsync();


            }

            else
            {
                var package = await _context.Packages.Where(m => m.Id == packageId).FirstOrDefaultAsync();

                package.PackageCatagoryId = catagoryId;
                package.LocationToId = locationToId;
                package.Address = address;
                package.PhoneNumber = phoneNo;
                package.Details = details;
                package.Dimension = dimension;
                package.Weight = weight;
                package.ProductPrice = productPrice;
                package.Price = delivaryPrice;
                package.Remarks = remarks;
                package.Status = 3;
                package.PickUpRequestId = pickUpRequestId;
                _context.Update(package);
                await _context.SaveChangesAsync();

            }
            return Json(true);
        }

        [HttpPost]
        public async Task<JsonResult> FinalizeRequest(int pickUpRequestId)
        {
            var request = await _context.PickUpRequests.Include(m=> m.Packages).Where(m => m.Id == pickUpRequestId).FirstOrDefaultAsync();


            if (request != null)
            {
                if (request.Packages.Count!=0)
                {
                    foreach (var package in request.Packages)
                    {
                        Random rnd = new Random();
                        package.Status = 4;
                        package.TrackingNumber = "TR" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + rnd.Next(1, 256).ToString();
                        _context.Update(package);
                        await _context.SaveChangesAsync();
                    }
                    request.Status = 4;
                    _context.Update(request);
                    await _context.SaveChangesAsync();


                }

                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

       

        public async Task<IActionResult> ShippedByAdmin(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var package = await _context.Packages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (package == null)
            {
                return NotFound();
            }
            else
            {
                package.ShippingDate = DateTime.Now;
                package.Status = 5;
                _context.Update(package);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(AdminActivePackageIndex));
            }

        }
        public async Task<IActionResult> DeleveredByAdmin(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var package = await _context.Packages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (package == null)
            {
                return NotFound();
            }
            else
            {
                package.Status = 6;
                package.DeliveryDate = DateTime.Now;
                _context.Update(package);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(AdminActivePackageIndex));
            }

        }

        public async Task<IActionResult> PartiallyDeleveredByAdmin(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var package = await _context.Packages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (package == null)
            {
                return NotFound();
            }
            else
            {
                package.Status = 7;
                package.DeliveryDate = DateTime.Now;
                _context.Update(package);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(AdminActivePackageIndex));
            }

        }

        public async Task<IActionResult> ReturnedByAdmin(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var package = await _context.Packages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (package == null)
            {
                return NotFound();
            }
            else
            {
                package.Status = 8;
                package.DeliveryDate = DateTime.Now;
                _context.Update(package);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(AdminActivePackageIndex));
            }

        }


        private bool PackageExists(int id)
        {
            return _context.Packages.Any(e => e.Id == id);
        }


        [HttpPost]
        public async Task<JsonResult> GetPackageByTrackingNumber(string trackingNumber)
        {
            if (trackingNumber == "" || trackingNumber == null)
            {

                return Json(false);
            }
            else
            {
                var package = await _context.Packages
                    .Include(m => m.DeliveryMan)
                    .Include(m => m.PickUpRequest)
                    .Include(m => m.PickUpRequest.LocationFrom)
                    .Include(m => m.LocationTo)
                    .Include(m => m.DeliveryMan)
                    .Include(m => m.PackageCatagory)
                    .Include(m => m.PickUpRequest.Merchant)
                    .Where(m => m.TrackingNumber == trackingNumber).FirstOrDefaultAsync();


               


                if (package != null)
                {
                    PublicViewModel publicViewModel = new PublicViewModel();
                    publicViewModel.Status = package.Status;
                    publicViewModel.Merchant = package.PickUpRequest.Merchant.Name;
                    publicViewModel.LocationFrom = package.PickUpRequest.LocationFrom.Name;
                    publicViewModel.LocationTo = package.LocationTo.Name;
                    publicViewModel.PackageCatagory = package.PackageCatagory.Name;
                    publicViewModel.Weight = (double)package.Weight;
                    publicViewModel.Price = (double)(package.Price + package.ProductPrice);
                    return Json(publicViewModel);
                }
                else
                {
                    return Json(false);
                }
            }

        }
    }
}
