using MediatR;
using MigrantCore.Entities;
using MigrantCore.Entities.Enums;
using MigrantCore.Persons.Requests;

namespace MigrantCore.Persons;

public class CreatePersonHandler : IRequestHandler<CreatePersonRequest, int>
{
    private readonly MigrantCoreContext _context;

    public CreatePersonHandler(MigrantCoreContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreatePersonRequest request, CancellationToken cancellationToken)
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