using Grievance_Management_System.Constants;
using Grievance_Management_System.Request;
using Grievence_Management_System_Project.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Grievence_Management_System_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("staffSignUp")]
        public async Task<IActionResult> StaffSignup([FromBody] StaffSignUpRequest staffSignUpRequest)
        {
            try
            {
                await authService.StaffSignUp(staffSignUpRequest);
                return Ok(ErrorConstant.Created);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getAllStaffsignUp")]
        public async Task<IActionResult> GetAllStaffRequest()
        {
            var staffSignUp = await authService.GetAllStaffSignUp();
            return Ok(staffSignUp);

        }

        [HttpPost("studentSignUp")]
        public async Task<IActionResult> StudentSignUp([FromBody] StudentSignUpRequest studentSignUpRequest)
        {
            try
            {
                await authService.StudentSignUp(studentSignUpRequest);
                return Ok(ErrorConstant.Created);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getAllStudentSignUp")]

        public async Task<IActionResult> GetAllStaffSignUp()
        {
            var studentSignUp = await authService.GetAllStudentSignUp();
            return Ok(studentSignUp);
        }

    }
}
