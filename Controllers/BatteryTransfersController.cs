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
using api.DTO;
using Microsoft.AspNetCore.Authorization; // Ensure you include this namespace

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class BatteryTransfersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BatteryTransfersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/BatteryTransfers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BatteryTransfer>>> GetBatteryTransfer()
        {
            if (_context.BatteryTransfer == null)
            {
                return NotFound();
            }
            return await _context.BatteryTransfer.ToListAsync();
        }

        // GET: api/BatteryTransfers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BatteryTransfer>> GetBatteryTransfer(int id)
        {
            if (_context.BatteryTransfer == null)
            {
                return NotFound();
            }
            var batteryTransfer = await _context.BatteryTransfer.FindAsync(id);

            if (batteryTransfer == null)
            {
                return NotFound();
            }

            return batteryTransfer;
        }

        // PUT: api/BatteryTransfers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Admin, FAIPadmin, FAIPwarehouse")] // Restrict access to specified roles

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBatteryTransfer(int id, BatteryTransfer batteryTransfer)
        {
            if (id != batteryTransfer.Id)
            {
                return BadRequest();
            }

            _context.Entry(batteryTransfer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BatteryTransferExists(id))
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

        // POST: api/BatteryTransfers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Admin, FAIPadmin, FAIPwarehouse")] // Restrict access to specified roles

        [HttpPost]
        public async Task<ActionResult<BatteryTransfer>> PostBatteryTransfer(BatteryTransfer batteryTransfer)
        {
            batteryTransfer.TransferDate = DateTime.Now;
            if (_context.BatteryTransfer == null)
            {
                return Problem("Entity set 'AppDbContext.BatteryTransfer' is null.");
            }
            _context.BatteryTransfer.Add(batteryTransfer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBatteryTransfer", new { id = batteryTransfer.Id }, batteryTransfer);
        }

        // DELETE: api/BatteryTransfers/5
        [Authorize(Roles = "Admin, FAIPadmin, FAIPwarehouse")] // Restrict access to specified roles

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBatteryTransfer(int id)
        {
            if (_context.BatteryTransfer == null)
            {
                return NotFound();
            }
            var batteryTransfer = await _context.BatteryTransfer.FindAsync(id);
            if (batteryTransfer == null)
            {
                return NotFound();
            }

            _context.BatteryTransfer.Remove(batteryTransfer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BatteryTransferExists(int id)
        {
            return (_context.BatteryTransfer?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpGet("transfers")]
        public async Task<IActionResult> GetBatteryTransferDetails()
        {
            var transferDetails = await GetBatteryTransferDetailsAsync();

            if (transferDetails == null || !transferDetails.Any())
            {
                return NotFound(); // Return 404 if no transfer details found
            }

            return Ok(transferDetails);
        }

        private async Task<List<BatteryTransferDto>> GetBatteryTransferDetailsAsync()
        {
            return await (from bt in _context.BatteryTransfer
                          join bl in _context.BatteryReleasing on bt.ReleasingId equals bl.Id
                          join br in _context.BatteryReceiving on bl.BatteryId equals br.Id
                          select new BatteryTransferDto
                          {
                              Id = bt.Id, // Ensure you're mapping the ID

                              TransferDate = bt.TransferDate,
                              ItemCategory = br.ItemCategory,
                              DrsiNo = br.DrsiNo ?? 0,
                              PoNo = br.PoNo ?? 0,
                              ItemDescription = br.ItemDescription,
                              BusinessUnitFrom = bt.BusinessUnitFrom,
                              BusinessUnitTo = bt.BusinessUnitTo,
                              PlateNoFrom = bt.PlateNoFrom,
                              PlateNoTo = bt.PlateNoTo,
                              Status = br.Status,
                              ItemCode = br.ItemCode,
                              Supplier = br.Supplier,
                              Batteryserial = br.Batteryserial,
                              DebossedNo = br.DebossedNo,
                              BatteryReceivingId = bl.Id





                          }).ToListAsync();
        }
    }
}
