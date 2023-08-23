using E3Starter.Configuration;
using E3Starter.Contracts.Services;
using E3Starter.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace E3Starter.Web.Controllers;

[Route("api/[action]")]
[ApiController]
public class PublicController : ControllerBase
{
    private readonly AppSettings _appSettings;
    private readonly IUserService _userService;

    public PublicController(IOptions<AppSettings> options, IUserService userService)
    {
        _appSettings = options.Value;
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginAttemptDto login)
    {
        if (login.Email is null || login.Password is null) throw new Exception();
        var user = await _userService.AuthenticateAsync(login.Email, login.Password);
        if (user == null) return Unauthorized();
        var token = GenerateJWT(user);
        return Ok(new { Token = token, User = user });
    }

    private string GenerateJWT(UserDto user)
    {
        if (_appSettings.Secret is null) throw new ApplicationException();
        var claims = new List<Claim> {
            new Claim("UserId", user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username)
        };
        foreach (var r in user.Roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, r.Name));
        }
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);
        return tokenString;
    }
}
