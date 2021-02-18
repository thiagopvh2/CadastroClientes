using CadastroClientes.Domain.Entities.Contracts;
using CadastroClientes.Shared.Entities;
using System;

namespace CadastroClientes.Domain.Entities
{
    public class PhoneNumber : Entity
    {
        public PhoneNumber(string number, string identification, Guid customerId)
        {
            Number = number;
            Identification = identification;
            CustomerId = customerId;

            AddNotifications(new CreatePhoneNumberContract(this));
        }
        public string Number { get; private set; }
        public string Identification { get; private set; }
        public Guid CustomerId { get; private set; }
        public Customer Customer { get; private set; }

    }
}
