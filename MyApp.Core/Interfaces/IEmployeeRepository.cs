using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Core.Entities;

namespace MyApp.Core.Interfaces
{
    public  interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeEntity>> GetAllEmployeesAsync();
        Task<EmployeeEntity> GetEmployeeByIdAsync(Guid id);
        Task<EmployeeEntity> AddEmployeeAsync(EmployeeEntity employee);
        Task<EmployeeEntity> UpdateEmployeeAsync(Guid employeeId, EmployeeEntity employee);
        Task<bool> DeleteEmployeeAsync(Guid employeeId);

    }
}
