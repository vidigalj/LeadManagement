using LeadManagement.Domain.Commands;
using LeadManagement.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LeadManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeadController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeadController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddLead([FromBody] AddLeadCommand command)
        {
            var leadId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetLeadById), new { id = leadId }, leadId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLead(Guid id, [FromBody] UpdateLeadCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("ID mismatch");
            }

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLeadById(Guid id)
        {
            var lead = await _mediator.Send(new GetLeadByIdQuery(id));
            if (lead == null)
            {
                return NotFound();
            }

            return Ok(lead);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLeads()
        {
            var leads = await _mediator.Send(new GetAllLeadsQuery());
            return Ok(leads);
        }
    }
}
