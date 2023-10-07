using System.Text.Json;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MigrantIdentity.Authentication;

[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("api/auth/login")]
    public async Task<ActionResult> Login([FromBody] Login request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return Ok(result);
    }
}