using CLDVapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CLDVapp.Controllers
{
    public class TransactionController : Controller
    {
        transactionTable tbl = new transactionTable();

        [HttpPost]
        public ActionResult AddTransaction(int productID, string name, string description, string price)
        {
            int? userID = HttpContext.Session.GetInt32("userID");
            transactionTable transaction = new transactionTable
            {
                userID = (int)userID,
                productID = productID,
                name = name,
                description = description,
                price = price
            };

            if (userID == null)
            {
                TempData["AlertMessage"] = "Please Login to purchase a product";
                return RedirectToAction("Login", "User");
            }
            var result2 = tbl.orderProduct(transaction);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult transactionPage()
        {
            int? cookieuserID = HttpContext.Session.GetInt32("userID");
            if (cookieuserID != null)
            {
                int userID = (int)cookieuserID;
                List<transactionTable> model = tbl.getTransactions(userID);
                return View("~/Views/Home/transactionPage.cshtml", model);
            }
            else
            {
                TempData["AlertMessage"] = "Please Login to view your order";
                TempData.Keep("AlertMessage");
                return RedirectToAction("loginPage", "Home");
            }

        }
    }
}
