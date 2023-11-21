using MigrantCore.Entities.Enums;

namespace MigrantCore.Entities;

public class Person
{
    public int Id { get; set; }
    
    public string FullName { get; set; }
    
    public DateTime BirthDate { get; set; }
    
    public Gender Gender { get; set; }
    
    public string Document { get; set; }
    
    public DateTime RegistrationDate { get; set; }
    
    public string RegistrationAddress { get; set; }
    
    public HouseCondition HouseCondition { get; set; }
    
    public string ResidenceAddress { get; set; }
    
    public bool NeedHouse { get; set; }
    
    public string Phone { get; set; }
    
    public Invalidity Invalidity { get; set; }
    
    public bool IsLargeFamily { get; set; }
    
    public bool NeedHelp { get; set; }
    
    public string AdditionalInfo { get; set; }
    
    public bool DismissalNote { get; set; }
    
    public RegistrationPlace RegistrationPlace { get; set; }
}