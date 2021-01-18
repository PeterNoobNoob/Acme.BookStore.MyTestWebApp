using Volo.Abp;

namespace Acme.BookStore.Employees
{
    class EmployeeAlreadyExistsException : BusinessException
    {
        public EmployeeAlreadyExistsException(string lastName)
            : base(BookStoreDomainErrorCodes.AuthorAlreadyExists)
        {
            WithData("lastName", lastName);
        }
    }
}
