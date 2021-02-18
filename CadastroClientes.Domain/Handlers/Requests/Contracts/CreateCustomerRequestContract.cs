using Flunt.Validations;
using System;

namespace CadastroClientes.Domain.Handlers.Requests.Contracts
{
    public class CreateCustomerRequestContract : Contract<CreateCustomerRequest>
    {
        public CreateCustomerRequestContract(CreateCustomerRequest request)
        {
            Requires()
                .IsNotNullOrEmpty(request.Name, "Name", "O nome não deve estar vazio!")
                .IsLowerOrEqualsThan(request.BirthDate, DateTime.Now, "BirthDate", "A data de nascimento não pode ser maior que o dia de hoje!")
                .IsUrlOrEmpty(request.FacebookUrl, "FacebookUrl", "Deve conter uma url do Facebook válida!")
                .IsUrlOrEmpty(request.LinkedinUrl, "LinkedinUrl", "Deve conter uma url do Linkedin válida!")
                .IsUrlOrEmpty(request.TwitterUrl, "TwitterUrl", "Deve conter uma url do Twitter válida!")
                .IsUrlOrEmpty(request.InstagramUrl, "InstagramUrl", "Deve conter uma url do Instagram válida!")
                .AreEquals(request.Cpf, 11, "Cpf", "O Cpf deve conter 11 números!")
                .IsNotNullOrEmpty(request.Rg, "Rg", "O RG não deve estar vazio!");
        }
    }
}
