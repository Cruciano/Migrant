using MediatR;
using Microsoft.EntityFrameworkCore;
using MigrantCore.Persons.Models;
using MigrantCore.RegistrationPlaces.Requests;

namespace MigrantCore.RegistrationPlaces;

public class ListRegistrationPlacesHandler : IRequestHandler<ListRegistrationPlacesRequest, RegistrationPlaceModel[]>
{
    private readonly MigrantCoreContext _context;
    
    public ListRegistrationPlacesHandler(MigrantCoreContext context)
    {
        _context = context;
    }

    public async Task<RegistrationPlaceModel[]> Handle(ListRegistrationPlacesRequest request,
        CancellationToken cancellationToken)
    {
        var places = await _context.Places.ToListAsync(cancellationToken);

        var data = places.Select(_ => new RegistrationPlaceModel
        {
            Id = _.Id,
            Place = _.Place,
        }).ToArray();

        return data;
    }
}