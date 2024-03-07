using Deportivo.Common.Enums;
using Deportivo.Web.Data.Entities;
using Deportivo.Web.IServices;
using Deportivo.Web.Migrations;
using Deportivo.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Deportivo.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsers _users;

        public AccountController(IUsers users)
        {
            _users = users;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {

            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            
            if (ModelState.IsValid)
            {

                var result = await _users.LoginAsync(model);
               
                if (result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        var returnUrl = Request.Query["ReturnUrl"].First();
                        if (!string.IsNullOrEmpty(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        
                    }

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Email or password incorrect.");
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _users.LogoutAsync();
            return RedirectToAction("Login", "Account");
        }
 
    }
}
