using Flunt.Localization;
using Flunt.Validations;

namespace CadastroClientes.Domain.Handlers.Requests.Contracts
{
    public class CreateAddressRequestContract : Contract<CreateAddressRequest>
    {
        public CreateAddressRequestContract(CreateAddressRequest request)
        {
            Requires()
                .IsNotNullOrEmpty(request.Street, "Street", "O logradouro não pode estar vazio!")
                .IsNotNullOrEmpty(request.Number, "Number", "O número não pode estar vazio!")
                .IsNotNullOrEmpty(request.Neighborhood, "Neighborhood", "O bairro não pode estar vazio!")
                .IsNotNullOrEmpty(request.City, "City", "A cidade não pode estar vazia!")
                .IsNotNullOrEmpty(request.State, "State", "O estado não pode estar vazio!")
                .IsNotNullOrEmpty(request.ZipCode, "ZipCode", "O CEP não pode estar vazio!")
                .Matches(request.ZipCode, FluntRegexPatterns.OnlyNumbersPattern, "ZipCode", "Apenas números permitidos para o RG!")
                .IsNotNullOrEmpty(request.Identification, "Identification", "É necessário ter uma identificação!");
        }
    }
}
