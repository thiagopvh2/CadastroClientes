using CadastroClientes.Domain.Entities.Contracts;
using CadastroClientes.Shared.Entities;
using System;

namespace CadastroClientes.Domain.Entities
{
    public class Address : Entity
    {
        public Address(string street, string number, string neighborhood, string city, string state, string country, string zipCode, string identification, Guid customerId)
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
            Identification = identification;
            CustomerId = customerId;

            AddNotifications(new CreateAddressContract(this));
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
        public string Identification { get; private set; }
        public Guid CustomerId { get; private set; }
        public Customer Customer { get; private set; }

    }

}
