using Acme.BookStore.Employees;
using System;
using System.ComponentModel.DataAnnotations;

namespace Acme.BookStore.Employees
{
    public class CreateEmployeeDto
    {
        public string FirstName { get; set; }

        [Required]
        [StringLength(EmployeeConsts.MaxLastNameLength)]
        public string LastName { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        public string CompanyRole { get; set; }
    }
}