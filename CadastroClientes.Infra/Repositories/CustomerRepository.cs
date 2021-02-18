using CadastroClientes.Domain.Entities;
using CadastroClientes.Domain.Queries;
using CadastroClientes.Domain.Repositories;
using CadastroClientes.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CadastroClientes.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _context;

        public CustomerRepository(CustomerContext context)
        {
            _context = context;
        }

        public void Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public IEnumerable<Customer> GetAll(string search)
        {
            return _context.Customers
               .AsNoTracking()
               .Where(CustomerQueries.GetAll(search))
               .ToList();
        }

        public Customer GetById(Guid id)
        {
            return _context
                .Customers
                .Include(x => x.Addresses)
                .Include(x => x.PhoneNumbers)
                .FirstOrDefault(x => x.Id == id);
        }

        public void Update(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
