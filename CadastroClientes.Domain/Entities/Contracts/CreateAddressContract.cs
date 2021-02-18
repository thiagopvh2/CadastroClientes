using Flunt.Localization;
using Flunt.Validations;

namespace CadastroClientes.Domain.Entities.Contracts
{
    public class CreateAddressContract : Contract<Address>
    {
        public CreateAddressContract(Address address)
        {
            Requires()
                .IsNotNullOrEmpty(address.Street, "Street", "O logradouro não pode estar vazio!")
                .IsNotNullOrEmpty(address.Number, "Number", "O número não pode estar vazio!")
                .Matches(address.Number, FluntRegexPatterns.OnlyNumbersPattern, "Number", "Apenas números permitidos para o número do endereço!")
                .IsNotNullOrEmpty(address.Neighborhood, "Neighborhood", "O bairro não pode estar vazio!")
                .IsNotNullOrEmpty(address.City, "City", "A cidade não pode estar vazia!")
                .IsNotNullOrEmpty(address.State, "State", "O estado não pode estar vazio!")
                .IsNotNullOrEmpty(address.ZipCode, "ZipCode", "O CEP não pode estar vazio!")
                .Matches(address.ZipCode, FluntRegexPatterns.OnlyNumbersPattern, "ZipCode", "Apenas números permitidos para o RG!")
                .IsNotNullOrEmpty(address.Identification, "Identification", "É necessário ter uma identificação!")
                .IsNotEmpty(address.CustomerId, "CustomerId");
            ;
        }
    }
}
