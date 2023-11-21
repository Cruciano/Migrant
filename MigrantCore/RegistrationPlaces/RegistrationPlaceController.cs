using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MigrantCore.Persons.Models;
using MigrantCore.RegistrationPlaces.Requests;

namespace MigrantCore.RegistrationPlaces;

[ApiController]
[Route("api/registration-places")]
public class RegistrationPlaceController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public RegistrationPlaceController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Authorize]
    public async Task<RegistrationPlaceModel[]> GetAllAsync(CancellationToken cancellationToken)
    {
        var places = await _mediator.Send(new ListRegistrationPlacesRequest(), cancellationToken);
        
        return places;
    }
}