using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RNR_WebAPI.Data;
using RNR_WebAPI.Model;

namespace RNR_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreakdownsController : ControllerBase
    {
        private readonly BreakdownContext _context;

        public BreakdownsController(BreakdownContext context)
        {
            _context = context;
        }

        // GET: api/Breakdowns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Breakdown>>> GetBreakdowns()
        {
            return await _context.Breakdowns.ToListAsync();
        }

        // POST: api/Breakdowns
        [HttpPost]
        public async Task<ActionResult<Breakdown>> PostBreakdown(Breakdown breakdown)
        {
            if (breakdown == null)
            {
                return BadRequest("Breakdown data is null");
            }

            _context.Breakdowns.Add(breakdown);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBreakdown", new { id = breakdown.BreakdownReference }, breakdown);
        }

        // PUT: api/Breakdowns/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBreakdown(string id, Breakdown breakdown)
        {
            if (id != breakdown.BreakdownReference)
            {
                return BadRequest();
            }

            _context.Entry(breakdown).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Breakdowns.Any(e => e.BreakdownReference == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
    }
}
