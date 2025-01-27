using AprendeCodigoAPI.Models;
using Microsoft.IdentityModel.Tokens;
using static AprendeCodigoAPI.DTOs.AuthDtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace AprendeCodigoAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppCodeContext _context;
        private readonly IConfiguration _config;

        public AuthService(AppCodeContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<AuthResponseDto> Login(LoginDto model)
        {
            var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == model.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.HashPassword))
                throw new Exception("Invalid credentials");

            return new AuthResponseDto(GenerateJwtToken(user), user.Username, user.Email);
        }

        public async Task<AuthResponseDto> Register(RegisterDto model)
        {
            if (await _context.Usuarios.AnyAsync(u => u.Email == model.Email || u.Username == model.Username))
                throw new Exception("User already exists");

            var user = new Usuario
            {
                Username = model.Username,
                Email = model.Email,
                Password = model.Password,
                HashPassword = BCrypt.Net.BCrypt.HashPassword(model.Password),
                FechaRegistro = DateTime.UtcNow
            };

            _context.Usuarios.Add(user);
            await _context.SaveChangesAsync();

            return new AuthResponseDto(GenerateJwtToken(user), user.Username, user.Email);
        }

        public string GenerateJwtToken(Usuario user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SecretKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
           new Claim(ClaimTypes.NameIdentifier, user.UsuarioId.ToString()),
           new Claim(ClaimTypes.Email, user.Email),
           new Claim(ClaimTypes.Name, user.Username)
       };

            var token = new JwtSecurityToken(
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_config["JWT:ExpirationMinutes"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
