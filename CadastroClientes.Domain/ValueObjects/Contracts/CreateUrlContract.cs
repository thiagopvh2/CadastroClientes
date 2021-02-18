using Flunt.Validations;

namespace CadastroClientes.Domain.ValueObjects.Contracts
{
    public class CreateUrlContract : Contract<Url>
    {
        public CreateUrlContract(Url url)
        {
            Requires().IsUrlOrEmpty(url.Value, "Url", "A URL não pode estar vazia!");
        }
    }
}
