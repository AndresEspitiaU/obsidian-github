namespace AprendeCodigoAPI.DTOs
{
    public class AuthDtos
    {
        public record LoginDto(string Email, string Password);
        public record RegisterDto(string Username, string Email, string Password);
        public record AuthResponseDto(string Token, string Username, string Email);
    }
}
