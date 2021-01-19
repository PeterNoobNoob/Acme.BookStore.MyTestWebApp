using Acme.BookStore.Employees;
using System;
using System.ComponentModel.DataAnnotations;

namespace Acme.BookStore.Employees
{
    public class UpdateEmployeeDto
    {
        [Required]
        [StringLength(EmployeeConsts.MaxLastNameLength)]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        public string CompanyRole { get; set; }
    }
}
