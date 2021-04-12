using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryApp.Data;
using DeliveryApp.Models;
using DeliveryApp.Models.Common.Authentication;
using DeliveryApp.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DeliveryApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // GET: /Account/Login
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Public()
        {
            return View();
        }
          [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                //Find User
                var user = await _userManager.FindByNameAsync(loginViewModel.UserName);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, loginViewModel.RememberMe, false);
                    if (result.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Provided Password is Incorrect!");
                    }
                }
                else
                {
                    ModelState.TryAddModelError("", "The UserName or Password Provided is Incorrect");
                }
            }

            //Not found user or password did not matched            
            return View(loginViewModel);
        }

        [HttpGet]
        //[Authorize]
        public IActionResult Register()
        {
            //var userTypes = _context.UserTypes.ToList();
            //ViewData["UserTypeId"] = new SelectList(userTypes, "Id", "Name");

            //var gates = _context.Gates.ToList();
            //ViewData["GateId"] = new SelectList(gates, "Id", "Name");

            //var yards = _context.Yards.ToList();
            //ViewData["YardId"] = new SelectList(yards, "Id", "Name");

            return View();
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                //var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name); //LoggedIn User

                //Create user
                var user = new ApplicationUser()
                {
                    UserName = registerViewModel.UserName,
                    Email = registerViewModel.Email,
                    UserTypeId = 2,
                    PhoneNumber = registerViewModel.PhoneNumber,
                    Status = 0
                };
                //Create user with password
                var result = await _userManager.CreateAsync(user, registerViewModel.Password);
                //Redirect User
                if (result.Succeeded)
                {
                    var merchant = new Merchant
                    {
                        ApplicationUserId = user.Id,
                        Name = registerViewModel.FullName,
                        Address = registerViewModel.Address
                        };
                        _context.Add(merchant);
                    int count = await _context.SaveChangesAsync();

                    if (count == 1)
                    {
                        merchant.MerchantIdNo ="M000"+ merchant.Id.ToString();
                        _context.Update(merchant);
                        int count2 = await _context.SaveChangesAsync();

                        await _userManager.AddToRoleAsync(user, "Merchant");
                        
                    }

                    return RedirectToAction("Index", "Home");
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(registerViewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Public", "Account");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> UpdatePassword(string userId)
        {
            if (userId == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            var updatePasswordViewModel = new UpdatePasswordViewModel
            {
                UserId = user.Id
            };

            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdatePassword(string userId, UpdatePasswordViewModel updatePasswordViewModel)
        {

            if (userId == null)
            {
                return NotFound();
            }

            if (userId != updatePasswordViewModel.UserId)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //Update password of user
                var result = await _userManager.ChangePasswordAsync(user, updatePasswordViewModel.PreviousPassword, updatePasswordViewModel.NewPassword);
                //Redirect User
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(updatePasswordViewModel);
        }

    }
}