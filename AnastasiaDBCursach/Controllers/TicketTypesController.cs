using AnastasiaDBCursach.Models;
using AnastasiaDBCursach.Services.TicketType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnastasiaDBCursach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketTypesController : ControllerBase
    {
        private readonly ITicketTypeService _ticketTypeService;
        public TicketTypesController(ITicketTypeService service)
        {
            _ticketTypeService = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<TableTicketType>>> GetAllTicketTypes()
        { 
            return await _ticketTypeService.GetAllTicketTypes();
        }

        [HttpPost]
        public async Task<ActionResult<List<TableTicketType>>> AddTicketType(TableTicketType tableTicket)
        {
            return await _ticketTypeService.AddTicketType(tableTicket);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TableTicketType>>> DeleteTicketType(int id)
        {
            var result = await _ticketTypeService.DeleteTicketType(id);
            if(result is null)
                return NotFound("No type to delete!");
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult<List<TableTicketType>>> UpdateTicketType(TableTicketType tableTicket)
        {
            var result = await _ticketTypeService.UpdateTicketType(tableTicket);
            if (result is null)
                return NotFound("No type to delete!");
            return Ok(result);
        }
    }
}
