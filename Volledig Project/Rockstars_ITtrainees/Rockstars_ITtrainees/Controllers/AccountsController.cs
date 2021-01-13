using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ITtrainees.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ITtrainees.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using ITtrainees.MVC.APITools;

namespace ITtrainees.MVC.Controllers
{
    public class AccountsController : Controller
    {

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid) return View(model);

            //get use by username and only continue if it exists 

            APIHelper.InitializeClient();
            Account user = await AccountOperations.Get(model.Username);

            //check username 
            if (user == null)
            {
                ModelState.AddModelError("", "Username or password is incorrect.");
                return View(model);
            }
            //check password
            var hasher = new PasswordHasher<Account>();
            if (hasher.VerifyHashedPassword(user, user.Password, model.Password) == PasswordVerificationResult.Failed)
            {
                ModelState.AddModelError("", "Username or password is incorrect.");
                return View(model);
            }
            
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.Name)
            };

            if (user.IsAdmin)
            {
                claims.Add(new Claim(ClaimTypes.Role,"Admin"));
            }

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties();

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return RedirectToAction("Index","Home");
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public async Task<IActionResult> Account()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Login");
            APIHelper.InitializeClient();
            Account user = await AccountOperations.Get(User.Identity.Name);
            return View(user);
        }


        public IActionResult Register()
        {
            if (!User.IsInRole("Admin")) return RedirectToAction("Login");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (!User.IsInRole("Admin")) return RedirectToAction("Login");

            if (!ModelState.IsValid) return View(model);

            Account account = await AccountOperations.Get(model.Username);

            if (account != null)
            {
                ModelState.AddModelError("Username", "Username is already in use");
                return View(model);
            }

            if (model.Password == model.PasswordCheck)
            {
                var hasher = new PasswordHasher<Account>();

            Account tempAccount = new Account(0,model.Username, model.Rockstars, model.IsAdmin, model.Password);

            string hashedPW = hasher.HashPassword(tempAccount, model.Password);

            tempAccount.Password = hashedPW;         
            APIHelper.InitializeClient();
            AccountOperations.Create(tempAccount);

            return RedirectToAction("Index","Home");

            }
            ModelState.AddModelError(nameof(model.Username), "Passwords do not match");

            return View(model); 
        }
    }
}
