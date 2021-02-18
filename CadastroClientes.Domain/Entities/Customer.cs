using CadastroClientes.Domain.Entities.Contracts;
using CadastroClientes.Domain.ValueObjects;
using CadastroClientes.Shared.Entities;
using System;
using System.Collections.Generic;

namespace CadastroClientes.Domain.Entities
{
    public class Customer : Entity
    {
        public Customer(string name, DateTime birthDate, Url facebookUrl, Url linkedinUrl, Url twitterUrl, Url instagramUrl, Cpf cpf, string rg)
        {
            Name = name;
            BirthDate = birthDate;
            PhoneNumbers = new List<PhoneNumber>();
            Addresses = new List<Address>();
            FacebookUrl = facebookUrl;
            LinkedinUrl = linkedinUrl;
            TwitterUrl = twitterUrl;
            InstagramUrl = instagramUrl;
            Cpf = cpf;
            Rg = rg;

            AddNotifications(new CreateCustomerContract(this));
        }
        protected Customer()
        {

        }

        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public IList<PhoneNumber> PhoneNumbers { get; private set; }
        public IList<Address> Addresses { get; private set; }
        public Url FacebookUrl { get; private set; }
        public Url LinkedinUrl { get; private set; }
        public Url TwitterUrl { get; private set; }
        public Url InstagramUrl { get; private set; }
        public Cpf Cpf { get; private set; }
        public string Rg { get; private set; }

        public void AddPhoneNumber(PhoneNumber phoneNumber)
        {
            PhoneNumbers.Add(phoneNumber);
        }

        public void AddAddress(Address address)
        {
            Addresses.Add(address);
        }

    }
}
