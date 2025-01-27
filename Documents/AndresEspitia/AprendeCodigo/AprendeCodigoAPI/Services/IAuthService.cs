using AprendeCodigoAPI.Models;
using static AprendeCodigoAPI.DTOs.AuthDtos;

namespace AprendeCodigoAPI.Services
{
    public interface IAuthService
    {
        Task<AuthResponseDto> Login(LoginDto model);
        Task<AuthResponseDto> Register(RegisterDto model);
        string GenerateJwtToken(Usuario user);
    }
}
