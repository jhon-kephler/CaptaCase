using CaptaCase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptaCase.Domain.Repositories
{
    public interface ICustomerSituationRepository : IRepository<CustomerSituation>
    {
        Task<CustomerSituation> GetCustomerSituationeBySituation(string situation);
    }
}