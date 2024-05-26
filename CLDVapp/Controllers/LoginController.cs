using CLDVapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CLDVapp.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginFeature login;

        public LoginController()
        {
            login = new LoginFeature();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var login = new LoginFeature();
            int userID = login.FetchUser(email, password);
            if (userID != -1)
            {
                HttpContext.Session.SetInt32("userID", userID); //Code for the cookie was learned from this website https://learn.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-8.0
                return RedirectToAction("Index", "Home", new { userID = userID });

            }
            else
            {
                return View("~/Views/Home/loginPage.cshtml");

            }
        }
    }
}
