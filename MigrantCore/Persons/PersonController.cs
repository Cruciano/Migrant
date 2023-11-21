using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MigrantCore.Persons.Models;
using MigrantCore.Persons.Requests;

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
    
    [HttpGet]
    public async Task<ActionResult<PeoplePage>> GetAllAsync([FromQuery] ListPeopleRequest request, CancellationToken cancellationToken)
    {
        var peoplePage = await _mediator.Send(request, cancellationToken);
        
        return peoplePage;
    }
    
    [HttpGet("{id:int}")]
    [Authorize]
    public async Task<ActionResult<PersonModel>> GetAsync([FromRoute] int id, CancellationToken cancellationToken)
    {
        var request = new GetPersonRequest { Id = id };
        var result = await _mediator.Send(request, cancellationToken);

        if (result is null)
            return NotFound();
        
        return result;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<int>> CreateAsync([FromBody] CreatePersonRequest request, CancellationToken cancellationToken)
    {
        var id = await _mediator.Send(request, cancellationToken);
        
        return id;
    }
    
    [HttpPut]
    [Authorize]
    public async Task<ActionResult> UpdateAsync([FromBody] EditPersonRequest request, CancellationToken cancellationToken)
    {
        var success = await _mediator.Send(request, cancellationToken);

        if (!success)
            return NotFound();
        
        return Ok();
    }
}