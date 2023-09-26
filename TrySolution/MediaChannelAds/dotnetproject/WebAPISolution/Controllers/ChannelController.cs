using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookStoreDBFirst.Models;

namespace BookStoreDBFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChannelController : ControllerBase
    {
        private readonly ChannelAdDbContext _context;

        public ChannelController(ChannelAdDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Channel>>> GetAllChannels()
        {
            var channels = await _context.Channels.ToListAsync();
            return Ok(channels);
        }
[HttpGet("ChannelNames")]
public async Task<ActionResult<IEnumerable<string>>> Get()
{
    // Project the ChannelTitle property using Select
    var ChannelNames = await _context.Channels
        .OrderBy(x => x.ChannelName)
        .Select(x => x.ChannelName)
        .ToListAsync();

    return ChannelNames;
}
        [HttpPost]
        public async Task<ActionResult> AddChannel(Channel channel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return detailed validation errors
            }
            await _context.Channels.AddAsync(channel);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChannel(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid Channel id");

            var channel = await _context.Channels.FindAsync(id);
              _context.Channels.Remove(channel);
                await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
