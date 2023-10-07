using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace MigrantIdentity.Authentication;

public class AuthOptions
{
    public const string Issuer = "CompanyInfo";
    public const string Audience = "SureShotClient";
    public const string Key = "SUPER SECRET KEY";
    public const int Lifetime = 60;
    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
    }
}