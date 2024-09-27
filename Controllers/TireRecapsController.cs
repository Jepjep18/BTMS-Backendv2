using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Models;
using api.DTO;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TireRecapsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TireRecapsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TireRecaps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TireRecap>>> GetTireRecap()
        {
          if (_context.TireRecap == null)
          {
              return NotFound();
          }
            return await _context.TireRecap.ToListAsync();
        }

        // GET: api/TireRecaps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TireRecap>> GetTireRecap(int id)
        {
          if (_context.TireRecap == null)
          {
              return NotFound();
          }
            var tireRecap = await _context.TireRecap.FindAsync(id);

            if (tireRecap == null)
            {
                return NotFound();
            }

            return tireRecap;
        }

        // PUT: api/TireRecaps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTireRecap(int id, TireRecap tireRecap)
        {
            if (id != tireRecap.Id)
            {
                return BadRequest();
            }

            _context.Entry(tireRecap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TireRecapExists(id))
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

        // POST: api/TireRecaps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostTireRecap(TireRecap tireRecap)
        {
            // Check if the TireReturnId exists in the TireReturn table
            var tireReturnExists = await _context.TireReturn.AnyAsync(tr => tr.Id == tireRecap.TireReturnId);

            if (!tireReturnExists)
            {
                return NotFound($"TireReturn with Id {tireRecap.TireReturnId} does not exist.");
            }

            _context.TireRecap.Add(tireRecap);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetTireRecap", new { id = tireRecap.Id }, tireRecap);
        }



        // DELETE: api/TireRecaps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTireRecap(int id)
        {
            if (_context.TireRecap == null)
            {
                return NotFound();
            }
            var tireRecap = await _context.TireRecap.FindAsync(id);
            if (tireRecap == null)
            {
                return NotFound();
            }

            _context.TireRecap.Remove(tireRecap);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TireRecapExists(int id)
        {
            return (_context.TireRecap?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // GET: api/TireRecaps/details
        [HttpGet("details")]
        public async Task<ActionResult<IEnumerable<TireRecapDetailDto>>> GetTireRecapDetails()
        {
            var results = await (from tr in _context.TireRecap
                                 join tt in _context.TireReturn on tr.TireReturnId equals tt.Id
                                 join trc in _context.TireReceiving on tt.TireId equals trc.Id
                                 select new TireRecapDetailDto
                                 {
                                     TireRecapId = tr.Id,
                                     RecappedDate = tr.RecappedDate, // Nullable DateTime
                                     TireRecapEndorsedBy = tr.EndorsedBy,
                                     Purpose = tt.Purpose,
                                     DateReceived = trc.DateReceived, // Nullable DateTime
                                     Receivedby = trc.Receivedby,
                                     Supplier = trc.Supplier,
                                     ItemCode = trc.ItemCode,
                                     Quantity = trc.Quantity, // Nullable int
                                     Unitofmeasurement = trc.Unitofmeasurement,
                                     Tiresize = trc.Tiresize,
                                     Tirebrand = trc.Tirebrand,
                                     TireSerial = trc.TireSerial,
                                     DebossedNo = trc.DebossedNo,
                                     Status = trc.Status,
                                     TireType = trc.TireType,
                                     ItemCategory = trc.ItemCategory
                                 }).ToListAsync();


            if (results == null || !results.Any())
            {
                return NotFound();
            }

            return Ok(results);
        }

    }
}
