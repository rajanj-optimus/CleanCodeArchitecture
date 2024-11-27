using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyApp.Core.Entities;
using MyApp.Core.Interfaces;

namespace MyApp.Application.Commands
{
    public  class UpdateEmployeeCommand : IRequest<EmployeeEntity>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public UpdateEmployeeCommand(Guid Id,EmployeeEntity employee)
        {
            this.Id = Id;
            Name = employee.Name;
            Phone = employee.Phone;
            Email = employee.Email;
        }
    }
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, EmployeeEntity>
    {
        IEmployeeRepository _employeeRepository;
        public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeEntity> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            Guid Id = request.Id;
            EmployeeEntity employee = new EmployeeEntity() { Name = request.Name, Phone = request.Phone, Email = request.Email };
            return await _employeeRepository.UpdateEmployeeAsync(Id, employee);
        }
    }
}
