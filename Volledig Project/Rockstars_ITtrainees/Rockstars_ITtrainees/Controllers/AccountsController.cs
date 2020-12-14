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
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Authorization.Policy;

namespace ITtrainees.MVC.Controllers
{
    [Authorize]
    [Route("Accounts")]
    public class AccountsController : Controller
    {
        private readonly IPolicyEvaluator policyEvaluator;

        /*public AccountsController(IPolicyEvaluator policyEvaluator)
        {
            this.policyEvaluator = policyEvaluator;
        }*/


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
        public async Task<ActionResult> Login(LoginViewModel model)
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
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            }

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties();

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return RedirectToAction("Index", "Home");
        }

        
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index","Home");
        }


        //[Authorize(Roles = "Admin")]
        [Route("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin")]
        [Route("register")]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var hasher = new PasswordHasher<Account>();

            Account tempAccount = new Account(0,model.Username, 0, model.IsAdmin, model.Password);

            string hashedPW = hasher.HashPassword(tempAccount, model.Password);

            tempAccount.Password = hashedPW;         
            APIHelper.InitializeClient();
            AccountOperations.Create(tempAccount);

            return RedirectToAction("Login");
        }
    }
}
