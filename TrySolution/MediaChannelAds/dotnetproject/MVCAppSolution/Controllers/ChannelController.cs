using Microsoft.AspNetCore.Mvc;
using BookStoreApp.Models;
using BookStoreApp.Services;
using System;
using System.Threading.Tasks;

namespace BookStoreApp.Controllers
{
    public class ChannelController : Controller
    {
        private readonly IChannelService _ChannelService;

        public ChannelController(IChannelService ChannelService)
        {
            _ChannelService = ChannelService;

        }

        public IActionResult AddChannel()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddChannel(Channel channel)
        {
            try
            {
                if (channel == null)
                {
                    return BadRequest("Invalid Channel data");
                }

                var success = _ChannelService.AddChannel(channel);

                if (success)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError(string.Empty, "Failed to add the Channel. Please try again.");
                return View(channel);
            }
            catch (Exception ex)
            {
                // Log or print the exception to get more details
                Console.WriteLine("Exception: " + ex.Message);

                // Return an error response or another appropriate response
                ModelState.AddModelError(string.Empty, "An error occurred while processing your request. Please try again.");
                return View(channel);
            }
        }

        public IActionResult Index()
        {
            try
            {
                var listChannels = _ChannelService.GetAllChannels();
                return View("Index",listChannels);
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
                var success = _ChannelService.DeleteChannel(id);

                if (success)
                {
                    // Check if the deletion was successful and return a view or a redirect
                    return RedirectToAction("Index"); // Redirect to the list of Channels, for example
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
