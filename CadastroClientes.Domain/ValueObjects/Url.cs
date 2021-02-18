using CadastroClientes.Domain.ValueObjects.Contracts;
using CadastroClientes.Shared.ValueObjects;

namespace CadastroClientes.Domain.ValueObjects
{
    public class Url : ValueObject
    {
        public Url(string value)
        {
            Value = value;

            AddNotifications(new CreateUrlContract(this));
        }
        public string Value { get; private set; }

    }
}
