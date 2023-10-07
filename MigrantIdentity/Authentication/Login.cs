using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace MigrantIdentity.Authentication;

public class Login : IRequest<LoginResult>
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class LoginResult
{
    public string UserId { get; set; }
    public string Username { get; set; }
    public string Token { get; set; }
    public DateTime Expires { get; set; }
}

public class LoginHandler : IRequestHandler<Login, LoginResult>
{
    private readonly SignInManager<IdentityUser> _signInManager;
    
    public LoginHandler(SignInManager<IdentityUser> signInManager)
    {
        _signInManager = signInManager;
    }
    
    public async Task<LoginResult> Handle(Login request, CancellationToken cancellationToken)
    {
        /* var newUser = new IdentityUser
        {
            Email = "qwerty@gmail.com",
            UserName = request.Username
        };
        
        await _userManager.CreateAsync(newUser, request.Password); */
        
        var user = await _signInManager.UserManager.FindByNameAsync(request.Username);

        if (user is null)
            throw new ArgumentException("User with this email is not found!");
        
        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
        
        if (!result.Succeeded)
            throw new ArgumentException("Login failed.");
        
        var (token, expires) = CreateToken(user);
        
        return new LoginResult
        {
            UserId = user.Id,
            Username = user.UserName,
            Token = token,
            Expires = expires
        };
    }
    
    private (string token, DateTime expires) CreateToken(IdentityUser user)
    {
        var securityKey = AuthOptions.GetSymmetricSecurityKey();
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

        var expires = DateTime.UtcNow.Add(TimeSpan.FromMinutes(AuthOptions.Lifetime));
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Expires = expires,
            SigningCredentials = credentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return (tokenHandler.WriteToken(token), expires);
    }
}