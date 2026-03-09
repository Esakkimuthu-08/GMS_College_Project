using Grievance_Management_System.Constants;
using Grievance_Management_System.Request;
using Grievence_Management_System_Project.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Grievence_Management_System_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApprovalController(IApprovalService approvalService) : ControllerBase
    {
        [HttpPost("approveStaff")]

        public async Task<IActionResult> ApproveStaff([FromBody] ApproveStaffDto approveStaffDto)
        {
            try
            {
                await approvalService.ApproveStaff(approveStaffDto);
                return Ok(ErrorConstant.Approved);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("approveStudent")]

        public async Task<IActionResult> ApproveStudent([FromBody] ApproveStudentDto approveStudentDto)
        {
            try
            {
                await approvalService.ApproveStudent(approveStudentDto);
                return Ok(ErrorConstant.Created);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
