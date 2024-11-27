using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyApp.Core.Entities;
using MyApp.Core.Interfaces;

namespace MyApp.Application.Query
{
    public class GetEmployeeByIdQuery : IRequest<EmployeeEntity>
    {
        public Guid Id { get; set; }
        public GetEmployeeByIdQuery(Guid Id)
        {
            this.Id = Id;
        }
    }
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeEntity>
    {
        IEmployeeRepository _employeeRepository;
        public GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<EmployeeEntity> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            Guid Id = request.Id;
            return await _employeeRepository.GetEmployeeByIdAsync(Id);
        }
    }
}
