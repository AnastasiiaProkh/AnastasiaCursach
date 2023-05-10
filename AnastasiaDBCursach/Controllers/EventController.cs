using AnastasiaDBCursach.Models;
using AnastasiaDBCursach.Services.EventType;
using AnastasiaDBCursach.Services.PositionService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnastasiaDBCursach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet, HttpOptions]
        public async Task<ActionResult<List<TableEvent>>> GetAllStaff()
        {
            return await _eventService.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<List<TableEvent>>> AddPosition(TableEvent position)
        {
            return await _eventService.Add(position);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TableEvent>?>> DeletePosition(int id)
        {
            var result = await _eventService.Delete(id);
            if (result is null)
                return NotFound("No position to delete!");
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<TableEvent>?>> UpdatePosition(TableEvent position)
        {
            var result = await _eventService.Edit(position);
            if (result is null)
                return NotFound("No such position found!");
            return Ok(result);
        }
    }
}
