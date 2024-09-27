using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using System.Globalization;
using OfficeOpenXml; // Ensure this is included for Excel handling

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class TireReceivingsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TireReceivingsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TireReceivings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TireReceiving>>> GetTireReceiving()
        {
            if (_context.TireReceiving == null)
            {
                return NotFound();
            }
            return await _context.TireReceiving.ToListAsync();
        }

        // GET: api/TireReceivings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TireReceiving>> GetTireReceiving(int id)
        {
            if (_context.TireReceiving == null)
            {
                return NotFound();
            }
            var tireReceiving = await _context.TireReceiving.FindAsync(id);

            if (tireReceiving == null)
            {
                return NotFound();
            }

            return tireReceiving;
        }

        // PUT: api/TireReceivings/5
        [Authorize(Roles = "Admin, FAIPadmin, FAIPwarehouse")] // Restrict access to specified roles
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTireReceiving(int id, TireReceiving tireReceiving)
        {
            if (id != tireReceiving.Id)
            {
                return BadRequest();
            }

            _context.Entry(tireReceiving).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TireReceivingExists(id))
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

        // POST: api/TireReceivings
        [Authorize(Roles = "Admin, FAIPadmin, FAIPwarehouse")] // Restrict access to specified roles
        [HttpPost]
        public async Task<ActionResult<TireReceiving>> PostTireReceiving(TireReceiving tireReceiving)
        {
            if (_context.TireReceiving == null)
            {
                return Problem("Entity set 'AppDbContext.TireReceiving' is null.");
            }
            tireReceiving.DateReceived = DateTime.Now;
            _context.TireReceiving.Add(tireReceiving);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTireReceiving", new { id = tireReceiving.Id }, tireReceiving);
        }

        [Authorize(Roles = "Admin, FAIPadmin")] // Restrict access to specified roles
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateTireStatus(int id, [FromBody] TireReceiving updateModel)
        {
            var tire = await _context.TireReceiving.FindAsync(id);
            if (tire == null)
            {
                return NotFound();
            }

            tire.Status = updateModel.Status;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/TireReceivings/5
        [Authorize(Roles = "Admin, FAIPadmin, FAIPwarehouse")] // Restrict access to specified roles
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTireReceiving(int id)
        {
            if (_context.TireReceiving == null)
            {
                return NotFound();
            }
            var tireReceiving = await _context.TireReceiving.FindAsync(id);
            if (tireReceiving == null)
            {
                return NotFound();
            }

            _context.TireReceiving.Remove(tireReceiving);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TireReceivingExists(int id)
        {
            return (_context.TireReceiving?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [Authorize(Roles = "Admin, FAIPadmin, FAIPwarehouse")]
        [HttpPost("upload")]
        public async Task<IActionResult> UploadExcel()
        {
            var response = new UploadResponse();

            try
            {
                if (Request.Form.Files.Count == 0)
                {
                    return BadRequest("No file uploaded.");
                }

                var file = Request.Form.Files[0]; // Assuming only one file is uploaded

                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    using (var package = new ExcelPackage(stream))
                    {
                        var worksheet = package.Workbook.Worksheets.FirstOrDefault();
                        if (worksheet != null)
                        {
                            var rowCount = worksheet.Dimension.Rows;
                            var tireReceivings = new List<TireReceiving>();

                            for (int row = 2; row <= rowCount; row++) // Assuming header is in row 1
                            {
                                var dateReceived = worksheet.Cells[row, 1].Value?.ToString();
                                var receivedBy = worksheet.Cells[row, 2].Value?.ToString() ?? "Unknown";
                                var drciNo = worksheet.Cells[row, 3].Value?.ToString();
                                var poNo = worksheet.Cells[row, 4].Value?.ToString();
                                var supplier = worksheet.Cells[row, 5].Value?.ToString();
                                var itemCode = worksheet.Cells[row, 6].Value?.ToString();
                                var quantity = worksheet.Cells[row, 7].Value?.ToString();
                                var unitOfMeasurement = worksheet.Cells[row, 8].Value?.ToString();
                                var tireSize = worksheet.Cells[row, 9].Value?.ToString();
                                var tireBrand = worksheet.Cells[row, 10].Value?.ToString();
                                var tireSerial = worksheet.Cells[row, 11].Value?.ToString();
                                var debossedNo = worksheet.Cells[row, 12].Value?.ToString();
                                var remarks = worksheet.Cells[row, 13].Value?.ToString();
                                var tireType = worksheet.Cells[row, 14].Value?.ToString();



                                DateTime? parsedDate = ParseDate(dateReceived);
                                if (!parsedDate.HasValue)
                                {
                                    Console.WriteLine($"Invalid date format for row {row}: '{dateReceived}'");
                                }

                                // Create TireReceiving object
                                tireReceivings.Add(new TireReceiving
                                {
                                    DateReceived = parsedDate,
                                    Receivedby = receivedBy,
                                    DrciNo = int.TryParse(drciNo, out var drciValue) ? (int?)drciValue : null,
                                    PoNo = int.TryParse(poNo, out var poValue) ? (int?)poValue : null,
                                    Supplier = supplier,
                                    ItemCode = itemCode,
                                    Quantity = int.TryParse(quantity, out int quantityValue) ? quantityValue : (int?)null,
                                    Unitofmeasurement = unitOfMeasurement,
                                    Tiresize = tireSize,
                                    Tirebrand = tireBrand,
                                    TireSerial = tireSerial,
                                    DebossedNo = debossedNo,
                                    Remarks = remarks,
                                    TireType = tireType,
                                    Status = "AVAILABLE", // Always "AVAILABLE"
                                    ItemCategory = "Tire", // Always "Tire"
                                });
                            }


                            _context.TireReceiving.AddRange(tireReceivings);
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

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<TireReceiving>>> SearchTireReceivings([FromQuery] string searchTerm)
        {
            if (_context.TireReceiving == null)
            {
                return NotFound();
            }

            // Trim the search term and ensure it's not null
            searchTerm = searchTerm?.Trim() ?? string.Empty;

            // Query to filter tire items based on search term across multiple fields
            var tireReceivings = await _context.TireReceiving
                .Where(t => t.Receivedby.Contains(searchTerm)
                            || t.Supplier.Contains(searchTerm)
                            || t.ItemCode.Contains(searchTerm)
                            || t.Tiresize.Contains(searchTerm)
                            || t.Tirebrand.Contains(searchTerm)
                            || t.TireSerial.Contains(searchTerm)
                            || t.Remarks.Contains(searchTerm)
                            || t.Status.Contains(searchTerm)
                            || t.TireType.Contains(searchTerm))
                .ToListAsync();

            // Return the filtered list
            return Ok(tireReceivings);
        }

        public class UploadResponse
        {
            public bool Success { get; set; }
            public string Message { get; set; }
        }

        // Helper method to parse the date
        private DateTime? ParseDate(string dateString)
        {
            if (string.IsNullOrWhiteSpace(dateString))
                return null;

            // Remove periods and trim the string
            dateString = dateString.Replace(".", "").Trim();

            // Define the expected date formats
            var formats = new[] { "MMM dd, yyyy" };

            // Try to parse the date
            if (DateTime.TryParseExact(dateString, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDate))
            {
                return parsedDate;
            }

            return null; // Return null if parsing fails
        }
    }
}
