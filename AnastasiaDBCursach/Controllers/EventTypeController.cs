using AnastasiaDBCursach.Models;
using AnastasiaDBCursach.Services.EventType;
using AnastasiaDBCursach.Services.PositionService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnastasiaDBCursach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventTypeController : ControllerBase
    {
        private readonly IEventTypeService _eventTypeService;

        public EventTypeController(IEventTypeService eventTypeService)
        {
            _eventTypeService = eventTypeService;
        }

        [HttpGet, HttpOptions]
        public async Task<ActionResult<List<TableEventType>>> GetAllStaff()
        {
            return await _eventTypeService.GetAllEventTypes();
        }

        [HttpPost]
        public async Task<ActionResult<List<TableEventType>>> AddPosition(TableEventType position)
        {
            return await _eventTypeService.AddEventType(position);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TableEventType>?>> DeletePosition(int id)
        {
            var result = await _eventTypeService.DeleteEventType(id);
            if (result is null)
                return NotFound("No position to delete!");
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<TableEventType>?>> UpdatePosition(TableEventType position)
        {
            var result = await _eventTypeService.EditEventType(position);
            if (result is null)
                return NotFound("No such position found!");
            return Ok(result);
        }
    }
}
