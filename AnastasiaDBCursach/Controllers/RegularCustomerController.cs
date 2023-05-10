using AnastasiaDBCursach.Models;
using AnastasiaDBCursach.Services.EventType;
using AnastasiaDBCursach.Services.PositionService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnastasiaDBCursach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegularCustomerController : ControllerBase
    {
        private readonly IRegularCustomerService _regularCustomerService;

        public RegularCustomerController(IRegularCustomerService regularCustomerService)
        {
            _regularCustomerService = regularCustomerService;
        }

        [HttpGet, HttpOptions]
        public async Task<ActionResult<List<TableRegularCustomer>>> GetAllStaff()
        {
            return await _regularCustomerService.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<List<TableRegularCustomer>>> AddPosition(TableRegularCustomer position)
        {
            return await _regularCustomerService.Add(position);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TableRegularCustomer>?>> DeletePosition(int id)
        {
            var result = await _regularCustomerService.Delete(id);
            if (result is null)
                return NotFound("No position to delete!");
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<TableRegularCustomer>?>> UpdatePosition(TableRegularCustomer position)
        {
            var result = await _regularCustomerService.Edit(position);
            if (result is null)
                return NotFound("No such position found!");
            return Ok(result);
        }
    }
}
