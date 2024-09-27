using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Models;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TireDisposalsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TireDisposalsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TireDisposals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TireDisposal>>> GetTireDisposal()
        {
          if (_context.TireDisposal == null)
          {
              return NotFound();
          }
            return await _context.TireDisposal.ToListAsync();
        }

        // GET: api/TireDisposals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TireDisposal>> GetTireDisposal(int id)
        {
          if (_context.TireDisposal == null)
          {
              return NotFound();
          }
            var tireDisposal = await _context.TireDisposal.FindAsync(id);

            if (tireDisposal == null)
            {
                return NotFound();
            }

            return tireDisposal;
        }

        // PUT: api/TireDisposals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTireDisposal(int id, TireDisposal tireDisposal)
        {
            if (id != tireDisposal.Id)
            {
                return BadRequest();
            }

            _context.Entry(tireDisposal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TireDisposalExists(id))
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

        // POST: api/TireDisposals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TireDisposal>> PostTireDisposal(TireDisposal tireDisposal)
        {
          if (_context.TireDisposal == null)
          {
              return Problem("Entity set 'AppDbContext.TireDisposal'  is null.");
          }
            _context.TireDisposal.Add(tireDisposal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTireDisposal", new { id = tireDisposal.Id }, tireDisposal);
        }

        // DELETE: api/TireDisposals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTireDisposal(int id)
        {
            if (_context.TireDisposal == null)
            {
                return NotFound();
            }
            var tireDisposal = await _context.TireDisposal.FindAsync(id);
            if (tireDisposal == null)
            {
                return NotFound();
            }

            _context.TireDisposal.Remove(tireDisposal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TireDisposalExists(int id)
        {
            return (_context.TireDisposal?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
