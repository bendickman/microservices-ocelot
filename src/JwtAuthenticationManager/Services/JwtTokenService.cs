using JwtAuthenticationManager.Interfaces;
using JwtAuthenticationManager.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtAuthenticationManager.Services;

public class JwtTokenService : ITokenService
{
    private static readonly List<UserAccount> _userAccountList = new List<UserAccount>
    {
        new UserAccount{ UserName = "admin", Password = "password123", Role = "Administrator" },
        new UserAccount{ UserName = "user", Password = "password456", Role = "User" },
    };

    public AuthenticationResponse? GenerateToken(
        AuthenticationRequest authenticationRequest)
    {
        if (string.IsNullOrWhiteSpace(authenticationRequest.UserName) ||
            string.IsNullOrWhiteSpace(authenticationRequest.Password))
        {
            return null;
        }

        var userAccount = _userAccountList
            .Where(x => x.UserName == authenticationRequest.UserName && x.Password == authenticationRequest.Password)
            .FirstOrDefault();

        if (userAccount is null)
        {
            return null;
        }

        var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(Constants.JWT_TOKEN_VALIDITY_MINS);
        var tokenKey = Encoding.ASCII.GetBytes(Constants.JWT_SECURITY_KEY);

        var claimsIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, authenticationRequest.UserName),
                new Claim("Role", userAccount.Role)
            });

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(tokenKey),
            SecurityAlgorithms.HmacSha256Signature);

        var securityTokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = claimsIdentity,
            Expires = tokenExpiryTimeStamp,
            SigningCredentials = signingCredentials
        };

        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
        var token = jwtSecurityTokenHandler.WriteToken(securityToken);

        return new AuthenticationResponse
        {
            UserName = userAccount.UserName,
            ExpiryInSeconds = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds,
            Token = token
        };
    }
}
