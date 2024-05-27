using CLDVapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CLDVapp.Controllers
{
    public class ProductController : Controller
    {
        public productTable prodTbl = new productTable();

        [HttpPost]
        public ActionResult addProduct(productTable product)
        {
            var result = prodTbl.insert_Product(product);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Work()
        {
            List<productTable> model = prodTbl.GetAllProducts();
            return View("~/Views/Home/Work.cshtml", model);
            
        }

        public IActionResult addWork()
        {
            int? cookieuserID = HttpContext.Session.GetInt32("userID");
            if (cookieuserID != null)
            {
                return View("~/Views/Home/addWork.cshtml");
            }
            else
            {
                TempData["AlertMessage"] = "Please Login to Create a Product";
                TempData.Keep("AlertMessage");
                return RedirectToAction("loginPage", "Home");
            }
        }
    }
}
