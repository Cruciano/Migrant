using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MigrantIdentity;

public class MigrantIdentityContext : IdentityDbContext<IdentityUser>
{    
    public MigrantIdentityContext(DbContextOptions<MigrantIdentityContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}