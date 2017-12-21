using DotNetCore.Interfaces;
using DotNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace DotNetCore.Controllers
{
    [Route("api/[controller]")]
    public class SetupController
        : Controller
    {
        private readonly DocumentSettings documentSettings;
        private readonly IDataRepository<Customer> customerRepository;

        public SetupController(IOptions<DocumentSettings> options, IDataRepository<Customer> customerRepository)
        {
            documentSettings = options.Value;
            this.customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await customerRepository.InitializeDatabaseAsync(documentSettings.DatabaseId, documentSettings.CollectionId);

            return Ok();
        }
    }
}
