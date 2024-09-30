using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Models;
using Microsoft.AspNetCore.Cors;
using System.Data;
using api.DTO;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient; // Ensure you include this namespace

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
                                        on br.BatteryReleasingId equals rc.Id into details
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

        [HttpGet("api/battery-return/by-battery/{batteryId}")]
        public IActionResult GetReturnByBatteryId(int batteryId)
        {
            var batteryReturn = _context.BatteryReturn
                                 .Where(br => br.BatteryReleasingId == batteryId)
                                 .FirstOrDefault();

            if (batteryReturn == null)
            {
                return NotFound();
            }

            return Ok(batteryReturn);
        }


        [HttpGet("return-details/{id}")]
        public async Task<ActionResult<BatteryReturnResponseDto>> GetBatteryReturnDetails(int id)
        {
            var result = await (from br in _context.BatteryReturn
                                where br.Id == id // Filter by id
                                join brel in _context.BatteryReleasing on br.BatteryReleasingId equals brel.Id into brelGroup
                                from brel in brelGroup.DefaultIfEmpty() // Left join
                                join brec in _context.BatteryReceiving on brel.BatteryId equals brec.Id into brecGroup
                                from brec in brecGroup.DefaultIfEmpty() // Left join
                                select new BatteryReturnResponseDto
                                {
                                    BatteryReturnId = br.Id,
                                    ReturnDate = br.ReceivedDate,
                                    ReturnEndorsedBy = br.Endorsedby,
                                    BatteryReturnBatteryId = br.BatteryReleasingId,
                                    BusinessUnit = brel != null ? brel.BusinessUnit : string.Empty, // Handle null
                                    Imjno = brel != null ? brel.Imjno : string.Empty, // Handle null
                                    ReleaseDate = brel != null ? (DateTime?)brel.ReleaseDate : null, // Handle nullable DateTime
                                    ReleasedReceivedBy = brel != null ? brel.Receivedby : string.Empty, // Handle null
                                    UserplateNo = brel != null ? brel.UserplateNo : string.Empty, // Handle null
                                    Remarks = brel != null ? brel.Remarks : string.Empty, // Handle null
                                    ReceivingId = brec != null ? brec.Id : 0, // Handle null; change based on your logic
                                    ReceivedDate = brec != null ? (DateTime?)brec.DateReceived : null, // Handle nullable DateTime
                                    ReceivedReceivedBy = brec != null ? brec.Receivedby : string.Empty, // Handle null
                                    DrsiNo = brec != null && brec.DrsiNo.HasValue ? brec.DrsiNo.Value.ToString() : string.Empty,
                                    PoNo = brec != null && brec.PoNo.HasValue ? brec.PoNo.Value.ToString() : string.Empty,
                                    ItemCode = brec != null ? brec.ItemCode : string.Empty, // Handle null
                                    Supplier = brec != null ? brec.Supplier : string.Empty, // Handle null
                                    ItemDescription = brec != null ? brec.ItemDescription : string.Empty, // Handle null
                                    Batteryserial = brec != null ? brec.Batteryserial : string.Empty, // Handle null
                                    DebossedNo = brec != null ? brec.DebossedNo : string.Empty, // Handle null
                                }).FirstOrDefaultAsync(); // Fetch the item or null if not found

            if (result == null)
            {
                return NotFound(); // Return 404 if no item found
            }

            return Ok(result); // Return the found item
        }









    }
}
