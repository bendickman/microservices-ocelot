namespace JwtAuthenticationManager.Models;

public class AuthenticationRequest
{
    public string UserName { get; init; } = string.Empty;

    public string Password { get; init; } = string.Empty;
}
