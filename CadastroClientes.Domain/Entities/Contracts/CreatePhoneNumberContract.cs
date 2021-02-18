using Flunt.Localization;
using Flunt.Validations;

namespace CadastroClientes.Domain.Entities.Contracts
{
    public class CreatePhoneNumberContract : Contract<PhoneNumber>
    {
        public CreatePhoneNumberContract(PhoneNumber phoneNumber)
        {
            Requires()
                .IsNotNullOrEmpty(phoneNumber.Number, "PhoneNumber")
                .Matches(phoneNumber.Number, FluntRegexPatterns.OnlyNumbersPattern, "Number", "Apenas números permitidos para o número do endereço!")
                .IsNotNullOrEmpty(phoneNumber.Identification, "Identification", "É necessário ter uma identificação!")
                .IsNotEmpty(phoneNumber.CustomerId,"CustomerId");
        }
    }
}
