using MediatR;
using MigrantCore.Persons.Models;

namespace MigrantCore.Persons.Requests;

public record CreatePersonRequest : IRequest<int>
{
    public string FullName { get; init; }
    
    public string BirthDate { get; init; }
    
    public string Gender { get; init; }
    
    public string Document { get; init; }
    
    public string RegistrationDate { get; init; }
    
    public string RegistrationAddress { get; init; }
    
    public string HouseCondition { get; init; }
    
    public string ResidenceAddress { get; init; }
    
    public bool NeedHouse { get; init; }
    
    public string Phone { get; init; }
    
    public string Invalidity { get; init; }
    
    public bool IsLargeFamily { get; init; }
    
    public bool NeedHelp { get; init; }
    
    public string AdditionalInfo { get; init; }
    
    public bool DismissalNote { get; init; }
    
    public RegistrationPlaceModel RegistrationPlace { get; init; }
}
