using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MigrantCore.RegistrationPlaces;

public class ListRegistrationPlaces : IRequest<RegistrationPlaceModel[]> { }

public class RegistrationPlaceModel
{
    public int Id { get; set; }
    public string Place { get; set; }
}

public class ListRegistrationPlacesHandler : IRequestHandler<ListRegistrationPlaces, RegistrationPlaceModel[]>
{
    private readonly MigrantCoreContext _context;
    
    public ListRegistrationPlacesHandler(MigrantCoreContext context)
    {
        _context = context;
    }

    public async Task<RegistrationPlaceModel[]> Handle(ListRegistrationPlaces request,
        CancellationToken cancellationToken)
    {
        var places = await _context.Places.ToListAsync(cancellationToken);

        var data = places.Select(x => new RegistrationPlaceModel
        {
            Id = x.Id,
            Place = x.Place,
        }).ToArray();

        return data;
    }
}