using AnastasiaDBCursach.Models;
using AnastasiaDBCursach.Services.EventType;
using AnastasiaDBCursach.Services.PositionService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnastasiaDBCursach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RescheduledController : ControllerBase
    {
        private readonly IRescheduledEventsServices _rescheduledService;

        public RescheduledController(IRescheduledEventsServices rescheduledService)
        {
            _rescheduledService = rescheduledService;
        }

        [HttpGet, HttpOptions]
        public async Task<ActionResult<List<TableRescheduledEvent>>> GetAllStaff()
        {
            return await _rescheduledService.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<List<TableRescheduledEvent>>> AddPosition(TableRescheduledEvent position)
        {
            return await _rescheduledService.Add(position);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TableRescheduledEvent>?>> DeletePosition(int id)
        {
            var result = await _rescheduledService.Delete(id);
            if (result is null)
                return NotFound("No position to delete!");
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<TableRescheduledEvent>?>> UpdatePosition(TableRescheduledEvent position)
        {
            var result = await _rescheduledService.Edit(position);
            if (result is null)
                return NotFound("No such position found!");
            return Ok(result);
        }
    }
}
