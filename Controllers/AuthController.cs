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
        [HttpPost ("staffSignUp")]

        public IActionResult StaffSignup([FromBody] StaffSignUpRequest staffSignUpRequest)
        {
            authService.StaffSignUp(staffSignUpRequest);
            return Ok(ErrorConstant.Created);
        }
    }
}
