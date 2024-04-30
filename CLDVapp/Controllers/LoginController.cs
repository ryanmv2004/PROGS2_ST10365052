using CLDVapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CLDVapp.Controllers
{
    public class LoginController : Controller
    {

        public Table_1 tbl = new Table_1();


        [HttpPost]
        public ActionResult SignUp(Table_1 Users)
        {
            var result = tbl.insert_User(Users);
            return RedirectToAction("Index", "Home");
        }

    }
}
