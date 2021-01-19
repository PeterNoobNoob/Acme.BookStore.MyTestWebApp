using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Employees
{
    public class GetEmployeeListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}