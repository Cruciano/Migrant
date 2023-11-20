using MediatR;
using Microsoft.EntityFrameworkCore;
using MigrantCore.Entities;
using MigrantCore.Persons.Mappers;
using MigrantCore.Persons.Models;

namespace MigrantCore.Persons;

public class GetPerson : IRequest<PersonModel>
{
    public int Id { get; set; }
}

public class GetPersonHandler : IRequestHandler<GetPerson, PersonModel>
{
    private readonly MigrantCoreContext _context;

    public GetPersonHandler(MigrantCoreContext context)
    {
        _context = context;
    }

    public async Task<PersonModel> Handle(GetPerson request, CancellationToken cancellationToken)
    {
        var person = await _context.Persons.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        
        if (person == null)
            return null;

        return person.MapPersonToModel();
    }
}