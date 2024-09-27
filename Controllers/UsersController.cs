using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Models;
using BCrypt.Net;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("all-users")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
          if (_context.User == null)
          {
              return NotFound();
          }
            return await _context.User.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
          if (_context.User == null)
          {
              return NotFound();
          }
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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
        [Authorize(Policy ="Admin")]
        public async Task<ActionResult<User>> PostUser(User user)
        {
          if (_context.User == null)
          {
              return Problem("Entity set 'AppDbContext.User'  is null.");
          }
            if (!ModelState.IsValid) 
            { 
                return BadRequest(ModelState);
            }
          if (!string.IsNullOrEmpty(user.PasswordHash))
            {
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            }
            user.DateCreated = DateTime.Now;
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.User == null)
            {
                return NotFound();
            }
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}/edit-role")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> AssignRole(int id, [FromBody] string name)
        {
            if(_context.User == null || _context.Role == null)
            {
                return Problem("Entity set 'AppDbContext.User' or 'AppDbContext.Role' is null");
            }
            var user = await _context.User.FindAsync(id);
            if(user == null)
            {
                return NotFound($"User with ID {id} not found");
            }
            var role = await _context.Role.SingleOrDefaultAsync(r => r.Name == name);
            if (role == null)
            {
                return NotFound($"Role '{name}' not found.");
            }
            user.Role = role.Name;
            _context.Entry(user).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(new {Message = "Role edited successfully"});
        }

        [HttpGet("current-user")]
        [Authorize] // Ensure only authenticated users can access this endpoint
        public async Task<ActionResult<User>> GetCurrentUser()
        {
            // Get the user ID from the claims
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            // Find the user in the database
            int userId = int.Parse(userIdClaim.Value); // Adjust parsing as needed
            var user = await _context.User.FindAsync(userId);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            return user;
        }

        private bool UserExists(int id)
        {
            return (_context.User?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
