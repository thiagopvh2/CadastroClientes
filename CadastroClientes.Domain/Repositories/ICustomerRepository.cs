using CadastroClientes.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CadastroClientes.Domain.Repositories
{
    public interface ICustomerRepository
    {
        void Create(Customer customer);
        void Update(Customer customer);
        Customer GetById(Guid id);
        IEnumerable<Customer> GetAll(string search);
    }
}