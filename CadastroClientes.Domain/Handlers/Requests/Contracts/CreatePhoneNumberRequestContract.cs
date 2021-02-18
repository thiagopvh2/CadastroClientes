using Flunt.Validations;

namespace CadastroClientes.Domain.Handlers.Requests.Contracts
{
    public class CreatePhoneNumberRequestContract : Contract<CreateCustomerRequest>
    {
        public CreatePhoneNumberRequestContract(CreatePhoneNumberRequest request)
        {
            Requires()
                .IsNotNullOrEmpty(request.Number, "PhoneNumber")
                .IsNotNullOrEmpty(request.Identification, "Identification", "É necessário ter uma identificação!");
        }
    }
}
