using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Employees
{
    class Employee : FullAuditedAggregateRoot<Guid>
    {
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public DateTime HireDate { get; set; }
    public string CompanyRole { get; set; }

    private Employee()
    {
        /* This constructor is for deserialization / ORM purpose */
    }

    internal Employee(
        Guid id,
        [NotNull] string firstName,
        [NotNull] string lastName,
        DateTime hireDate,
        [CanBeNull] string companyRole = null)
        : base(id)
    {
        SetName(lastName);
        FirstName = firstName;
        HireDate = hireDate;
        CompanyRole = CompanyRole;
    }

    internal Employee ChangeName([NotNull] string lastName)
    {
        SetName(lastName);
        return this;
    }

    private void SetName([NotNull] string lastName)
    {
        LastName = Check.NotNullOrWhiteSpace(
            lastName,
            nameof(lastName),
            maxLength: EmployeeConsts.MaxFirstNameLength
            );
        }
    }
}
