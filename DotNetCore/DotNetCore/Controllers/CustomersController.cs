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
        private readonly IDataRepository<Customer> customerRepository;

        public CustomersController(IDataRepository<Customer> customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            return await customerRepository.FetchItemsAsync();
        }

        [HttpGet("{partitionKey}/{id}")]
        public async Task<Customer> Get(string id, string partitionKey)
        {
            return await customerRepository.FetchItemAsync(id, partitionKey);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Customer customer)
        {
            var createdCustomer = await customerRepository.CreateItemAsync(customer);

            return Ok(createdCustomer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody]Customer customer)
        {
            var updatedCustomer = await customerRepository.UpdateItemAsync(id, customer);

            return Ok(updatedCustomer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await customerRepository.DeleteItemAsync(id);

            return Ok();
        }
    }
}
