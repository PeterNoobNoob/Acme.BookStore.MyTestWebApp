﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Employees
{
    public interface IEmployeeRepository : IRepository<Employee, Guid>
    {
        Task<Employee> FindByNameAsync(string lastName);

        Task<List<Employee>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}