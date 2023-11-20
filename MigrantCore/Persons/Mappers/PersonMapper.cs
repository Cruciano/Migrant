using MigrantCore.Entities;
using MigrantCore.Persons.Models;

namespace MigrantCore.Persons.Mappers;

public static class PersonMapper
{
    public static Person MapModelToPerson(this PersonModel model)
    {
        Gender gender;
        HouseCondition houseCondition;
        Invalidity invalidity;
        
        if (!Enum.TryParse(model.Gender, out gender))
            gender = Gender.Male;
        
        if (!Enum.TryParse(model.HouseCondition, out houseCondition))
            houseCondition = HouseCondition.Survived;
        
        if (!Enum.TryParse(model.Invalidity, out invalidity))
            invalidity = Invalidity.NoDisability;
        
        return new Person
        {
            FullName = model.FullName,
            BirthDate = DateTime.Parse(model.BirthDate),
            Gender = gender,
            Document = model.Document,
            RegistrationDate = DateTime.Parse(model.RegistrationDate),
            RegistrationAddress = model.RegistrationAddress,
            HouseCondition = houseCondition,
            ResidenceAddress = model.ResidenceAddress,
            NeedHouse = model.NeedHouse,
            Phone = model.Phone,
            Invalidity = invalidity,
            IsLargeFamily = model.IsLargeFamily,
            NeedHelp = model.NeedHelp,
            AdditionalInfo = model.AdditionalInfo,
            DismissalNote = model.DismissalNote,
            RegistrationPlace =  new RegistrationPlace
            {
                Id = model.RegistrationPlace.Id,
                Place = model.RegistrationPlace.Place,
            },
        };
    }

    public static PersonModel MapPersonToModel(this Person person)
    {
        return new PersonModel
        {
            Id = person.Id,
            FullName = person.FullName,
            BirthDate = person.BirthDate.ToString(),
            Gender = person.Gender.ToString(),
            Document = person.Document,
            RegistrationAddress = person.RegistrationAddress,
            HouseCondition = person.HouseCondition.ToString(),
            ResidenceAddress = person.ResidenceAddress,
            NeedHouse = person.NeedHouse,
            Phone = person.Phone,
            Invalidity = person.Invalidity.ToString(),
            IsLargeFamily = person.IsLargeFamily,
            NeedHelp = person.NeedHelp,
            AdditionalInfo = person.AdditionalInfo,
            DismissalNote = person.DismissalNote,
            RegistrationPlace = new RegistrationPlaceModel
            {
                Id = person.RegistrationPlace.Id,
                Place = person.RegistrationPlace.Place,
            }
        };
    }
}