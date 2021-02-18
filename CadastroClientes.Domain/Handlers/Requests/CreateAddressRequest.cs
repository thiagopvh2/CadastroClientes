using CadastroClientes.Domain.Handlers.Requests.Contracts;
using Flunt.Notifications;

namespace CadastroClientes.Domain.Handlers.Requests
{
    public class CreateAddressRequest : Notifiable<Notification>
    {
        public CreateAddressRequest(string street, string number, string neighborhood, string city, string state, string country, string zipCode, string identification)
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
            Identification = identification;

            AddNotifications(new CreateAddressRequestContract(this));
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
        public string Identification { get; private set; }
    }

}
