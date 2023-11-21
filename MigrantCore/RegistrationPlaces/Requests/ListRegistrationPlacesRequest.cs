using MediatR;
using MigrantCore.Persons.Models;

namespace MigrantCore.RegistrationPlaces.Requests;

public record ListRegistrationPlacesRequest : IRequest<RegistrationPlaceModel[]> { }