using MediatR;
using MigrantCore.Persons.Models;

namespace MigrantCore.Persons.Requests;

public record GetPersonRequest : IRequest<PersonModel>
{
    public int Id { get; init; }
}