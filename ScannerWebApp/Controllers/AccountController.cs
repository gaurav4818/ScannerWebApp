using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using ScannerWebApp.Models;
using System.Security.Claims;

namespace ScannerWebApp.Controllers
{
    public class AccountController : Controller
    {
        public AccountController() { }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public List<UserCredentials> Users()
        {
            var users = new List<UserCredentials>()
            {
                new UserCredentials{Username = "Gaurav", Password = "Gaurav@123" },
                new UserCredentials{Username = "TradeWithV", Password = "TradeWithV@1" },
            };
            return users;
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserCredentials model)
        {
            if (ModelState.IsValid)
            {
                var username = model.Username;
                var password = model.Password;

                if (Verify(model))
                {
                    // Authentication successful, sign in the user
                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                // Add any additional claims as needed
            };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    var authenticationProperties = new AuthenticationProperties
                    {
                        IsPersistent = model.RememberMe, // Determine if the user should stay authenticated
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties);

                    return RedirectToAction("Index", "Home"); // Redirect to the home page or a protected resource
                }

                ViewBag.message = "Invalid Username or Password";
            }

            // If authentication fails, display the login view with an error message
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Redirect to the home page or any other desired page after logout
            return RedirectToAction("Login", "Account");
        }

        public bool Verify(UserCredentials userCredentials) 
        {
            var users = Users();
            var user = users.FirstOrDefault(x => x.Username == userCredentials.Username && x.Password == userCredentials.Password);
            if(user != null)
            {
                return true;
            }
            return false;
        }
    }
}
