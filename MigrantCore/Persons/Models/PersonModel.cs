namespace MigrantCore.Persons.Models;

public record PersonModel
{
    public int Id { get; set; }
    
    public string FullName { get; set; }
    
    public string BirthDate { get; set; }
    
    public string Gender { get; set; }
    
    public string Document { get; set; }
    
    public string RegistrationDate { get; set; }
    
    public string RegistrationAddress { get; set; }
    
    public string HouseCondition { get; set; }
    
    public string ResidenceAddress { get; set; }
    
    public bool NeedHouse { get; set; }
    
    public string Phone { get; set; }
    
    public string Invalidity { get; set; }
    
    public bool IsLargeFamily { get; set; }
    
    public bool NeedHelp { get; set; }
    
    public string AdditionalInfo { get; set; }
    
    public bool DismissalNote { get; set; }
    
    public RegistrationPlaceModel RegistrationPlace { get; set; }
}