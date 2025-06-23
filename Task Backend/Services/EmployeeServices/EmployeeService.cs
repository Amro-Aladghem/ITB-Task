using Database;
using Database.Entities;
using DTOs.EmployeeDTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.EmployeeServices
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        { 
            _context = context;
        }

        public async Task<List<EmployeeDto>> GetAllEmployees()
        {
            List<Employee> Employees = await _context.Employees.FromSqlInterpolated($"EXEC dbo.SP_GetAllEmployees").ToListAsync();

            List<EmployeeDto> employeeDtos = Employees.Select(e => new EmployeeDto(e))
                                                      .ToList();

            return employeeDtos;
        }

        public async Task<bool> DeleteEmployee(int EmployeeId)
        {
            int NumberOfAffectedRows = await _context.Employees.Where(e => e.Id == EmployeeId).ExecuteDeleteAsync();

            return NumberOfAffectedRows > 0;
        }
    }
}
