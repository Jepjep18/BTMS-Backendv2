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
using OfficeOpenXml;
using System.Globalization;
using System;



namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class BatteryReceivingsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BatteryReceivingsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BatteryReceiving>>> GetBatteryReceiving()
        {
            if (_context.BatteryReceiving == null)
            {
                return NotFound();
            }
            return await _context.BatteryReceiving.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BatteryReceiving>> GetBatteryReceiving(int id)
        {
            if (_context.BatteryReceiving == null)
            {
                return NotFound();
            }
            var batteryReceiving = await _context.BatteryReceiving.FindAsync(id);

            if (batteryReceiving == null)
            {
                return NotFound();
            }

            return batteryReceiving;
        }


        [Authorize(Roles = "Admin, FAIPadmin, FAIPwarehouse")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBatteryReceiving(int id, BatteryReceiving batteryReceiving)
        {
            if (id != batteryReceiving.Id)
            {
                return BadRequest();
            }

            _context.Entry(batteryReceiving).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BatteryReceivingExists(id))
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

        [Authorize(Roles = "Admin, FAIPadmin, FAIPwarehouse")]
        [HttpPost]
        public async Task<ActionResult<BatteryReceiving>> PostBatteryReceiving(BatteryReceiving batteryReceiving)
        {
            if (_context.BatteryReceiving == null)
            {
                return Problem("Entity set 'AppDbContext.BatteryReceiving' is null.");
            }
            batteryReceiving.DateReceived = DateTime.Now;
            _context.BatteryReceiving.Add(batteryReceiving);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBatteryReceiving", new { id = batteryReceiving.Id }, batteryReceiving);
        }

        [Authorize(Roles = "Admin, FAIPadmin")]
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBatteryStatus(int id, [FromBody] BatteryReceiving updateModel)
        {
            var battery = await _context.BatteryReceiving.FindAsync(id);
            if (battery == null)
            {
                return NotFound();
            }

            battery.Status = updateModel.Status;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [Authorize(Roles = "Admin, FAIPadmin, FAIPwarehouse")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBatteryReceiving(int id)
        {
            if (_context.BatteryReceiving == null)
            {
                return NotFound();
            }
            var batteryReceiving = await _context.BatteryReceiving.FindAsync(id);
            if (batteryReceiving == null)
            {
                return NotFound();
            }

            _context.BatteryReceiving.Remove(batteryReceiving);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BatteryReceivingExists(int id)
        {
            return (_context.BatteryReceiving?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpGet("released-items")]
        public IActionResult GetReleasedItems()
        {

            if (_context.BatteryReleasing == null || _context.BatteryReceiving == null)
            {
                return NotFound();
            }


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

        [Authorize(Roles = "Admin, FAIPadmin, FAIPwarehouse")]
        [HttpPost("upload")]
        public async Task<IActionResult> UploadExcel()
        {
            var response = new UploadResponse();

            try
            {
                var file = Request.Form.Files[0];

                using (var stream = new MemoryStream())
                {
                    file.CopyTo(stream);
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    using (var package = new ExcelPackage(stream))
                    {
                        var worksheet = package.Workbook.Worksheets.FirstOrDefault();
                        if (worksheet != null)
                        {
                            var rowCount = worksheet.Dimension.Rows;
                            var batteryReceivings = new List<BatteryReceiving>();

                            for (int row = 2; row <= rowCount; row++)
                            {
                                var dateReceived = worksheet.Cells[row, 1].Value?.ToString();
                                var itemDescription = worksheet.Cells[row, 2].Value?.ToString();
                                var itemCode = worksheet.Cells[row, 3].Value?.ToString();
                                var batterySerialNo = worksheet.Cells[row, 4].Value?.ToString();
                                var drsiNo = worksheet.Cells[row, 5].Value?.ToString();
                                var poNo = worksheet.Cells[row, 6].Value?.ToString();
                                var supplier = worksheet.Cells[row, 7].Value?.ToString();
                                var debossedNo = worksheet.Cells[row, 8].Value?.ToString();
                                var unitOfMeasurement = worksheet.Cells[row, 9].Value?.ToString();
                                var quantity = worksheet.Cells[row, 10].Value?.ToString();
                                var receivedBy = worksheet.Cells[row, 11].Value?.ToString() ?? "Unknown";

                                DateTime? parsedDate = ParseDate(dateReceived);
                                if (!parsedDate.HasValue)
                                {
                                    Console.WriteLine($"Invalid date format for row {row}: '{dateReceived}'");
                                }


                                batteryReceivings.Add(new BatteryReceiving
                                {
                                    DateReceived = parsedDate,
                                    ItemDescription = itemDescription,
                                    ItemCode = itemCode,
                                    Batteryserial = batterySerialNo,
                                    DrsiNo = int.TryParse(drsiNo, out int drsiNoValue) ? drsiNoValue : (int?)null,
                                    PoNo = int.TryParse(poNo, out int poNoValue) ? poNoValue : (int?)null,
                                    Supplier = supplier,
                                    DebossedNo = debossedNo,
                                    Unitofmeasurement = unitOfMeasurement,
                                    Quantity = int.TryParse(quantity, out int quantityValue) ? quantityValue : (int?)null,
                                    Receivedby = receivedBy,
                                    Status = "AVAILABLE",
                                    ItemCategory = "Battery",
                                });
                            }

                            _context.BatteryReceiving.AddRange(batteryReceivings);
                            await _context.SaveChangesAsync();

                            response.Success = true;
                            response.Message = "Data uploaded successfully.";
                            return Ok(response);
                        }
                    }
                }

                response.Success = false;
                response.Message = "Invalid Excel file.";
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Internal server error: {ex}";
                return StatusCode(500, response);
            }
        }


        private DateTime? ParseDate(string dateString)
        {
            if (string.IsNullOrWhiteSpace(dateString))
                return null;


            dateString = dateString.Replace(".", "").Trim();


            var formats = new[] { "MMM dd, yyyy" };


            if (DateTime.TryParseExact(dateString, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDate))
            {
                return parsedDate;
            }

            return null;
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<BatteryReceiving>>> SearchBatteryReceivings([FromQuery] string searchTerm)
        {
            if (_context.BatteryReceiving == null)
            {
                return NotFound();
            }

            searchTerm = searchTerm?.Trim() ?? string.Empty;

            var batteryReceivings = await _context.BatteryReceiving
                .Where(t => t.Receivedby.Contains(searchTerm)
                            || t.Supplier.Contains(searchTerm)
                            || t.DrsiNo.ToString().Contains(searchTerm)
                            || t.PoNo.ToString().Contains(searchTerm)
                            || t.ItemCode.Contains(searchTerm)
                            || t.ItemDescription.Contains(searchTerm)
                            || t.Batteryserial.Contains(searchTerm)
                            || t.DebossedNo.Contains(searchTerm))
                .ToListAsync();

            return Ok(batteryReceivings);
        }











        public class UploadResponse
        {
            public bool Success { get; set; }
            public string Message { get; set; }
        }
    }
}