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
                                     on tr.TireId equals rc.Id into details
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
            return Ok(tireReturn.TireId);
        }

        [HttpGet("returned-items-details")]
        public async Task<IActionResult> GetTireReturnDetails()
        {
            var tireReturnDetails = await (from tr in _context.TireReturn
                                           join trel in _context.TireReleasing on tr.TireId equals trel.TireId
                                           join trec in _context.TireReceiving on trel.TireId equals trec.Id
                                           select new
                                           {
                                               TireReturnId = tr.Id,
                                               ReturnDate = tr.ReceivedDate,
                                               ReturnEndorsedBy = tr.EndorsedBy,
                                               Purpose = tr.Purpose,
                                               TireReleasingId = trel.Id,
                                               BusinessUnit = trel.Company,
                                               trel.Imjno,
                                               trel.Driver,
                                               trel.PlateNo,
                                               trel.Abfiserialno,
                                               trel.Remarks,
                                               trel.ReleaseDate,
                                               TireReleasingReceivedBy = trel.Receivedby, // Rename this property
                                               ReceivingId = trec.Id,
                                               trec.DateReceived,
                                               trec.DebossedNo,
                                               trec.DrciNo,
                                               trec.ItemCategory,
                                               trec.ItemCode,
                                               trec.PoNo,
                                               TireReceivingReceivedBy = trec.Receivedby, // Rename this property
                                               trec.TireSerial,
                                               trec.Tiresize,
                                               trec.TireType
                                           }).ToListAsync();

            return Ok(tireReturnDetails);
        }



    }
}
