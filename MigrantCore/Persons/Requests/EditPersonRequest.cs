using MediatR;
using MigrantCore.Persons.Models;

namespace MigrantCore.Persons.Requests;

public record EditPersonRequest : IRequest<bool>
{
    public int Id { get; init; } 
    
    public string FullName { get; init; } = null!;
    
    public string BirthDate { get; init; } = null!;
    
    public string Gender { get; init; } = null!;
    
    public string Document { get; init; } = null!;
    
    public string RegistrationDate { get; init; } = null!;
    
    public string RegistrationAddress { get; init; } = null!;
    
    public string HouseCondition { get; init; } = null!;
    
    public string ResidenceAddress { get; init; } = null!;
    
    public bool NeedHouse { get; init; } 
    
    public string Phone { get; init; } = null!;
    
    public string Invalidity { get; init; } = null!;
    
    public bool IsLargeFamily { get; init; } 
    
    public bool NeedHelp { get; init; }
    
    public string AdditionalInfo { get; init; } = null!;
    
    public bool DismissalNote { get; init; }
    
    public RegistrationPlaceModel RegistrationPlace { get; init; } = null!;
}