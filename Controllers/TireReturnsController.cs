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
using Microsoft.AspNetCore.Authorization; // Ensure you include this namespace
using api.DTO;



namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class TireReturnsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TireReturnsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TireReturns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TireReturn>>> GetTireReturn()
        {
            if (_context.TireReturn == null)
            {
                return NotFound();
            }
            return await _context.TireReturn.ToListAsync();
        }

        // GET: api/TireReturns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TireReturn>> GetTireReturn(int id)
        {
            if (_context.TireReturn == null)
            {
                return NotFound();
            }
            var tireReturn = await _context.TireReturn.FindAsync(id);

            if (tireReturn == null)
            {
                return NotFound();
            }

            return tireReturn;
        }

        // PUT: api/TireReturns/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Admin, FAIPadmin, FAIPwarehouse")] // Restrict access to specified roles
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTireReturn(int id, TireReturn tireReturn)
        {
            if (id != tireReturn.Id)
            {
                return BadRequest();
            }

            _context.Entry(tireReturn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TireReturnExists(id))
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

        // POST: api/TireReturns
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Admin, FAIPadmin, FAIPwarehouse")] // Restrict access to specified roles
        [HttpPost]
        public async Task<ActionResult<TireReturn>> PostTireReturn(TireReturn tireReturn)
        {
            if (_context.TireReturn == null)
            {
                return Problem("Entity set 'AppDbContext.TireReturn' is null.");
            }
            tireReturn.ReceivedDate = DateTime.Now;
            _context.TireReturn.Add(tireReturn);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTireReturn", new { id = tireReturn.Id }, tireReturn);
        }

        // DELETE: api/TireReturns/5
        [Authorize(Roles = "Admin, FAIPadmin, FAIPwarehouse")] // Restrict access to specified roles
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTireReturn(int id)
        {
            if (_context.TireReturn == null)
            {
                return NotFound();
            }
            var tireReturn = await _context.TireReturn.FindAsync(id);
            if (tireReturn == null)
            {
                return NotFound();
            }

            _context.TireReturn.Remove(tireReturn);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TireReturnExists(int id)
        {
            return (_context.TireReturn?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpGet("returned-items")]
        public IActionResult GetTireReturnWithDetails()
        {
            var tireReturnDetails = (from tr in _context.TireReturn
                                     join rc in _context.TireReceiving
                                     on tr.TireReleasingId equals rc.Id into details
                                     from detail in details.DefaultIfEmpty()
                                     select new
                                     {
                                         DateReturned = tr.ReceivedDate,
                                         EndorsedBy = tr.EndorsedBy,
                                         Purpose = tr.Purpose,
                                         ReceivedBy = tr.EndorsedBy,
                                         ItemDescription = detail != null ? detail.ItemCode : null,
                                         ItemCategory = detail != null ? detail.ItemCategory : null,
                                         DrciNo = detail != null ? detail.DrciNo : (int?)null,
                                         PoNo = detail != null ? detail.PoNo : (int?)null,
                                         SerialNo = detail != null ? detail.TireSerial : null,
                                         DebossedNo = detail != null ? detail.DebossedNo : null
                                     }).ToList();

            return Ok(tireReturnDetails);
        }

        [HttpGet("{tireReturnId}/tire-id")]
        public IActionResult GetTireIdFromReturn(int tireReturnId)
        {
            var tireReturn = _context.TireReturn.FirstOrDefault(tr => tr.Id == tireReturnId);
            if (tireReturn == null)
            {
                return NotFound();
            }
            return Ok(tireReturn.TireReleasingId);
        }

        [HttpGet("returned-items-details/{id}")]
        public async Task<IActionResult> GetTireReturnDetails(int id)
        {
            var tireReturnDetails = await (from tr in _context.TireReturn
                                           join tr2 in _context.TireReleasing on tr.TireReleasingId equals tr2.Id into tr2Join
                                           from tr2 in tr2Join.DefaultIfEmpty() // Left join
                                           join tr3 in _context.TireReceiving on tr2.TireId equals tr3.Id into tr3Join
                                           from tr3 in tr3Join.DefaultIfEmpty() // Left join
                                           where tr.Id == id // Filter by ID
                                           select new TireReturnDetailDto
                                           {
                                               TireReturnId = tr.Id,
                                               ReceivedDate = tr.ReceivedDate ?? DateTime.MinValue, // Handle nullable DateTime
                                               EndorsedBy = tr.EndorsedBy,
                                               Purpose = tr.Purpose,
                                               TireReleasingId = tr.TireReleasingId,
                                               Company = tr2.Company,
                                               Imjno = tr2.Imjno,
                                               Driver = tr2.Driver,
                                               PlateNo = tr2.PlateNo,
                                               Abfiserialno = tr2.Abfiserialno,
                                               Remarks = tr2.Remarks,
                                               ReleaseDate = tr2.ReleaseDate ?? DateTime.MinValue, // Handle nullable DateTime
                                               Receivedby = tr2.Receivedby,
                                               TireId = tr2.TireId,
                                               TireReceivingId = tr3.Id, // Ensure correct mapping
                                               DateReceived = tr3.DateReceived ?? DateTime.MinValue, // Handle nullable DateTime
                                               TireReceivedBy = tr3.Receivedby,
                                               Supplier = tr3.Supplier,
                                               ItemCode = tr3.ItemCode,
                                               Quantity = tr3.Quantity,
                                               Unitofmeasurement = tr3.Unitofmeasurement,
                                               Tiresize = tr3.Tiresize,
                                               Tirebrand = tr3.Tirebrand,
                                               TireSerial = tr3.TireSerial,
                                               DebossedNo = tr3.DebossedNo,
                                               TireReceivingRemarks = tr3.Remarks,
                                               TireReceivingStatus = tr3.Status,
                                               TireType = tr3.TireType,
                                               ItemCategory = tr3.ItemCategory
                                           }).ToListAsync();

            if (tireReturnDetails == null || !tireReturnDetails.Any())
            {
                return NotFound(); // Return 404 if no details found for the specified ID
            }

            return Ok(tireReturnDetails);
        }










    }
}
