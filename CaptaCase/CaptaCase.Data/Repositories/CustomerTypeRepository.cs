using CaptaCase.Domain.Entities;
using CaptaCase.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptaCase.Data.Repositories
{
    public class CustomerTypeRepository : Repository<CustomerType>, ICustomerTypeRepository
    {
        public CustomerTypeRepository(DbContext dbContext) : base(dbContext) { }

        public async Task<CustomerType> GetCustomerTypeByType(string type) => await _dbSet.SingleOrDefaultAsync(entity => EF.Property<string>(entity, "Type") == type);
    }
}
