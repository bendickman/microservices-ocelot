namespace JwtAuthenticationManager.Models;

public class UserAccount
{
    public string UserName { get; init; } = string.Empty;

    public string Password { get; init; } = string.Empty;

    public string Role { get; init; } = string.Empty;
}