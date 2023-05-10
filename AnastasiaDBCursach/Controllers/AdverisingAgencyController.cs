using AnastasiaDBCursach.Models;
using AnastasiaDBCursach.Services.EventType;
using AnastasiaDBCursach.Services.PositionService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnastasiaDBCursach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertasingAgencies : ControllerBase
    {
        private readonly IAddvertisinAgenciesService _advertisingAgencyService;

        public AdvertasingAgencies(IAddvertisinAgenciesService advertisingAgencyService)
        {
            _advertisingAgencyService = advertisingAgencyService;
        }

        [HttpGet, HttpOptions]
        public async Task<ActionResult<List<TableAdvertisingAgency>>> GetAllStaff()
        {
            return await _advertisingAgencyService.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<List<TableAdvertisingAgency>>> AddPosition(TableAdvertisingAgency position)
        {
            return await _advertisingAgencyService.Add(position);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TableAdvertisingAgency>?>> DeletePosition(int id)
        {
            var result = await _advertisingAgencyService.Delete(id);
            if (result is null)
                return NotFound("No agency to delete!");
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<TableAdvertisingAgency>?>> UpdatePosition(TableAdvertisingAgency position)
        {
            var result = await _advertisingAgencyService.Edit(position);
            if (result is null)
                return NotFound("No such agency found!");
            return Ok(result);
        }
    }
}
