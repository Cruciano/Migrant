using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MigrantCore.Persons.Models;

namespace MigrantCore.Persons;

[ApiController]
[Route("api/person")]
public class PersonController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public PersonController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPut]
    [Authorize]
    public async Task<ActionResult<int>> Create([FromBody] CreatePerson request, CancellationToken cancellationToken)
    {
        var id = await _mediator.Send(request, cancellationToken);
        return id;
    }
    
    [HttpPost]
    [Authorize]
    public async Task<ActionResult> Update([FromBody] EditPerson request, CancellationToken cancellationToken)
    {
        var success = await _mediator.Send(request, cancellationToken);

        if (!success)
        {
            return NotFound();
        }
        return Ok();
    }
    
    [HttpGet("{id:int}")]
    [Authorize]
    public async Task<ActionResult<PersonModel>> Get([FromRoute] int id, CancellationToken cancellationToken)
    {
        var request = new GetPerson { Id = id };
        var result = await _mediator.Send(request, cancellationToken);

        if (result == null)
            return NotFound();
        
        return result;
    }
    
    [HttpGet]
    public async Task<ActionResult<PagedPeople>> GetAll([FromQuery] ListPeople request, CancellationToken cancellationToken)
    {
        var peoplePage = await _mediator.Send(request, cancellationToken);
        return peoplePage;
    }
}