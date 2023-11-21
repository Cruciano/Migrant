using MediatR;
using Microsoft.EntityFrameworkCore;
using MigrantCore.Persons.Mappers;
using MigrantCore.Persons.Models;
using MigrantCore.Persons.Requests;

namespace MigrantCore.Persons;

public class GetPersonHandler : IRequestHandler<GetPersonRequest, PersonModel>
{
    private readonly MigrantCoreContext _context;

    public GetPersonHandler(MigrantCoreContext context)
    {
        _context = context;
    }

    public async Task<PersonModel> Handle(GetPersonRequest request, CancellationToken cancellationToken)
    {
        var person = await _context.Persons.FirstOrDefaultAsync(_ => _.Id == request.Id, cancellationToken);
        
        if (person is null)
            return null;

        return person.MapPersonToModel();
    }
}