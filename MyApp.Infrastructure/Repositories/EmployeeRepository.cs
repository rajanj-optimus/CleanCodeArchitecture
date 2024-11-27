using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyApp.Core.Entities;
using MyApp.Core.Interfaces;
using MyApp.Infrastructure.Data;

namespace MyApp.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;
        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<EmployeeEntity>> GetAllEmployeesAsync()
        {
            var result = await _appDbContext.Employees.ToListAsync();
            return result;
        }

        public async Task<EmployeeEntity> GetEmployeeByIdAsync(Guid id)
        {
            var result  = await _appDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<EmployeeEntity> AddEmployeeAsync(EmployeeEntity employee)
        {
            employee.Id = Guid.NewGuid();
            _appDbContext.Employees.Add(employee);
            await _appDbContext.SaveChangesAsync();
            return employee;
        }

        public async Task<EmployeeEntity> UpdateEmployeeAsync(Guid employeeId, EmployeeEntity employee)
        {
            var result  = await _appDbContext.Employees.FirstOrDefaultAsync(x => x.Id == employeeId);
            if(result is not null)
            {
                result.Name = employee.Name;
                result.Phone = employee.Phone;
                result.Email = employee.Email;
                await _appDbContext.SaveChangesAsync();
            }
            return employee;

        }

        public async Task<bool> DeleteEmployeeAsync(Guid employeeId)
        {
            var result = await _appDbContext.Employees.FirstOrDefaultAsync(x => x.Id == employeeId);
            if( result is not null )
            {
                _appDbContext.Employees.Remove(result);
                return await _appDbContext.SaveChangesAsync() > 0;
            }
            return false;
        }


    }
}
