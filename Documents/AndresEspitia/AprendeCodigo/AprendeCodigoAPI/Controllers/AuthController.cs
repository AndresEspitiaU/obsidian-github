using AprendeCodigoAPI.Services;
using Microsoft.AspNetCore.Mvc;
using static AprendeCodigoAPI.DTOs.AuthDtos;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponseDto>> Login(LoginDto model)
    {
        try
        {
            return await _authService.Login(model);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("register")]
    public async Task<ActionResult<AuthResponseDto>> Register(RegisterDto model)
    {
        try
        {
            return await _authService.Register(model);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}