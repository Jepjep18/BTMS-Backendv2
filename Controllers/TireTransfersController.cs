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
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using Microsoft.AspNetCore.Authorization; // Ensure you include this namespace

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TireTransfersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TireTransfersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TireTransfers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TireTransfer>>> GetTireTransfer()
        {
            if (_context.TireTransfer == null)
            {
                return NotFound();
            }
            return await _context.TireTransfer.ToListAsync();
        }

        // GET: api/TireTransfers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TireTransfer>> GetTireTransfer(int id)
        {
            if (_context.TireTransfer == null)
            {
                return NotFound();
            }
            var tireTransfer = await _context.TireTransfer.FindAsync(id);

            if (tireTransfer == null)
            {
                return NotFound();
            }

            return tireTransfer;
        }

        // PUT: api/TireTransfers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Admin, FAIPadmin, FAIPwarehouse")] // Restrict access to specified roles
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTireTransfer(int id, TireTransfer tireTransfer)
        {
            if (id != tireTransfer.Id)
            {
                return BadRequest();
            }

            _context.Entry(tireTransfer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TireTransferExists(id))
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

        // POST: api/TireTransfers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Admin, FAIPadmin, FAIPwarehouse")] // Restrict access to specified roles
        [HttpPost]
        public async Task<ActionResult<TireTransfer>> PostTireTransfer(TireTransfer tireTransfer)
        {
            if (_context.TireTransfer == null)
            {
                return Problem("Entity set 'AppDbContext.TireTransfer' is null.");
            }
            _context.TireTransfer.Add(tireTransfer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTireTransfer", new { id = tireTransfer.Id }, tireTransfer);
        }

        // DELETE: api/TireTransfers/5
        [Authorize(Roles = "Admin, FAIPadmin, FAIPwarehouse")] // Restrict access to specified roles
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTireTransfer(int id)
        {
            if (_context.TireTransfer == null)
            {
                return NotFound();
            }
            var tireTransfer = await _context.TireTransfer.FindAsync(id);
            if (tireTransfer == null)
            {
                return NotFound();
            }

            _context.TireTransfer.Remove(tireTransfer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TireTransferExists(int id)
        {
            return (_context.TireTransfer?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // GET: api/TireTransfers/history
        [HttpGet("history")]
        public async Task<ActionResult<IEnumerable<TireTransferHistoryDto>>> GetTireTransferHistory()
        {
            if (_context == null)
            {
                return NotFound();
            }

            var query = @"
                SELECT
                    tr.ItemCode AS ItemDescription,
                    tr.ItemCategory,
                    tr.DrciNo,
                    tr.PoNo,
                    tr.TireSerial AS SerialNo,
                    tr.DebossedNo,
                    tr.Status,
                    tt.TransferDate,
                    tt.BusinessUnitFrom,
                    tt.BusinessUnitTo,
                    tt.PlateNoFrom AS PlateNumberFrom,
                    tt.PlateNoTo AS PlateNumberTo
                FROM
                    TireReceiving tr
                INNER JOIN
                    TireTransfer tt
                ON
                    tr.Id = tt.ReleasingId;";

            using (IDbConnection dbConnection = _context.Database.GetDbConnection())
            {
                // Ensure the connection is open
                if (dbConnection.State == ConnectionState.Closed)
                    dbConnection.Open();

                var result = await dbConnection.QueryAsync<TireTransferHistoryDto>(query);

                return Ok(result);
            }
        }

        [HttpGet("transfers")]
        public async Task<IActionResult> GetTireTransferDetails()
        {
            var transferDetails = await GetTireTransferDetailsAsync();

            if (transferDetails == null || !transferDetails.Any())
            {
                return NotFound(); // Return 404 if no transfer details found
            }

            return Ok(transferDetails);
        }

        private async Task<List<TireTransferDto>> GetTireTransferDetailsAsync()
        {
            return await (from tt in _context.TireTransfer
                          join tr in _context.TireReleasing on tt.ReleasingId equals tr.Id
                          join rr in _context.TireReceiving on tr.TireId equals rr.Id
                          select new TireTransferDto
                          {
                              TransferDate = tt.TransferDate, // Transfer Date
                              ItemCategory = rr.ItemCategory, // Item Category
                              ItemDescription = rr.ItemCode, // Item Code as Item Description
                              BusinessUnitFrom = tt.BusinessUnitFrom,
                              BusinessUnitTo = tt.BusinessUnitTo,
                              PlateNoFrom = tt.PlateNoFrom,
                              PlateNoTo = tt.PlateNoTo,
                              Tirebrand = rr.Tirebrand,
                              Tiresize = rr.Tiresize,
                              TireSerial = rr.TireSerial,
                              ItemCode = rr.ItemCode,
                              TireType = rr.TireType,
                              Status = rr.Status
                          }).ToListAsync();
        }
    }
}
