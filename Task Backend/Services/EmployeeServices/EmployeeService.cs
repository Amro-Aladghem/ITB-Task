using Database;
using Database.Entities;
using DTOs.EmployeeDTOs;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

        public bool IsAddEmployeeInfoCorrect(AddEmployeeDto addEmployeeDto)
        {
            if(string.IsNullOrEmpty(addEmployeeDto.Level)|| string.IsNullOrEmpty(addEmployeeDto.FirstName) || string.IsNullOrEmpty(addEmployeeDto.LastName)
                || string.IsNullOrEmpty(addEmployeeDto.JobTitle))
            {
                return false;
            }

            return true;
        }

        public bool IsUpdateEmployeeInfoCorrect(UpdateEmployeDto updateEmployeDto)
        {
            if(updateEmployeDto.EmployeeId<=0 || string.IsNullOrEmpty(updateEmployeDto.FirstName) || string.IsNullOrEmpty(updateEmployeDto.LastName)
                || string.IsNullOrEmpty(updateEmployeDto.Level) || string.IsNullOrEmpty(updateEmployeDto.JobTitle))
            {
                return false;
            }

            return true;
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

        public async Task<bool> AddNewEmployee(AddEmployeeDto addEmployeeDto)
        {
            int NumberOfRowAffected = await _context.Database.ExecuteSqlRawAsync("EXEC dbo.SP_AddNewEmployee @p0,@p1,@p2,@p3",
                                                                               addEmployeeDto.FirstName, addEmployeeDto.LastName, addEmployeeDto.JobTitle, addEmployeeDto.Level);

            return NumberOfRowAffected > 0;
        }

        public async Task<bool> UpdateEmployee(UpdateEmployeDto updateEmployeDto)
        {
            int NumberOfRowAffected = await _context.Database.ExecuteSqlRawAsync("EXEC dbo.SP_UpdateEmployee @p0,@p1,@p2,@p3,@p4",
                                                                             updateEmployeDto.EmployeeId, updateEmployeDto.FirstName, updateEmployeDto.LastName,
                                                                             updateEmployeDto.JobTitle, updateEmployeDto.Level);

            return NumberOfRowAffected > 0;
        }

        public async Task<EmployeeDto?> GetEmployeeInfo(int EmployeeId)
        {
            EmployeeDto? employeeInfo = await _context.Employees.Where(E => E.Id == EmployeeId).Select(E => new EmployeeDto()
            {
                Id = E.Id,
                FirstName = E.FirstName,
                LastName = E.LastName,
                JobTitle = E.JobTitle,
                Level = E.Level,
                DateOfJoined = E.DateOfJoined

            }).FirstOrDefaultAsync();

            return employeeInfo;
        }
    }
}
