using AnastasiaDBCursach.Models;
using AnastasiaDBCursach.Services.EventType;
using AnastasiaDBCursach.Services.PositionService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnastasiaDBCursach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SponsorsController : ControllerBase
    {
        private readonly ISponsorsService _sponsorsService;

        public SponsorsController(ISponsorsService sponsorsService)
        {
            _sponsorsService = sponsorsService;
        }

        [HttpGet, HttpOptions]
        public async Task<ActionResult<List<TableSponsor>>> GetAllStaff()
        {
            return await _sponsorsService.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<List<TableSponsor>>> AddPosition(TableSponsor position)
        {
            return await _sponsorsService.Add(position);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TableSponsor>?>> DeletePosition(int id)
        {
            var result = await _sponsorsService.Delete(id);
            if (result is null)
                return NotFound("No position to delete!");
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<TableSponsor>?>> UpdatePosition(TableSponsor position)
        {
            var result = await _sponsorsService.Edit(position);
            if (result is null)
                return NotFound("No such position found!");
            return Ok(result);
        }
    }
}
