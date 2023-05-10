using AnastasiaDBCursach.Models;
using AnastasiaDBCursach.Services.EventType;
using AnastasiaDBCursach.Services.PositionService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnastasiaDBCursach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _eventTypeService;

        public TicketController(ITicketService eventTypeService)
        {
            _eventTypeService = eventTypeService;
        }

        [HttpGet, HttpOptions]
        public async Task<ActionResult<List<TableTicket>>> GetAllStaff()
        {
            return await _eventTypeService.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<List<TableTicket>>> AddPosition(TableTicket position)
        {
            return await _eventTypeService.Add(position);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TableTicket>?>> DeletePosition(int id)
        {
            var result = await _eventTypeService.Delete(id);
            if (result is null)
                return NotFound("No position to delete!");
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<TableTicket>?>> UpdatePosition(TableTicket position)
        {
            var result = await _eventTypeService.Edit(position);
            if (result is null)
                return NotFound("No such position found!");
            return Ok(result);
        }
    }
}
