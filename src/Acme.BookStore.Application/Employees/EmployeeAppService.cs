using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acme.BookStore.Employees;
using Acme.BookStore.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Employees
{
    [Authorize(BookStorePermissions.Employees.Default)]
    public class EmployeeAppService : BookStoreAppService, IEmployeeAppService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly EmployeeManager _employeeManager;

        public EmployeeAppService(
            IEmployeeRepository employeeRepository,
            EmployeeManager employeeManager)
        {
            _employeeRepository = employeeRepository;
            _employeeManager = employeeManager;
        }

       public async Task<EmployeeDto> GetAsync(Guid id)
        {
            var employee = await _employeeRepository.GetAsync(id);
            return ObjectMapper.Map<Employee, EmployeeDto>(employee);
        }

        public async Task<PagedResultDto<EmployeeDto>> GetListAsync(GetEmployeeListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Employee.LastName);
            }

            var employees = await _employeeRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            var totalCount = await AsyncExecuter.CountAsync(
                _employeeRepository.WhereIf(
                    !input.Filter.IsNullOrWhiteSpace(),
                    employee => employee.LastName.Contains(input.Filter)
                )
            );

            return new PagedResultDto<EmployeeDto>(
                totalCount,
                ObjectMapper.Map<List<Employee>, List<EmployeeDto>>(employees)
            );
        }

        [Authorize(BookStorePermissions.Employees.Create)]
        public async Task<EmployeeDto> CreateAsync(CreateEmployeeDto input)
        {
            var employee = await _employeeManager.CreateAsync(
                input.FirstName,
                input.LastName,
                input.HireDate,
                input.CompanyRole
            );

            await _employeeRepository.InsertAsync(employee);

            return ObjectMapper.Map<Employee, EmployeeDto>(employee);
        }

        [Authorize(BookStorePermissions.Employees.Edit)]
        public async Task UpdateAsync(Guid id, UpdateEmployeeDto input)
        {
            var employee = await _employeeRepository.GetAsync(id);

            if (employee.LastName != input.LastName)
            {
                await _employeeManager.ChangeNameAsync(employee, input.LastName);
            }

            employee.HireDate = input.HireDate;
            employee.CompanyRole = input.CompanyRole;

            await _employeeRepository.UpdateAsync(employee);
        }

        [Authorize(BookStorePermissions.Employees.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _employeeRepository.DeleteAsync(id);
        }
    }
}