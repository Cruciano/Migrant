namespace MigrantCore.Persons.Models;

public record RegistrationPlaceModel
{
    public int Id { get; init; }
    
    public string Place { get; init; }
}