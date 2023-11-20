using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<RegistrationPlaceModel[]> GetAll(CancellationToken cancellationToken)
    {
        var places = await _mediator.Send(new ListRegistrationPlaces(), cancellationToken);
        return places;
    }
}