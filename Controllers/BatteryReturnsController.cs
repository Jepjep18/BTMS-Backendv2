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

        [HttpGet("api/battery-return/by-battery/{batteryId}")]
        public IActionResult GetReturnByBatteryId(int batteryId)
        {
            var batteryReturn = _context.BatteryReturn
                                 .Where(br => br.BatteryId == batteryId)
                                 .FirstOrDefault();

            if (batteryReturn == null)
            {
                return NotFound();
            }

            return Ok(batteryReturn);
        }
        [HttpGet("return-details/{id}")]
        public async Task<ActionResult<BatteryReturnResponseDto>> GetBatteryReturnById(int id)
        {
            var result = await (from br in _context.BatteryReturn
                                join brel in _context.BatteryReleasing on br.BatteryId equals brel.Id
                                join brec in _context.BatteryReceiving on brel.BatteryId equals brec.Id
                                where br.Id == id // Fetch by ID
                                select new BatteryReturnResponseDto
                                {
                                    BatteryReturnId = br.Id,
                                    ReturnDate = br.ReceivedDate,
                                    ReturnEndorsedBy = br.Endorsedby,
                                    BatteryReturnBatteryId = br.BatteryId,
                                    BusinessUnit = brel.BusinessUnit,
                                    Imjno = brel.Imjno,
                                    ReleaseDate = brel.ReleaseDate,
                                    ReleasedReceivedBy = brel.Receivedby,
                                    UserplateNo = brel.UserplateNo,
                                    Remarks = brel.Remarks,
                                    ReceivingId = brec.Id,
                                    ReceivedDate = brec.DateReceived,
                                    ReceivedReceivedBy = brec.Receivedby,
                                    DrsiNo = brec.DrsiNo.HasValue ? brec.DrsiNo.Value.ToString() : string.Empty,
                                    PoNo = brec.PoNo.HasValue ? brec.PoNo.Value.ToString() : string.Empty,
                                    ItemCode = brec.ItemCode,
                                    Supplier = brec.Supplier,
                                    ItemDescription = brec.ItemDescription,
                                    Batteryserial = brec.Batteryserial,
                                    DebossedNo = brec.DebossedNo
                                }).FirstOrDefaultAsync(); // Use FirstOrDefaultAsync since we're expecting a single item

            if (result == null)
            {
                return NotFound(); // Return a 404 if not found
            }

            return Ok(result); // Return the found item
        }





    }
}
