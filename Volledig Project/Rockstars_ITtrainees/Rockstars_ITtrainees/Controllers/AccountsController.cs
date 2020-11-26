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

namespace ITtrainees.MVC.Controllers
{
    [Authorize]
    [Route("Accounts")]
    public class AccountsController : Controller
    {

        [AllowAnonymous]
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Route("login")]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid) return View(model);
            
            //get use by username and only continue if it exists 
            var user = new User();//moet via de dal gaan om de username op te halen
            //check username 
            if (user == null)
            {
                ModelState.AddModelError("", "The username or password is incorrect.");
                return View(model);
            }
            //check password
            var hasher = new PasswordHasher<User>();
            if (hasher.VerifyHashedPassword(user, user.Password, model.Password) == PasswordVerificationResult.Failed)
            {
                ModelState.AddModelError("", "The username or password is incorrect.");
                return View(model);
            }
            
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.Username)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties();

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return LocalRedirect((returnUrl));
        }


        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        [Route("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Route("register")]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var hasher = new PasswordHasher<User>();

            string hashedPW = hasher.HashPassword(new User(), model.Password);

            //add new user to database with model.username and hashedPW

            return RedirectToAction("Login", new {returnUrl = "/"});
        }


    }
}
