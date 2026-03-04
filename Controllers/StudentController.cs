using Grievance_Management_System.Constants;
using Grievance_Management_System.Request;
using Grievence_Management_System_Project.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Grievence_Management_System_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(IStudentService studentService) : ControllerBase
    {
        [HttpPost ("createstudent")]
        public IActionResult CreateStudent([FromBody] StudentSignUpRequest studentSignUpRequest)
        {
            studentService.CreateStudent (studentSignUpRequest);
            return Ok(ErrorConstant.Created);
        }
    }
}
