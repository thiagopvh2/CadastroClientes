using CadastroClientes.Domain.ValueObjects.Contracts;
using CadastroClientes.Shared.ValueObjects;

namespace CadastroClientes.Domain.ValueObjects
{
    public class Cpf : ValueObject
    {
        public Cpf(string value)
        {
            Value = value;

            AddNotifications(new CreateCpfContract(this));
        }

        public string Value { get; private set; }
    }
}
