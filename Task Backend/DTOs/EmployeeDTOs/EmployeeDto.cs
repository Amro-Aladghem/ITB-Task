using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Entities;

namespace DTOs.EmployeeDTOs
{
    public class EmployeeDto
    {
        public EmployeeDto(Employee employee)
        {
            Id= employee.Id;
            FirstName= employee.FirstName;
            LastName= employee.LastName;
            JobTitle= employee.JobTitle;
            Level = employee.Level;
            DateOfJoined= employee.DateOfJoined;
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string Level { get; set; }
        public DateOnly DateOfJoined { get; set; }
    }
}
