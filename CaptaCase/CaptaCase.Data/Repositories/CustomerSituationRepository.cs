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
    public class CustomerSituationRepository : Repository<CustomerSituation>, ICustomerSituationRepository
    {
        public CustomerSituationRepository(DbContext dbContext) : base(dbContext) { }
        public async Task<CustomerSituation> GetCustomerSituationeBySituation(string situation) => 
            await _dbSet.SingleOrDefaultAsync(entity => EF.Property<string>(entity, "Situation") == situation);
    }
}
