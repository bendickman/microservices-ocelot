namespace JwtAuthenticationManager.Models;

public class AuthenticationResponse
{
    public string UserName { get; init; } = string.Empty;

    public string Token { get; init; } = string.Empty;

    public int ExpiryInSeconds { get; init; }
}
