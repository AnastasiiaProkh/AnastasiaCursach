using AnastasiaDBCursach.Models;
using AnastasiaDBCursach.ResponseModels;
using AnastasiaDBCursach.Services.PositionService;
using AnastasiaDBCursach.Services.StaffService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnastasiaDBCursach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        [HttpGet, HttpOptions]
        public async Task<ActionResult<List<TablePosition>>> GetAllStaff()
        {
            return await _positionService.GetAllPositions();
        }

        [HttpPost]
        public async Task<ActionResult<List<TablePosition>>> AddPosition(TablePosition position)
        {
            return await _positionService.AddPosition(position);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TablePosition>?>> DeletePosition(int id) { 
            var result = await _positionService.DeletePosition(id);
            if(result is null)
                return NotFound("No position to delete!");
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<TablePosition>?>> UpdatePosition(TablePosition position)
        {
            var result = await _positionService.EditPosition(position);
            if (result is null)
                return NotFound("No such position found!");
            return Ok(result);
        }
    }
}
