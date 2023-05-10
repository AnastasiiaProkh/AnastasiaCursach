using AnastasiaDBCursach.Models;
using AnastasiaDBCursach.Services.EventType;
using AnastasiaDBCursach.Services.PositionService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnastasiaDBCursach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefundController : ControllerBase
    {
        private readonly IRefundService _refundService;

        public RefundController(IRefundService refundService)
        {
            _refundService = refundService;
        }

        [HttpGet, HttpOptions]
        public async Task<ActionResult<List<TableRefund>>> GetAllStaff()
        {
            return await _refundService.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<List<TableRefund>>> AddPosition(TableRefund position)
        {
            return await _refundService.Add(position);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TableRefund>?>> DeletePosition(int id)
        {
            var result = await _refundService.Delete(id);
            if (result is null)
                return NotFound("No position to delete!");
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<TableRefund>?>> UpdatePosition(TableRefund position)
        {
            var result = await _refundService.Edit(position);
            if (result is null)
                return NotFound("No such position found!");
            return Ok(result);
        }
    }
}
