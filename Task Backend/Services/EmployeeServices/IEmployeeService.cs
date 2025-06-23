using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.EmployeeDTOs;

namespace Services.EmployeeServices
{
    public interface IEmployeeService
    {
        public Task<List<EmployeeDto>> GetAllEmployees();
        public Task<bool> DeleteEmployee(int EmployeeId);
    }
}
