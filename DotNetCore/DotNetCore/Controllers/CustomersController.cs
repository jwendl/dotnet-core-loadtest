using DotNetCore.Interfaces;
using DotNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetCore.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController
        : Controller
    {
        private readonly IDataRepository<string, Customer> customerRepository;

        public CustomersController(IDataRepository<string, Customer> customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [HttpGet("{partitionKey}")]
        public async Task<IEnumerable<Customer>> Get(string partitionKey)
        {
            return await customerRepository.FetchItemsAsync(partitionKey);
        }

        [HttpGet("{partitionKey}/{id}")]
        public async Task<Customer> Get(string partitionKey, string id)
        {
            return await customerRepository.FetchItemAsync(partitionKey, id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Customer customer)
        {
            var createdCustomer = await customerRepository.CreateItemAsync(customer.Address.State, customer);

            return Ok(createdCustomer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody]Customer customer)
        {
            var updatedCustomer = await customerRepository.UpdateItemAsync(customer.Address.State, id, customer);

            return Ok(updatedCustomer);
        }

        [HttpDelete("{partitionKey}/{id}")]
        public async Task<IActionResult> Delete(string partitionKey, string id)
        {
            await customerRepository.DeleteItemAsync(partitionKey, id);

            return Ok();
        }
    }
}
