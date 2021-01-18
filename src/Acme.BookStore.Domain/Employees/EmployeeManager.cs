using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Acme.BookStore.Employees
{
    class EmployeeManager : DomainService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> CreateAsync(
            [NotNull] string firstName,
            [NotNull] string lastName,
            DateTime hireDate,
            [CanBeNull] string companyRole = null)
        {
            Check.NotNullOrWhiteSpace(lastName, nameof(lastName));

            var existingEmployee = await _employeeRepository.FindByNameAsync(lastName);
            if (existingEmployee != null)
            {
                throw new EmployeeAlreadyExistsException(lastName);
            }

            return new Employee(
                GuidGenerator.Create(),
                firstName,
                lastName,
                hireDate,
                companyRole
            );
        }

        public async Task ChangeNameAsync(
            [NotNull] Employee employee,
            [NotNull] string newLastName)
        {
            Check.NotNull(employee, nameof(employee));
            Check.NotNullOrWhiteSpace(newLastName, nameof(newLastName));

            var existingEmployee = await _employeeRepository.FindByNameAsync(newLastName);
            if (existingEmployee != null && existingEmployee.Id != employee.Id)
            {
                throw new EmployeeAlreadyExistsException(newLastName);
            }

            employee.ChangeName(newLastName);
        }
    }
}
{
    }
}
