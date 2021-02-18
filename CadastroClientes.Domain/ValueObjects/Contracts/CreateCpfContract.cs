using Flunt.Localization;
using Flunt.Validations;

namespace CadastroClientes.Domain.ValueObjects.Contracts
{
    public class CreateCpfContract : Contract<Cpf>
    {
        public CreateCpfContract(Cpf cpf)
        {
            Requires()
                .AreEquals(cpf.Value, 11, "Cpf", "Cpf inválido")
                .Matches(cpf.Value, FluntRegexPatterns.OnlyNumbersPattern, "Cpf", "Cpf inválido");
        }
    }
}
