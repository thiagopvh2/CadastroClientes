using CadastroClientes.Domain.Handlers.Requests.Contracts;
using Flunt.Notifications;

namespace CadastroClientes.Domain.Handlers.Requests
{
    public class CreatePhoneNumberRequest : Notifiable<Notification>
    {
        public CreatePhoneNumberRequest(string number, string identification)
        {
            Number = number;
            Identification = identification;

            AddNotifications(new CreatePhoneNumberRequestContract(this));
        }

        public string Number { get; private set; }
        public string Identification { get; private set; }

    }
}
