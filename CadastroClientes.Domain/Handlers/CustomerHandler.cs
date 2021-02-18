using CadastroClientes.Domain.Commands;
using CadastroClientes.Domain.Commands.Contracts;
using CadastroClientes.Domain.Entities;
using CadastroClientes.Domain.Handlers.Requests;
using CadastroClientes.Domain.Repositories;
using CadastroClientes.Domain.ValueObjects;
using Flunt.Notifications;

namespace CadastroClientes.Domain.Handlers
{
    public class CustomerHandler : Notifiable<Notification>
    {
        private readonly ICustomerRepository _repository;

        public CustomerHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateCustomerRequest request)
        {
            if (!request.IsValid)
            {
                AddNotifications(request.Notifications);
                return new GenericCommandResult(false, "Requisição inválida!", request.Notifications);
            }

            var facebookUrl = new Url(request.FacebookUrl);
            var linkedinUrl = new Url(request.LinkedinUrl);
            var twitterUrl = new Url(request.TwitterUrl);
            var instagramUrl = new Url(request.InstagramUrl);

            var cpf = new Cpf(request.Cpf);

            var customer = new Customer(request.Name, request.BirthDate, facebookUrl, linkedinUrl, twitterUrl, instagramUrl, cpf, request.Rg);

            foreach (var requestPhoneNumber in request.PhoneNumbers)
            {
                var phoneNumber = new PhoneNumber(requestPhoneNumber.Number, requestPhoneNumber.Identification,customer.Id);
                customer.AddPhoneNumber(phoneNumber);
                AddNotifications(phoneNumber.Notifications);
            }

            foreach (var requestAddress in request.Adresses)
            {
                var address = new Address(requestAddress.Street, requestAddress.Number, requestAddress.Neighborhood, requestAddress.City, requestAddress.State, requestAddress.Country, requestAddress.ZipCode, requestAddress.Identification, customer.Id);
                customer.AddAddress(address);
                AddNotifications(address.Notifications);
            }

            AddNotifications(facebookUrl.Notifications);
            AddNotifications(linkedinUrl.Notifications);
            AddNotifications(twitterUrl.Notifications);
            AddNotifications(instagramUrl.Notifications);
            AddNotifications(cpf.Notifications);
            AddNotifications(customer.Notifications);

            if (!IsValid)
            {
                return new GenericCommandResult(IsValid, "Erro ao criar cliente!", Notifications);
            }

            _repository.Create(customer);

            return new GenericCommandResult(IsValid, "Cliente criado!", Notifications);
        }
    }
}
