namespace MigrantCore.Persons.Models;

public record PeoplePage
{
    public PersonModel[] PersonModels { get; init; }
    
    public int PageSize { get; init; }
    
    public int PageNumber { get; init; }
    
    public int TotalPages { get; init; }
    
    public int TotalRecords { get; init; }
}