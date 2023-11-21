using MediatR;
using Microsoft.EntityFrameworkCore;
using MigrantCore.Persons.Mappers;
using MigrantCore.Persons.Models;
using MigrantCore.Persons.Requests;
using Shared;

namespace MigrantCore.Persons;

public class ListPeopleHandler : IRequestHandler<ListPeopleRequest, PeoplePage>
{
    private readonly MigrantCoreContext _context;

    public ListPeopleHandler(MigrantCoreContext context)
    {
        _context = context;
    }

    public async Task<PeoplePage> Handle(ListPeopleRequest request, CancellationToken cancellationToken)
    {
        var allPeople = await _context.Persons.Page(request.PageNumber, request.PageSize).ToListAsync(cancellationToken);
        var count = await _context.Persons.CountAsync(cancellationToken);

        var data = allPeople.Select(_ => _.MapPersonToModel()).ToArray();

        return new PeoplePage
        {
            PersonModels = data,
            PageSize = request.PageSize,
            PageNumber = request.PageNumber,
            TotalPages = count.TotalPages(request.PageSize),
            TotalRecords = count,
        };
    }
}