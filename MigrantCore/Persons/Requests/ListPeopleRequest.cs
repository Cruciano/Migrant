using MediatR;
using MigrantCore.Persons.Models;

namespace MigrantCore.Persons.Requests;

public record ListPeopleRequest : IRequest<PeoplePage>
{
    public int PageSize { get; init; } = 20;
    public int PageNumber { get; init; } = 1;
}
