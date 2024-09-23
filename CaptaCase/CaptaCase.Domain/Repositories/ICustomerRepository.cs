using CaptaCase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptaCase.Domain.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        void DeleteCustomer(string cpf);
        void UpdateCustomer(Customer entity);
        Task<Customer> GetCustomerByCPF(string CPF);
    }
}
