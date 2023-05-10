using AnastasiaDBCursach.Models;
using AnastasiaDBCursach.ResponseModels;
using AnastasiaDBCursach.Services.StaffService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace AnastasiaDBCursach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet,HttpOptions]

        public async Task<ActionResult<List<Staff>>> GetAllStaff()
        { 
            return await _staffService.GetAllStaff();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Staff>>> DeleteStaff(int id)
        { 
            var result = await _staffService.DeleteStaff(id);
            if (result is null)
                return NotFound("No such user");
            return Ok(result);
        }

        [HttpPost]

        public async Task<ActionResult<List<Staff>>> AddStaff(TableStaff staff)
        {
           var result = await _staffService.AddStaff(staff);
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult<List<Staff>>> UpdateStaff(TableStaff staff)
        {
            var result = await _staffService.UpdateStaff(staff);
            if (result is null)
                return NotFound("Staff with such id doesnt exist");
            return Ok(result);
        }
    }
}
