using api.Data;
using api.Dto;
using api.MailUtils;
using api.Models;
using BCrypt.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        public UserController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (string.IsNullOrEmpty(registerDto.Email))
            {
                return BadRequest("Email không được để trống");
            }
            var existingEmail = await _context.users
              .Where(u => u.Email == registerDto.Email)
              .FirstOrDefaultAsync();

            if (existingEmail != null)
            {
                return Conflict("Email đã được đăng kí" );
            }
            string newPassword= GenerateRandomPassword(6);

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword, 10);
            var newUser = new User()
            {
                Email = registerDto.Email,
                Password = hashedPassword,
                Role="User"
            };
            _context.users.Add(newUser);
            await _context.SaveChangesAsync();


            var message = await MailUtils.MailUtils.SendMail(
                registerDto.Email,
                "Đăng kí tài khoản",
                $"<h1>Chào mừng!</h1>" +
                    $"<p>Đây là password của bạn: <strong>{newPassword}</strong></p>" +
                    $"<p>Hãy đăng nhập và đổi mật khẩu sau lần đăng nhập đầu tiên.</p>" +
                    $"<br><a href='http://localhost:8080'>Đi đến website</a>"
            );
            return Ok("Đăng kí thành công. Mật khẩu đã được gửi đến email của bạn. Vui lòng kiểm tra email.");
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (string.IsNullOrEmpty(loginDto.Email))
            {
                return BadRequest("Email không được để trống");
            }
            if (string.IsNullOrEmpty(loginDto.Password))
            {
                return BadRequest("Mật khẩu không được để trống");
            }
            var user = await _context.users.SingleOrDefaultAsync(u => u.Email == loginDto.Email);
            if (user == null)
            {
                return NotFound("Email chưa được đăng kí");
            }
            if(!BCrypt.Net.BCrypt.Verify(loginDto.Password,user.Password))
            {
                return BadRequest("Mật khẩu không chính xác");
            }
            var Token = GenerateJwtToken(user);

            var User = new
            {
                email=user.Email,
                phone=user.Phone,
                address=user.Address,
                role=user.Role,
                token=Token,
            };

            return Ok(User);
        }

        [HttpPost("recover")]
        public async Task<IActionResult> RecoverPassword([FromBody] RegisterDto registerDto)
        {
            if (string.IsNullOrEmpty(registerDto.Email))
            {
                return BadRequest("Email không được để trống");
            }
            var user = await _context.users
              .Where(u => u.Email == registerDto.Email)
              .FirstOrDefaultAsync();

            if (user == null)
            {
                return Conflict("Email chưa được đăng kí");
            }

            string newPassword = GenerateRandomPassword(6);
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword, 10);
            user.Password = hashedPassword;
            await _context.SaveChangesAsync();

            var message = await MailUtils.MailUtils.SendMail(
               registerDto.Email,
               "Cấp lại mật khẩu",
               $"<h1>Chào mừng !</h1>" +
                   $"<p>Đây là mật khẩu mới của bạn: <strong>{newPassword}</strong></p>" +
                   $"<br><a href='http://localhost:8080'>Đi đến website</a>"
           );
            return Ok("Mật khẩu mới đã được gửi. Vui lòng kiểm tra.");
        }

        [HttpGet("getByPage")]
        public async Task<IActionResult> getBypage(int page = 1, int limit = 10)
        {
            var user = await _context.users
                .Skip((page - 1) * limit)
                .Take(limit).ToListAsync();
            return Ok(user);
        }
        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(ClaimTypes.Role, user.Role), // Gán vai trò
                new Claim("UserId", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(2),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public static string  GenerateRandomPassword(int length)
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                StringBuilder sb = new StringBuilder();
                Random rand = new Random();

                for (int i = 0; i < length; i++)
                {
                    char c = chars[rand.Next(chars.Length)];
                    sb.Append(c);
                }

                return sb.ToString();
            }

        }

}
