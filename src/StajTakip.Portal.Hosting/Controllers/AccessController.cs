using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using StajTakip.Portal.Hosting.Models;

namespace StajTakip.Portal.Hosting.Controllers
{

    public class AccessController : Controller
    {
        public AccessController()
        {
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Access");
        }

        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = User;

            if (claimUser.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel modelLogin)
        {
            await Task.CompletedTask;

            if (!string.IsNullOrEmpty(modelLogin.Email) && 
                !string.IsNullOrEmpty(modelLogin.Password) &&
                "user@gmail.com".Equals(modelLogin.Email, StringComparison.InvariantCultureIgnoreCase) && 
                "123".Equals(modelLogin.Password))
            {
                List<Claim> claims = new List<Claim>(){
                new Claim(ClaimTypes.NameIdentifier, modelLogin.Email),
                // new Claim(ClaimTypes.Authentication, Boolean.TrueString),
                new Claim(ClaimTypes.Role, "Administrator"),
                new Claim("OtherProperties","Example Role")};

                var authenticationScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                
                var claimsIdentity = new ClaimsIdentity(claims, authenticationScheme);
                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    //AllowRefresh = true,
                    //IsPersistent = Boolean.TrueString.Equals(modelLogin.KeepLoggedIn, StringComparison.InvariantCultureIgnoreCase)
                };

                await HttpContext.SignInAsync(authenticationScheme, new ClaimsPrincipal(claimsIdentity), properties);
                return LocalRedirect("/");
            }
            else
            {
                ViewData["ValidateMessage"] = "Kullanıcı Bulunamadı!";
                return View("Login");
                
            }
        }

}
}
