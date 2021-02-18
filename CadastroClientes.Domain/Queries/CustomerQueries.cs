using CadastroClientes.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace CadastroClientes.Domain.Queries
{
    public static class CustomerQueries
    {
        public static Expression<Func<Customer, bool>> GetAll(string search)
        {
            return x => x.Name.Contains(search);
        }
    }
}
