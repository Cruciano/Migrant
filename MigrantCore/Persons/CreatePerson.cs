using MediatR;
using Microsoft.EntityFrameworkCore;
using MigrantCore.Entities;
using MigrantCore.Persons.Models;

namespace MigrantCore.Persons;

public class CreatePerson : IRequest<int>
{
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

public class CreatePersonHandler : IRequestHandler<CreatePerson, int>
{
    private readonly MigrantCoreContext _context;

    public CreatePersonHandler(MigrantCoreContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreatePerson request, CancellationToken cancellationToken)
    {
        Gender gender;
        HouseCondition houseCondition;
        Invalidity invalidity;
        
        if (!Enum.TryParse(request.Gender, out gender))
            gender = Gender.Male;
        
        if (!Enum.TryParse(request.HouseCondition, out houseCondition))
            houseCondition = HouseCondition.Survived;
        
        if (!Enum.TryParse(request.Invalidity, out invalidity))
            invalidity = Invalidity.NoDisability;
        
        var person = new Person
        {
            FullName = request.FullName,
            BirthDate = DateTime.Parse(request.BirthDate),
            Gender = gender,
            Document = request.Document,
            RegistrationDate = DateTime.Parse(request.RegistrationDate),
            RegistrationAddress = request.RegistrationAddress,
            HouseCondition = houseCondition,
            ResidenceAddress = request.ResidenceAddress,
            NeedHouse = request.NeedHouse,
            Phone = request.Phone,
            Invalidity = invalidity,
            IsLargeFamily = request.IsLargeFamily,
            NeedHelp = request.NeedHelp,
            AdditionalInfo = request.AdditionalInfo,
            DismissalNote = request.DismissalNote,
            RegistrationPlace =  new RegistrationPlace
            {
                Id = request.RegistrationPlace.Id,
                Place = request.RegistrationPlace.Place,
            },
        };

        await _context.Persons.AddAsync(person, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        
        return person.Id;
    }
}