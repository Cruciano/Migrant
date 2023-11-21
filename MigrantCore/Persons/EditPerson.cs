using MediatR;
using Microsoft.EntityFrameworkCore;
using MigrantCore.Entities;
using MigrantCore.Entities.Enums;
using MigrantCore.Persons.Requests;

namespace MigrantCore.Persons;

public class EditPersonHandler : IRequestHandler<EditPersonRequest, bool>
{
    private readonly MigrantCoreContext _context;

    public EditPersonHandler(MigrantCoreContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(EditPersonRequest request, CancellationToken cancellationToken)
    {
        var person = await _context.Persons.FirstOrDefaultAsync(_ => _.Id == request.Id, cancellationToken);

        if (person is null)
            return false;
            
        Gender gender;
        HouseCondition houseCondition;
        Invalidity invalidity;
        
        if (!Enum.TryParse(request.Gender, out gender))
            gender = Gender.Male;
        
        if (!Enum.TryParse(request.HouseCondition, out houseCondition))
            houseCondition = HouseCondition.Survived;
        
        if (!Enum.TryParse(request.Invalidity, out invalidity))
            invalidity = Invalidity.NoDisability;

        person.FullName = request.FullName;
        person.BirthDate = DateTime.Parse(request.BirthDate);
        person.Gender = gender;
        person.Document = request.Document;
        person.RegistrationDate = DateTime.Parse(request.RegistrationDate);
        person.RegistrationAddress = request.RegistrationAddress;
        person.HouseCondition = houseCondition;
        person.ResidenceAddress = request.ResidenceAddress;
        person.NeedHouse = request.NeedHouse;
        person.Phone = request.Phone;
        person.Invalidity = invalidity;
        person.IsLargeFamily = request.IsLargeFamily;
        person.NeedHelp = request.NeedHelp;
        person.AdditionalInfo = request.AdditionalInfo;
        person.DismissalNote = request.DismissalNote;
        person.RegistrationPlace = new RegistrationPlace
        {
            Id = request.RegistrationPlace.Id,
            Place = request.RegistrationPlace.Place,
        };

        _context.Update(person);
        
        await _context.SaveChangesAsync(cancellationToken);
        
        return true;
    }
}