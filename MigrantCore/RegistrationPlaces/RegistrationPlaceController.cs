using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MigrantCore.RegistrationPlaces;

[ApiController]
[Route("places")]
public class RegistrationPlaceController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public RegistrationPlaceController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<RegistrationPlaceModel[]> GetAll(CancellationToken cancellationToken)
    {
        var places = await _mediator.Send(new ListRegistrationPlaces(), cancellationToken);
        return places;
    }
}