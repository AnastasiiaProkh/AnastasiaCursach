using AnastasiaDBCursach.Models;
using AnastasiaDBCursach.Services.EventType;
using AnastasiaDBCursach.Services.PositionService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnastasiaDBCursach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvitationsController : ControllerBase
    {
        private readonly IInvitationService _invitationsService;

        public InvitationsController(IInvitationService invitationService)
        {
            _invitationsService = invitationService;
        }

        [HttpGet, HttpOptions]
        public async Task<ActionResult<List<TableInvitation>>> GetAllStaff()
        {
            return await _invitationsService.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<List<TableInvitation>>> AddPosition(TableInvitation position)
        {
            return await _invitationsService.Add(position);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TableInvitation>?>> DeletePosition(int id)
        {
            var result = await _invitationsService.Delete(id);
            if (result is null)
                return NotFound("No position to delete!");
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<TableInvitation>?>> UpdatePosition(TableInvitation position)
        {
            var result = await _invitationsService.Edite(position);
            if (result is null)
                return NotFound("No such position found!");
            return Ok(result);
        }
    }
}
