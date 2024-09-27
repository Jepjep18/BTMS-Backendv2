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

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class BusinessUnitsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BusinessUnitsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Policy = "AdminorFAIPadmin")]
        public async Task<ActionResult<IEnumerable<BusinessUnit>>> GetBusinessUnit()
        {
          if (_context.BusinessUnit == null)
          {
              return NotFound();
          }
            return await _context.BusinessUnit.ToListAsync();
        }


        [HttpGet("{id}")]
        [Authorize(Policy = "AdminorFAIPadmin")]
        public async Task<ActionResult<BusinessUnit>> GetBusinessUnit(int id)
        {
          if (_context.BusinessUnit == null)
          {
              return NotFound();
          }
            var businessUnit = await _context.BusinessUnit.FindAsync(id);

            if (businessUnit == null)
            {
                return NotFound();
            }

            return businessUnit;
        }

      
        [HttpPut("{id}")]
        [Authorize(Policy = "AdminorFAIPadmin")]
        public async Task<IActionResult> PutBusinessUnit(int id, BusinessUnit businessUnit)
        {
            if (id != businessUnit.Id)
            {
                return BadRequest();
            }

            _context.Entry(businessUnit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessUnitExists(id))
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

       
        [HttpPost]
        [Authorize(Policy = "AdminorFAIPadmin")]
        public async Task<ActionResult<BusinessUnit>> PostBusinessUnit(BusinessUnit businessUnit)
        {
          if (_context.BusinessUnit == null)
          {
              return Problem("Entity set 'AppDbContext.BusinessUnit'  is null.");
          }
            _context.BusinessUnit.Add(businessUnit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBusinessUnit", new { id = businessUnit.Id }, businessUnit);
        }

        
        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminorFAIPadmin")]
        public async Task<IActionResult> DeleteBusinessUnit(int id)
        {
            if (_context.BusinessUnit == null)
            {
                return NotFound();
            }
            var businessUnit = await _context.BusinessUnit.FindAsync(id);
            if (businessUnit == null)
            {
                return NotFound();
            }

            _context.BusinessUnit.Remove(businessUnit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BusinessUnitExists(int id)
        {
            return (_context.BusinessUnit?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
