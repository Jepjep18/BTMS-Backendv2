using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using api.DTO; // Ensure you include this namespace

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class TireReleasingsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TireReleasingsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TireReleasings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TireReleasing>>> GetTireReleasing()
        {
            if (_context.TireReleasing == null)
            {
                return NotFound();
            }
            return await _context.TireReleasing.ToListAsync();
        }

        // GET: api/TireReleasings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TireReleasing>> GetTireReleasing(int id)
        {
            if (_context.TireReleasing == null)
            {
                return NotFound();
            }
            var tireReleasing = await _context.TireReleasing.FindAsync(id);

            if (tireReleasing == null)
            {
                return NotFound();
            }

            return tireReleasing;
        }

        // PUT: api/TireReleasings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Admin, FAIPadmin, FAIPwarehouse")] // Restrict access to specified roles
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTireReleasing(int id, TireReleasing tireReleasing)
        {
            if (id != tireReleasing.Id)
            {
                return BadRequest();
            }

            _context.Entry(tireReleasing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TireReleasingExists(id))
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

        // POST: api/TireReleasings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Admin, FAIPadmin, FAIPwarehouse")] // Restrict access to specified roles
        [HttpPost]
        public async Task<ActionResult<TireReleasing>> PostTireReleasing(TireReleasing tireReleasing)
        {
            if (_context.TireReleasing == null)
            {
                return Problem("Entity set 'AppDbContext.TireReleasing' is null.");
            }
            tireReleasing.ReleaseDate = DateTime.Now;
            _context.TireReleasing.Add(tireReleasing);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTireReleasing", new { id = tireReleasing.Id }, tireReleasing);
        }

        // DELETE: api/TireReleasings/5
        [Authorize(Roles = "Admin, FAIPadmin, FAIPwarehouse")] // Restrict access to specified roles
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTireReleasing(int id)
        {
            if (_context.TireReleasing == null)
            {
                return NotFound();
            }
            var tireReleasing = await _context.TireReleasing.FindAsync(id);
            if (tireReleasing == null)
            {
                return NotFound();
            }

            _context.TireReleasing.Remove(tireReleasing);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TireReleasingExists(int id)
        {
            return (_context.TireReleasing?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpGet("released-items")]
        public IActionResult GetReleasedItems()
        {
            var releasedItems = (from tr in _context.TireReleasing
                                 join trec in _context.TireReceiving
                                 on tr.TireId equals trec.Id
                                 select new
                                 {
                                     trec.ItemCode,
                                     trec.ItemCategory,
                                     trec.DrciNo,
                                     trec.PoNo,
                                     trec.TireSerial,
                                     trec.DebossedNo,
                                     DateReleased = tr.ReleaseDate,
                                     ReleasedBy = tr.Receivedby
                                 }).ToList();

            return Ok(releasedItems);
        }

        [HttpPost("release-multiple")]
        public async Task<IActionResult> ReleaseMultipleItems([FromBody] ReleaseMultipleTireItemsDto releaseData)
        {
            if (_context.TireReleasing == null || _context.TireReceiving == null)
            {
                return NotFound("Tire releasing or receiving data is not found.");
            }

            // Fetch the tires to be released
            var tiresToRelease = await _context.TireReceiving
                .Where(tire => releaseData.TireIds.Contains(tire.Id))
                .ToListAsync();

            if (tiresToRelease == null || !tiresToRelease.Any())
            {
                return NotFound("No tires found for the provided IDs.");
            }

            // Create new TireReleasing records for each tire
            foreach (var tire in tiresToRelease)
            {
                var tireReleasing = new TireReleasing
                {
                    TireId = tire.Id,
                    Company = releaseData.Company,
                    Imjno = releaseData.Imjno,
                    Driver = releaseData.Driver,
                    PlateNo = releaseData.PlateNo,
                    Abfiserialno = releaseData.Abfiserialno,
                    Remarks = releaseData.Remarks,
                    ReleaseDate = releaseData.ReleaseDate ?? DateTime.Now,
                    Receivedby = releaseData.Receivedby
                };

                _context.TireReleasing.Add(tireReleasing);

                // Update tire status in TireReceiving
                tire.Status = "RELEASED";
                _context.TireReceiving.Update(tire);
            }

            // Save changes to the database
            await _context.SaveChangesAsync();

            return Ok("Tires successfully released.");
        }

    }
}
