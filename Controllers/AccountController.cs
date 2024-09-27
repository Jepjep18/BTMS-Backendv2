using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;
using api.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AccountController> _logger;

        public AccountController(AppDbContext context, IConfiguration configuration, ILogger<AccountController> logger)
        {
            _context = context;
            _configuration = configuration;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            _logger.LogInformation("Login attempt for user: {Username}", loginDto.Username);

            var user = await _context.User.SingleOrDefaultAsync(u => u.Username == loginDto.Username);
            if (user == null)
            {
                _logger.LogWarning("Unauthorized login attempt for user: {Username}", loginDto.Username);
                return Unauthorized();
            }

            
            if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
            {
                _logger.LogWarning("Failed password verification for user: {Username}", loginDto.Username);
                return Unauthorized();
            }

           
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role) 
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

           
            return Ok(new { Token = tokenHandler.WriteToken(token) });
        }

    }
}
