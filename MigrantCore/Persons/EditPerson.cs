using MediatR;
using Microsoft.EntityFrameworkCore;
using MigrantCore.Entities;
using MigrantCore.Persons.Models;

namespace MigrantCore.Persons;

public class EditPerson : IRequest<bool>
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

public class EditPersonHandler : IRequestHandler<EditPerson, bool>
{
    private readonly MigrantCoreContext _context;

    public EditPersonHandler(MigrantCoreContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(EditPerson request, CancellationToken cancellationToken)
    {
        var person = await _context.Persons.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (person == null)
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