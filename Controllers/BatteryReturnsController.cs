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
using System.Data;
using api.DTO;
using Dapper;
using Microsoft.AspNetCore.Authorization; // Ensure you include this namespace

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class BatteryReturnsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BatteryReturnsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/BatteryReturns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BatteryReturn>>> GetBatteryReturn()
        {
            if (_context.BatteryReturn == null)
            {
                return NotFound();
            }
            return await _context.BatteryReturn.ToListAsync();
        }

        // GET: api/BatteryReturns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BatteryReturn>> GetBatteryReturn(int id)
        {
            if (_context.BatteryReturn == null)
            {
                return NotFound();
            }
            var batteryReturn = await _context.BatteryReturn.FindAsync(id);

            if (batteryReturn == null)
            {
                return NotFound();
            }

            return batteryReturn;
        }

        // PUT: api/BatteryReturns/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Admin, FAIPadmin, FAIPwarehouse")] // Restrict access to specified roles

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBatteryReturn(int id, BatteryReturn batteryReturn)
        {
            if (id != batteryReturn.Id)
            {
                return BadRequest();
            }

            _context.Entry(batteryReturn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BatteryReturnExists(id))
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

        // POST: api/BatteryReturns
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Admin, FAIPadmin, FAIPwarehouse")] // Restrict access to specified roles

        [HttpPost]
        public async Task<ActionResult<BatteryReturn>> PostBatteryReturn(BatteryReturn batteryReturn)
        {
            if (_context.BatteryReturn == null)
            {
                return Problem("Entity set 'AppDbContext.BatteryReturn' is null.");
            }
            batteryReturn.ReceivedDate = DateTime.Now;
            _context.BatteryReturn.Add(batteryReturn);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBatteryReturn", new { id = batteryReturn.Id }, batteryReturn);
        }

        // DELETE: api/BatteryReturns/5
        [Authorize(Roles = "Admin, FAIPadmin, FAIPwarehouse")] // Restrict access to specified roles

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBatteryReturn(int id)
        {
            if (_context.BatteryReturn == null)
            {
                return NotFound();
            }
            var batteryReturn = await _context.BatteryReturn.FindAsync(id);
            if (batteryReturn == null)
            {
                return NotFound();
            }

            _context.BatteryReturn.Remove(batteryReturn);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BatteryReturnExists(int id)
        {
            return (_context.BatteryReturn?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpGet("return-items")]
        public IActionResult GetBatteryReturnWithDetails()
        {
            var batteryReturnDetails = (from br in _context.BatteryReturn
                                        join rc in _context.BatteryReceiving
                                        on br.BatteryId equals rc.Id into details
                                        from detail in details.DefaultIfEmpty()
                                        select new
                                        {
                                            DateReturned = br.ReceivedDate,
                                            EndorsedBy = br.Endorsedby,
                                            ItemDescription = detail != null ? detail.ItemDescription : null,
                                            ItemCategory = detail != null ? detail.ItemCategory : null,
                                            DrsiNo = detail != null ? detail.DrsiNo : (int?)null,
                                            PoNo = detail != null ? detail.PoNo : (int?)null,
                                            SerialNo = detail != null ? detail.Batteryserial : null,
                                            DebossedNo = detail != null ? detail.DebossedNo : null
                                        }).ToList();

            if (batteryReturnDetails == null || !batteryReturnDetails.Any())
            {
                return NotFound();
            }

            return Ok(batteryReturnDetails);
        }

        [HttpGet("return-items-details")]
        public async Task<IActionResult> GetBatteryReturnWithDetail()
        {
            if (_context == null)
            {
                return NotFound();
            }

            var query = @"
        SELECT 
            BR.ReceivedDate AS DispossalDate,
            BR.Endorsedby AS EndorsedBy,
            BRR.ItemCategory
        FROM 
            BatteryReturn BR
        JOIN 
            BatteryReceiving BRR
        ON 
            BR.BatteryId = BRR.Id
        WHERE
            BR.BatteryId = BRR.Id
    ";

            using (IDbConnection dbConnection = _context.Database.GetDbConnection())
            {
                // Ensure the connection is open
                if (dbConnection.State == ConnectionState.Closed)
                    dbConnection.Open();

                var result = await dbConnection.QueryAsync<BatteryReturnDetailDto>(query);

                return Ok(result);
            }
        }
    }
}
