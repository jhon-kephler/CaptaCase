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
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext dbContext) : base(dbContext) { }

        public async Task<Customer> GetCustomerByCPF(string CPF) => await _dbSet.SingleOrDefaultAsync(entity => EF.Property<string>(entity, "CPF") == CPF);

        public void UpdateCustomer(Customer entity)
        {
            var existingEntity = _dbSet.Find(entity.CPF);
            if (existingEntity != null)
            {
                var properties = typeof(Customer).GetProperties();
                foreach (var property in properties)
                {
                    var newValue = property.GetValue(entity);
                    var oldValue = property.GetValue(existingEntity);
                    var propertyName = property.Name;

                    if (newValue != null && !newValue.Equals(oldValue))
                    {
                        if (!IsZero(newValue))
                        {
                            property.SetValue(existingEntity, newValue);
                            _dbContext.Entry(existingEntity).Property(propertyName).IsModified = true;
                        }
                    }
                }
                _dbContext.SaveChanges();
            }
        }

        public void DeleteCustomer(string cpf)
        {
            var entity = _dbSet.Find(cpf);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("A entidade com o ID fornecido não foi encontrado.");
            }
        }
    }
}
