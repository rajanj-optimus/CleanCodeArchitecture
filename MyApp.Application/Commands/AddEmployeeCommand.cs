using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using MediatR;
using MyApp.Core.Entities;
using MyApp.Core.Interfaces;

namespace MyApp.Application.Commands
{
    public class AddEmployeeCommand : IRequest<EmployeeEntity>
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public AddEmployeeCommand(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }
    }
    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, EmployeeEntity>
    {
        IEmployeeRepository _employeeRepository;
        public AddEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<EmployeeEntity> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new EmployeeEntity
            {
                Id = Guid.NewGuid(),  
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone
            };
            await _employeeRepository.AddEmployeeAsync(employee);
            return employee;
        }
    }
}
