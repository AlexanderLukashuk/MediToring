using AutoMapper;
using MediatR;
using MediToring.Application.Features.Medications.Commands.CreateMedication;
using MediToring.Application.Features.Medications.Commands.DeleteMedication;
using MediToring.Application.Features.Medications.Commands.UpdateMedication;
using MediToring.Application.Features.Medications.Queries.GetMedicationDetails;
using MediToring.Application.Features.Medications.Queries.GetMedicationList;
using MediToring.WebApi.Models.Request.Medications;
using Microsoft.AspNetCore.Mvc;

namespace MediToring.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MedicationController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public MedicationController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<MedicationListVm>>> GetAll()
    {
        var query = new GetMedicationListQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MedicationDetailsVm>> Get(Guid id)
    {
        var query = new GetMedicationDetailsQuery { Id = id };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateMedicationDto dto)
    {
        var command = _mapper.Map<CraeteMedicationCommand>(dto);
        var id = await _mediator.Send(command);
        return Ok(id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateMedicationDto dto)
    {
        var command = _mapper.Map<UpdateMedicationCommand>(dto);
        command.Id = id;
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteMedicationCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}