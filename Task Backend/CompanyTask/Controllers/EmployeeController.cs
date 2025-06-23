using DTOs.EmployeeDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.EmployeeServices;

namespace CompanyTask.Controllers
{
    [Route("api/v1/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public IEmployeeService _employeeService { get; set; }

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetAllEmployees()
        {
            List<EmployeeDto> employees = await _employeeService.GetAllEmployees();

            if (employees.Count == 0)
                return NotFound(new { message = "No employees was found in the system!" });

            return Ok(employees);
        }

        [HttpDelete("{employeeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteEmployee(int employeeId)
        {
            bool isDone = await _employeeService.DeleteEmployee(employeeId);

            if (!isDone)
                return NotFound(new { message = "No Employee with this Id!" });

            return Ok(isDone);
        }
    }
}
