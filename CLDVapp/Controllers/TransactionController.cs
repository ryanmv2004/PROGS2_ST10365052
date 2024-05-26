using CLDVapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CLDVapp.Controllers
{
    public class TransactionController : Controller
    {
        transactionTable tbl = new transactionTable();

        [HttpPost]
        public ActionResult AddTransaction(transactionTable transaction)
        {
            int? userID = HttpContext.Session.GetInt32("userID");
            if (userID == null)
            {
                TempData["AlertMessage"] = "Please Login to purchase a product";
                return RedirectToAction("Login", "User");
            }
            var result2 = tbl.orderProduct(transaction);
            return RedirectToAction("MyWork", "Product");
        }
    }
}
