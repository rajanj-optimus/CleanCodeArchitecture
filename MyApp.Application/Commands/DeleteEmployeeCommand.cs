using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyApp.Core.Interfaces;

namespace MyApp.Application.Commands
{
    public class DeleteEmployeeCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public DeleteEmployeeCommand(Guid Id)
        {
            this.Id = Id;
        }
    }
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        IEmployeeRepository _employeeRepository;
        public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async  Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await _employeeRepository.DeleteEmployeeAsync(request.Id);
        }
    }
}
