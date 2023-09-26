using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookStoreDBFirst.Models;

namespace BookStoreDBFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdController : ControllerBase
    {
        private readonly ChannelAdDbContext _context;

        public AdController(ChannelAdDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ad>>> GetAllAds()
        {
            var ads = await _context.Ads.ToListAsync();
            return Ok(ads);
        }

        [HttpPost]
        public async Task<ActionResult> AddAd(Ad ad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return detailed validation errors
            }
            await _context.Ads.AddAsync(ad);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAd(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid Ad id");

            var ad = await _context.Ads.FindAsync(id);
              _context.Ads.Remove(ad);
                await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
