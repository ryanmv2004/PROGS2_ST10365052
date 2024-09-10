using Azure.Storage.Blobs;
using CLDVapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CLDVapp.Controllers
{
    public class ProductController : Controller
    {
        public productTable prodTbl = new productTable();

        [HttpPost]
        public async Task<IActionResult> addProduct(IFormFile image, string name, string price, string description, string availability, string category)
        {
            string imageUrl = null;

            if (image != null && image.Length > 0)
            {
                // Azure Blob Storage connection string
                string connectionString = "DefaultEndpointsProtocol=https;AccountName=st10365052demostorage;AccountKey=5fTakvNfnJG3Gm7ndmyFD1gno7X9MsKJbKiuSLZNYxdz6VPzTzH28MpyK/H8u/mZbRQ74C1OOAyO+AStQ/yUkg==;EndpointSuffix=core.windows.net";
                string containerName = "st10365052container";

                // Create a BlobServiceClient
                BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

                // Get a reference to the container
                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

                // Create the container if it does not exist
                await containerClient.CreateIfNotExistsAsync();

                // Get a reference to the blob
                string blobName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                BlobClient blobClient = containerClient.GetBlobClient(blobName);

                // Upload the file
                using (var stream = image.OpenReadStream())
                {
                    await blobClient.UploadAsync(stream, true);
                }

                // Get the URL of the uploaded image
                imageUrl = blobClient.Uri.ToString();
            }

            // Create a new productTable object
            var product = new productTable
            {
                name = name,
                price = price,
                description = description,
                availability = availability,
                category = category,
                url = imageUrl
            };

            // Insert the product into the database
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
