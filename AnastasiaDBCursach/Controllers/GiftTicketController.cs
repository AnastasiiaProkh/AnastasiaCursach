using AnastasiaDBCursach.Models;
using AnastasiaDBCursach.Services.EventType;
using AnastasiaDBCursach.Services.PositionService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnastasiaDBCursach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiftTicketController : ControllerBase
    {
        private readonly IGiftTicketService _giftTicketService;

        public GiftTicketController(IGiftTicketService giftTicketService)
        {
            _giftTicketService = giftTicketService;
        }

        [HttpGet, HttpOptions]
        public async Task<ActionResult<List<TableGiftTicket>>> GetAllStaff()
        {
            return await _giftTicketService.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<List<TableGiftTicket>>> AddPosition(TableGiftTicket position)
        {
            return await _giftTicketService.Add(position);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TableGiftTicket>?>> DeletePosition(int id)
        {
            var result = await _giftTicketService.Delete(id);
            if (result is null)
                return NotFound("No position to delete!");
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<TableGiftTicket>?>> UpdatePosition(TableGiftTicket position)
        {
            var result = await _giftTicketService.Edit(position);
            if (result is null)
                return NotFound("No such position found!");
            return Ok(result);
        }
    }
}
