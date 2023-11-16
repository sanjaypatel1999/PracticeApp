using ApplicationName.Data;
using ApplicationName.Models.Account;
using ApplicationName.Models.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApplicationName.Controllers.Account
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext context;

        public AccountController(ApplicationDbContext context)
        {

            this.context = context;


        }

        public IActionResult Index() => View();
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(SignUpUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var data = new User()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Mobile = model.Mobile,
                    Password = model.Password,
                    IsActive = model.IsActive
                    
                };
                context.Users.Add(data);
                context.SaveChanges();
                TempData["SuccessMessage"] = "You are eligibile for login";
                return RedirectToAction("Login");
            }
            else
            {
                TempData["errorMessage"] = "Empty from can't be submitted!";
                return View(model);
            }
        }
        public IActionResult Login()

        {
            return View();
        }
        [HttpPost]
        public  IActionResult Login(LoginSignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                 var data = context.Users.Where(e => e.UserName == model.UserName).SingleOrDefault();
                if (data != null)
                {
                    bool isValid = data.UserName == model.UserName && data.Password == model.Password;
                    if (isValid)
                    {
                        var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, model.UserName) },
                            CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        HttpContext.Session.SetString("UserName", model.UserName);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["errorPassword"] = "Invalid password";
                        return View(model);
                    }
                }
                else
                {
                    TempData["errorUserName"] = "User not found";
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }
        public IActionResult LogOut()
        {

            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            var storeCookies = Request.Cookies.Keys;
            foreach (var cookies in storeCookies)
            {
                Response.Cookies.Delete(cookies);
            }
            return RedirectToAction("Login", "Account");
        }
    }
}
