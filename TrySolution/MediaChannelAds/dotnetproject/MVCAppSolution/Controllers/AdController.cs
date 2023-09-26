using Microsoft.AspNetCore.Mvc;
using BookStoreApp.Models;
using BookStoreApp.Services;
using System;
using System.Threading.Tasks;

namespace BookStoreApp.Controllers
{
    public class AdController : Controller
    {
        private readonly IAdService _AdService;

        public AdController(IAdService AdService)
        {
            _AdService = AdService;

        }

        public IActionResult AddAd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAd(Ad ad)
        {
            try
            {
                if (ad == null)
                {
                    return BadRequest("Invalid Ad data");
                }

                var success = _AdService.AddAd(ad);

                if (success)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError(string.Empty, "Failed to add the Ad. Please try again.");
                return View(ad);
            }
            catch (Exception ex)
            {
                // Log or print the exception to get more details
                Console.WriteLine("Exception: " + ex.Message);
                Console.WriteLine("StackTrace: " + ex.StackTrace);
                // Return an error response or another appropriate response
                ModelState.AddModelError(string.Empty, "An error occurred while processing your request. Please try again.");
                return View(ad);
            }
        }

        public IActionResult Index()
        {
            try
            {
                var listAds = _AdService.GetAllAds();
                return View("Index", listAds);
            }
            catch (Exception ex)
            {
                // Log or print the exception to get more details
                Console.WriteLine("Exception: " + ex.Message);

                // Return an error view or another appropriate response
                return View("Error"); // Assuming you have an "Error" view
            }
        }
        public IActionResult Delete(int id)
        {
            try
            {
                var success = _AdService.DeleteAd(id);

                if (success)
                {
                    // Check if the deletion was successful and return a view or a redirect
                    return RedirectToAction("Index"); // Redirect to the list of Ads, for example
                }
                else
                {
                    // Handle other error cases
                    return View("Error"); // Assuming you have an "Error" view
                }
            }
            catch (Exception ex)
            {
                // Log or print the exception to get more details
                Console.WriteLine("Exception: " + ex.Message);

                // Return an error view or another appropriate response
                return View("Error"); // Assuming you have an "Error" view
            }
        }
    }
}
