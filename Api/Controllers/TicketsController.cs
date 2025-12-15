using Api.Contracts.Tickets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/v1/tickets")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateTicket([FromBody] CreateTicketRequest request)
        {


            return CreatedAtAction();
        }

        [HttpGet("{id:int}")]
        public IActionResult GetTicketById(int id)
        {
            // Placeholder for retrieving tickets logic
            return Ok("List of tickets.");
        }

        [HttpPost("{id:int}/status")]
        public IActionResult ChangeStatus(int id, string newStatus, DateTime updatedAt)
        {
            return Ok("");
        }
    }
}
