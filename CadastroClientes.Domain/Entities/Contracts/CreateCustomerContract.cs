using Flunt.Localization;
using Flunt.Validations;
using System;

namespace CadastroClientes.Domain.Entities.Contracts
{
    public class CreateCustomerContract : Contract<Customer>
    {
        public CreateCustomerContract(Customer customer)
        {
            Requires()
                .IsNotNullOrEmpty(customer.Name, "Name", "O nome não deve estar vazio!")
                .IsLowerOrEqualsThan(customer.BirthDate, DateTime.Now, "BirthDate", "A data de nascimento não pode ser maior que o dia de hoje!")
                .IsNotNullOrEmpty(customer.Rg, "Rg", "O RG não deve estar vazio!")
                .Matches(customer.Rg, FluntRegexPatterns.OnlyNumbersPattern, "Rg", "Apenas números permitidos para o RG!");
        }
    }
}
