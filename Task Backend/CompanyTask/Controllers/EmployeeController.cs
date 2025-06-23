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

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddNewEmployee([FromBody] AddEmployeeDto addEmployeeDto)
        {
            if (!_employeeService.IsAddEmployeeInfoCorrect(addEmployeeDto))
                return BadRequest("Data Is not valied!");

            bool IsDone = await _employeeService.AddNewEmployee(addEmployeeDto);

            if (!IsDone)
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to add Employee!");

            return Ok(IsDone);
        }

        [HttpGet("{employeeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetEmployeeInfo(int employeeId)
        {
            EmployeeDto? employeeDto = await _employeeService.GetEmployeeInfo(employeeId);

            if (employeeDto is null)
                return NotFound("No Employee found for this Id!");

            return Ok(employeeDto);
        }

        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateEmployee([FromBody] UpdateEmployeDto updateEmploye)
        {
            if (!_employeeService.IsUpdateEmployeeInfoCorrect(updateEmploye))
                return BadRequest("Invalied or empty data!");

            bool IsDene = await _employeeService.UpdateEmployee(updateEmploye);

            if (!IsDene)
                return NotFound("No Employee with this Id!");

            return Ok(IsDene);
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
