using LearningBE.Models.Entities;
using LearningBE.Repositories;
using LearningBE.Services;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
namespace LearningBE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly UserService _userService; // Dùng UserService bro đã viết để check user
        private readonly UserRepository _userRepo;
        public AuthController(IConfiguration config, UserService userService, UserRepository userRepo)
        {
            _config = config;
            _userService = userService;
            _userRepo = userRepo;
        }
        public class LoginRequest { public string Username { get; set; } public string Password { get; set; } }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest login)
        {
            //var users = await _userService.GetListUserAsync();
            var userEntity = await _userRepo.GetByUsernameAsync(login.Username);
            if (userEntity == null || userEntity.Password != login.Password)
            {
                return Unauthorized("Sai tài khoản hoặc mật khẩu");
            }

            var token = GenerateJwtToken(userEntity);
            return Ok(new { token });
        }

        private string GenerateJwtToken(User user)
        {
            //Chuyển chuỗi Key từ cấu hình thành dạng byte để máy tính có thể xử lý mã hóa
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            //Chỉ định thuật toán mã hóa(thường là HmacSha256) để ký tên lên Token
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            //Đây là những mẩu thông tin về người dùng được nhúng vào Token(như Id, Username, Role).
            //Khi FE gửi Token lên, bro có thể lấy lại các thông tin này mà không cần truy vấn lại Database
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id!),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("Role", "Admin") // Bro có thể gán quyền ở đây
            };
            //Đối tượng chứa tất cả thông tin: ai phát hành, ai dùng, các Claims, thời điểm hết hạn và chữ ký bảo mật
            var token = new JwtSecurityToken(
                    _config["Jwt:Issuer"],
                    _config["Jwt:Audience"],
                    claims,
                    expires: DateTime.Now.AddMinutes(Convert.ToDouble(_config["Jwt:DurationInMinutes"])),
                    signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
