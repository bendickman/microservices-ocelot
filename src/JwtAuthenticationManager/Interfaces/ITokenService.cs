using JwtAuthenticationManager.Models;

namespace JwtAuthenticationManager.Interfaces;
public interface ITokenService
{
    AuthenticationResponse? GenerateToken(AuthenticationRequest authenticationRequest);
}