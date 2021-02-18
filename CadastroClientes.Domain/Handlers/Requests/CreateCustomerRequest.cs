using CadastroClientes.Domain.Handlers.Requests.Contracts;
using Flunt.Notifications;
using System;
using System.Collections.Generic;

namespace CadastroClientes.Domain.Handlers.Requests
{
    public class CreateCustomerRequest : Notifiable<Notification>
    {
        public CreateCustomerRequest(string name, DateTime birthDate, ICollection<CreatePhoneNumberRequest> phoneNumbers, ICollection<CreateAddressRequest> adresses, string facebookUrl, string linkedinUrl, string twitterUrl, string instagramUrl, string cpf, string rg)
        {
            Name = name;
            BirthDate = birthDate;
            PhoneNumbers = phoneNumbers;
            Adresses = adresses;
            FacebookUrl = facebookUrl;
            LinkedinUrl = linkedinUrl;
            TwitterUrl = twitterUrl;
            InstagramUrl = instagramUrl;
            Cpf = cpf;
            Rg = rg;

            AddNotifications(new CreateCustomerRequestContract(this));
        }

        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public ICollection<CreatePhoneNumberRequest> PhoneNumbers { get; private set; }
        public ICollection<CreateAddressRequest> Adresses { get; private set; }
        public string FacebookUrl { get; private set; }
        public string LinkedinUrl { get; private set; }
        public string TwitterUrl { get; private set; }
        public string InstagramUrl { get; private set; }
        public string Cpf { get; private set; }
        public string Rg { get; private set; }

    }
}
