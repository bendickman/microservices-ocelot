using JwtAuthenticationManager.Interfaces;
using JwtAuthenticationManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Api.Controllers;
[ApiController]
[Route("api")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;
    private readonly ITokenService _tokenService;

    public AuthController(
        ILogger<AuthController> logger,
        ITokenService jwtTokenHandler)
    {
        _logger = logger;
        _tokenService = jwtTokenHandler;
    }

    [HttpPost]
    [Route("auth")]
    public ActionResult<IEnumerable<AuthenticationResponse>> Get(
        [FromBody] AuthenticationRequest request)
    {
        var result = _tokenService.GenerateToken(request);

        if (result is null)
        {
            return Unauthorized();
        }

        return Ok(result);
    }
}
