using Grievance_Management_System.Constants;
using Grievance_Management_System.Request;
using Grievence_Management_System_Project.AppDbContext;
using Grievence_Management_System_Project.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Grievence_Management_System_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController(IStaffService staffService) : ControllerBase
    {
        [HttpPost("createStaff")]
        public async Task<IActionResult> Createstaff([FromBody] StaffRequest staffRequest)
        {
            await staffService.CreateStaff(staffRequest);
            return Ok(ErrorConstant.Created);
        }

        [HttpGet("getAllStaffs")]

        public async Task<IActionResult> GetAllStaffs()
        {
            return Ok(await staffService.GetAllStaffs());
        }
    }
}
