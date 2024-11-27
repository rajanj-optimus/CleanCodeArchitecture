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
    public class GetAllEmployeesQuery: IRequest<IEnumerable<EmployeeEntity>>
    {

    }
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeEntity>>
    {
        IEmployeeRepository _employeeRepository;
        public GetAllEmployeesQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<IEnumerable<EmployeeEntity>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            return await _employeeRepository.GetAllEmployeesAsync();
        }
    }
}
