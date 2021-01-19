using Acme.BookStore.Employees;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.Employees
{
    public interface IEmployeeAppService : IApplicationService
    {
        Task<EmployeeDto> GetAsync(Guid id);

        Task<PagedResultDto<EmployeeDto>> GetListAsync(GetEmployeeListDto input);

        Task<EmployeeDto> CreateAsync(CreateEmployeeDto input);

        Task UpdateAsync(Guid id, UpdateEmployeeDto input);

        Task DeleteAsync(Guid id);
    }
}