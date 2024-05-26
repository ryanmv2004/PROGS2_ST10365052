using CLDVapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CLDVapp.Controllers
{
    public class SignUpController : Controller
    {

        public userTable tbl = new userTable();
        [HttpPost]
        public ActionResult SignUp(userTable Users)
        {
            var result = tbl.insert_User(Users);
            return RedirectToAction("Index", "Home");
        }

    }
}
