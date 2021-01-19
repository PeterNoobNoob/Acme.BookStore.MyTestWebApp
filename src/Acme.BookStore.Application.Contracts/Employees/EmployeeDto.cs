using System;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Employees
{
    public class EmployeeDto : EntityDto<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime HireDate { get; set; }

        public string CompanyRole { get; set; }
    }
}