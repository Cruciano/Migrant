using Microsoft.EntityFrameworkCore;
using MigrantCore.Entities;

namespace MigrantCore;

public class MigrantCoreContext  : DbContext
{
    public DbSet<RegistrationPlace> Places { get; set; }
    public DbSet<Person> Persons { get; set; }
    
    public MigrantCoreContext(DbContextOptions<MigrantCoreContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RegistrationPlace>().HasData(
            new RegistrationPlace[]
            {
                new RegistrationPlace() { Id = 1, Place = "ЦНАП" },
                new RegistrationPlace() { Id = 2, Place = "Степові хутори" },
            });
    }
}