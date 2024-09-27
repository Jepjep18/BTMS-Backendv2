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
    public class BatteryReleasingsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BatteryReleasingsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/BatteryReleasings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BatteryReleasing>>> GetBatteryReleasing()
        {
            if (_context.BatteryReleasing == null)
            {
                return NotFound();
            }
            return await _context.BatteryReleasing.ToListAsync();
        }

        // GET: api/BatteryReleasings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BatteryReleasing>> GetBatteryReleasing(int id)
        {
            if (_context.BatteryReleasing == null)
            {
                return NotFound();
            }
            var batteryReleasing = await _context.BatteryReleasing.FindAsync(id);

            if (batteryReleasing == null)
            {
                return NotFound();
            }

            return batteryReleasing;
        }

         // GET: api/BatteryReleasings/battery/{batteryId}
        [HttpGet("battery/{batteryId}")]
        public async Task<ActionResult<IEnumerable<BatteryReleasing>>> GetBatteryReleasingsByBatteryId(int batteryId)
        {
            if (_context.BatteryReleasing == null)
            {
                return NotFound();
            }

            var batteryReleasings = await _context.BatteryReleasing
                .Where(br => br.BatteryId == batteryId)
                .ToListAsync();

            if (batteryReleasings == null || !batteryReleasings.Any())
            {
                return NotFound();
            }

            return batteryReleasings;
        }

        // PUT: api/BatteryReleasings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Admin, FAIPadmin, FAIPwarehouse")] // Restrict access to specified roles
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBatteryReleasing(int id, BatteryReleasing batteryReleasing)
        {
            if (id != batteryReleasing.Id)
            {
                return BadRequest();
            }

            _context.Entry(batteryReleasing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BatteryReleasingExists(id))
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

        // POST: api/BatteryReleasings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Admin, FAIPadmin, FAIPwarehouse")] // Restrict access to specified roles
        [HttpPost]
        public async Task<ActionResult<BatteryReleasing>> PostBatteryReleasing(BatteryReleasing batteryReleasing)
        {
            if (_context.BatteryReleasing == null)
            {
                return Problem("Entity set 'AppDbContext.BatteryReleasing' is null.");
            }
            batteryReleasing.ReleaseDate = DateTime.Now;
            _context.BatteryReleasing.Add(batteryReleasing);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBatteryReleasing", new { id = batteryReleasing.Id }, batteryReleasing);
        }

        // DELETE: api/BatteryReleasings/5
        [Authorize(Roles = "Admin, FAIPadmin, FAIPwarehouse")] // Restrict access to specified roles
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBatteryReleasing(int id)
        {
            if (_context.BatteryReleasing == null)
            {
                return NotFound();
            }
            var batteryReleasing = await _context.BatteryReleasing.FindAsync(id);
            if (batteryReleasing == null)
            {
                return NotFound();
            }

            _context.BatteryReleasing.Remove(batteryReleasing);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BatteryReleasingExists(int id)
        {
            return (_context.BatteryReleasing?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpGet("released-items")]
        public IActionResult GetReleasedItems()
        {
            // Check if the context is null
            if (_context.BatteryReleasing == null || _context.BatteryReceiving == null)
            {
                return NotFound();
            }

            // Join BatteryReleasing and BatteryReceiving to get the required data
            var releasedItems = (from br in _context.BatteryReleasing
                                 join brec in _context.BatteryReceiving
                                 on br.BatteryId equals brec.Id
                                 select new
                                 {
                                     ItemDescription = brec.ItemDescription,
                                     ItemCategory = brec.ItemCategory,
                                     DrSiCiNo = brec.DrsiNo,
                                     PoNo = brec.PoNo,
                                     SerialNo = brec.Batteryserial,
                                     DebossedNo = brec.DebossedNo,
                                     DateReleased = br.ReleaseDate,
                                     ReleasedBy = br.Receivedby
                                 }).ToList();

            return Ok(releasedItems);
        }

        [HttpPost("release-multiple")]
        public async Task<IActionResult> ReleaseMultipleItems([FromBody] ReleaseMultipleItemsDto releaseData)
        {
            // Check if the context is null
            if (_context.BatteryReleasing == null || _context.BatteryReceiving == null)
            {
                return NotFound("Battery releasing or receiving data is not found.");
            }

            // Find all the BatteryReceiving records with the given batteryIds
            var batteriesToRelease = await _context.BatteryReceiving
                .Where(battery => releaseData.BatteryIds.Contains(battery.Id) && battery.Status == "AVAILABLE")
                .ToListAsync();

            if (batteriesToRelease == null || batteriesToRelease.Count == 0)
            {
                return NotFound("No available batteries found for the provided IDs.");
            }

            // Release each battery by creating a BatteryReleasing record
            foreach (var battery in batteriesToRelease)
            {
                var batteryReleasing = new BatteryReleasing
                {
                    BatteryId = battery.Id,
                    BusinessUnit = releaseData.BusinessUnit,
                    Imjno = releaseData.Imjno,
                    ReleaseDate = releaseData.ReleaseDate,
                    Receivedby = releaseData.Receivedby,
                    UserplateNo = releaseData.UserPlateNo,
                    Remarks = releaseData.Remarks,
                };

                _context.BatteryReleasing.Add(batteryReleasing);

                // Update battery status to "RELEASED"
                battery.Status = "RELEASED";
                _context.Entry(battery).State = EntityState.Modified;
            }

            // Save changes to the database
            await _context.SaveChangesAsync();

            return Ok(new { message = "Selected batteries released successfully." });
        }

    }
}
