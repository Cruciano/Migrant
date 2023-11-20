using MediatR;
using Microsoft.EntityFrameworkCore;
using MigrantCore.Persons.Mappers;
using MigrantCore.Persons.Models;
using Shared;

namespace MigrantCore.Persons;

public class ListPeople : IRequest<PagedPeople>
{
    public int PageSize { get; set; } = 20;
    public int PageNumber { get; set; } = 1;
}

public class PagedPeople
{
    public PersonModel[] PersonModels { get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public int TotalPages { get; set; }
    public int TotalRecords { get; set; }
}

public class ListPeopleHandler : IRequestHandler<ListPeople, PagedPeople>
{
    private readonly MigrantCoreContext _context;

    public ListPeopleHandler(MigrantCoreContext context)
    {
        _context = context;
    }

    public async Task<PagedPeople> Handle(ListPeople request, CancellationToken cancellationToken)
    {
        var allPeople = await _context.Persons.Page(request.PageNumber, request.PageSize).ToListAsync(cancellationToken);
        var count = await _context.Persons.CountAsync(cancellationToken);

        var data = allPeople.Select(x => x.MapPersonToModel()).ToArray();

        return new PagedPeople
        {
            PersonModels = data,
            PageSize = request.PageSize,
            PageNumber = request.PageNumber,
            TotalPages = count.TotalPages(request.PageSize),
            TotalRecords = count,
        };
    }
}