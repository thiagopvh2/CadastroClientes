using CadastroClientes.Domain.Commands;
using CadastroClientes.Domain.Entities;
using CadastroClientes.Domain.Handlers;
using CadastroClientes.Domain.Handlers.Requests;
using CadastroClientes.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CadastroClientes.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        [HttpGet("GetAll/{search}")]
        public IEnumerable<Customer> GetAll([FromServices] ICustomerRepository repository,string search)
        {
            return repository.GetAll(search);
        }

        [HttpGet("{id:guid}")]
        public Customer Get([FromServices] ICustomerRepository repository, Guid id)
        {
            return repository.GetById(id);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public GenericCommandResult Post([FromBody] CreateCustomerRequest request, [FromServices] CustomerHandler handler)
        {
            return (GenericCommandResult)handler.Handle(request);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }


    }
}
